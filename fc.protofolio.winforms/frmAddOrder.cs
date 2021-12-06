using DevExpress.XtraEditors;
using Fc.Protofolio.Winforms.Helper;
using Fc.Protofolio.Winforms.Models;
using Fc.Protofolio.Winforms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fc.Protofolio.Winforms
{
    public partial class frmAddOrder : Form
    {

        private readonly IProtofolioAPIClient _protofolioAPIClient;
        private Order _selectedOrder;
        private List<Order> _orders;
        private readonly Holdings holdings;
        public bool RefreshRequried = false;

        OrderType _orderType;
        #region Constructor

        public frmAddOrder(IProtofolioAPIClient protofolioAPIClient, List<Order> orders, Holdings holdings, OrderType orderType = OrderType.BUY)
        {
            InitializeComponent();
            symbolLookUpEdit.Properties.PopupWidth = 800;
            toDateEdit.Properties.MaxValue = DateTime.Today;

            toDateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            toDateEdit.Properties.Mask.EditMask = Constants.API_DATEFORMAT;
            toDateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
           
           
            _protofolioAPIClient = protofolioAPIClient;
            _orders = orders;
            this.holdings = holdings;
            _orderType = orderType;
            InitializeDefaultValue();
        }

        #endregion

        #region PrivateMethods
        private void InitializeDefaultValue()
        {
            _selectedOrder = new Order();

            if (_orderType == OrderType.SELL)
            {

                _selectedOrder.OrderType = OrderType.SELL;
                _selectedOrder.Quantity = holdings.Quantity;

                _selectedOrder.Symbol = holdings.Symbol;
                cmbOrderType.Properties.Items.AddRange(new string[] { "Sell" });
                cmbOrderType.SelectedIndex = 0;
                cmbOrderType.Enabled = false;

                toDateEdit.EditValue = GetPreviousWorkingDay();
                toDateEdit.Enabled = false;
                symbolLookUpEdit.EditValue = holdings.Symbol;
                symbolLookUpEdit.Enabled = false;


                txtQuantity.Text = holdings.Quantity.ToString();
                txtQuantity.Enabled = false;


            }
            else
            {
                _selectedOrder.OrderType = OrderType.BUY;
                _selectedOrder.Quantity = 10;
                cmbOrderType.Properties.Items.AddRange(new string[] { "Buy" });
                cmbOrderType.SelectedIndex = 0;
                txtQuantity.Text = _selectedOrder.Quantity.ToString();
            }

        }

        private void PerpareOrder()
        {
            var symbol = _orderType == OrderType.BUY ? (symbolLookUpEdit.GetSelectedDataRow() as StockSymbol).Symbol : _selectedOrder.Symbol;
            ;
            _selectedOrder.Symbol = symbol;
            _selectedOrder.OrderType = _orderType;
            _selectedOrder.DateTime = DateTime.ParseExact(toDateEdit.Text, Constants.API_DATEFORMAT, null);
            _selectedOrder.BrokageFee = 0;
            _selectedOrder.IsDeleted = false;
            _selectedOrder.Id = Guid.NewGuid();
        }

        private bool ValidateControls(ref string errorMsg)
        {
            if (_selectedOrder.Quantity <= 0)
            {
                errorMsg = "Please input Quantity";
                txtQuantity.Focus();
            }
            else if (String.IsNullOrEmpty(toDateEdit.Text))
            {
                errorMsg = "Please input Date";
                toDateEdit.Focus();
            }
            else if (_orderType == OrderType.BUY && symbolLookUpEdit.GetSelectedDataRow() as StockSymbol == null)
            {
                errorMsg = "Please input Symbol";
                symbolLookUpEdit.Focus();
            }
            else if (_selectedOrder.Price == 0)
            {
                errorMsg = "Invalid Price";
                txtPrice.Focus();
            }
            else
            {
                return true;
            }

            return false;
        }

        private DateTime GetPreviousWorkingDay()
        {
            DateTime today = DateTime.Now;
            DateTime prevWorkday = today.AddDays(-1);
            while (prevWorkday.DayOfWeek == DayOfWeek.Saturday || prevWorkday.DayOfWeek == DayOfWeek.Sunday)
            {
                prevWorkday = prevWorkday.AddDays(-1);
            }
            //DateTime previousWeekStart = startingDate.AddDays(-7);
            return prevWorkday;
        }
        private async Task CalculatePrice()
        {
            var symbol = symbolLookUpEdit.GetSelectedDataRow() as StockSymbol;
            if (symbol == null && _orderType == OrderType.SELL)
            {
                symbol = new StockSymbol() { Symbol = holdings.Symbol };
            }
            if (!String.IsNullOrEmpty(toDateEdit.Text) && symbol != null)
            {
                var ohlc = await GetLTP(symbol.Symbol, toDateEdit.Text);
                if (ohlc != null)
                {
                    _selectedOrder.Price = Math.Round(ohlc.Close, 2);
                    txtPrice.Text = _selectedOrder.Price.ToString();
                    txtCost.Text = _selectedOrder.Cost.ToString(); ;
                }
            }
        }
        private async Task<Ohlc> GetLTP(string symbol, string date)
        {
            try
            {
                return await _protofolioAPIClient.GetAsync<Ohlc>($"stockquote/ltp?symbol={symbol}&date={date}");
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "An Error Occured");
            }
            return null;
        }

        private async Task<bool> SubmitOrder(Order order)
        {
            try
            {
                return await _protofolioAPIClient.PostAsync<bool, Order>($"orders/add", order);
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "An Error Occured");
            }
            return false;
        } 
        #endregion

        #region Events

        private void symbolLookUpEdit_AutoSuggest(object sender, DevExpress.XtraEditors.Controls.LookUpEditAutoSuggestEventArgs e)
        {

            e.SetMinimumAnimationDuration(TimeSpan.FromMilliseconds(1000));
            // Assign a Task that returns suggestions
            var delay = Task.Delay(2000, e.CancellationToken);
            e.QuerySuggestions = delay.ContinueWith(async _ =>
            {
                try
                {
                    if (!String.IsNullOrEmpty(e.Text))
                    {
                        var result = await _protofolioAPIClient.GetAsyncWithCancellation<List<StockSymbol>>($"stockquote/symbolsearch?keywords={e.Text}", e.CancellationToken);

                        return (result as System.Collections.ICollection);

                    }
                }
                catch (TaskCanceledException)
                {
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "An Error Occured");


                }
                return Array.Empty<StockSymbol>();
            }).Unwrap();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var errorMsg = "";
                if (ValidateControls(ref errorMsg))
                {
                    PerpareOrder();
                    if (await SubmitOrder(_selectedOrder))
                    {
                        XtraMessageBox.Show("Order created successful", Constants.MSG_TITLE);
                        RefreshRequried = true;
                        this.Close();
                    }
                }
                else
                {
                    XtraMessageBox.Show(errorMsg, "Validation Failed");
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "An Error Occured");
            }
        }
        private void txtQuantity_EditValueChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtQuantity.Text))
            {
                _selectedOrder.Quantity = Convert.ToInt32(txtQuantity.Text);
                txtCost.Text = _selectedOrder.Cost.ToString();
            }
        }
        private void toDateEdit_DrawItem(object sender, DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs e)
        {
            if (e.Date.DayOfWeek == DayOfWeek.Saturday || e.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                e.Handled = true;
            }
        }

        private async void symbolLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            await CalculatePrice();
        }

        private async void toDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            await CalculatePrice();
        }

        #endregion
    }


}
