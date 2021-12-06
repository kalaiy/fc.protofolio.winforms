using DevExpress.XtraEditors;
using Fc.Protofolio.Winforms.Models;
using Fc.Protofolio.Winforms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fc.Protofolio.Winforms
{
    public partial class fmProtofolioMgt : Form
    {
        private readonly IProtofolioAPIClient _protofolioAPIClient;
        private List<Order> _orders;

        #region Constructor

        public fmProtofolioMgt(IProtofolioAPIClient protofolioAPIClient)
        {
            InitializeComponent();
            _protofolioAPIClient = protofolioAPIClient;
        }

        #endregion

        #region PrivateMethods
        private async Task LoadOrders()
        {
            _orders = await _protofolioAPIClient.GetAsync<List<Order>>("orders/all");

            gcTranscation.DataSource = _orders.OrderByDescending(o => o.DateTime);
            gcPLReport.DataSource = await GetHoldings();
        }

        private async Task<List<Holdings>> GetHoldings()
        {
            return await _protofolioAPIClient.GetAsync<List<Holdings>>("orders/holdings");
        }
        #endregion

        #region Events
        private async void fmProtofolioMgt_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadOrders();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "An Error Occured");
            }
        }

        private async void btnAddOrder_Click(object sender, EventArgs e)
        {

            try
            {

                frmAddOrder addOrder = new frmAddOrder(_protofolioAPIClient, _orders, null);
                addOrder.ShowDialog();
                if (addOrder.RefreshRequried)
                {
                    await LoadOrders();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "An Error Occured");
            }
        }

        private async void sellButton_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {

                var holding = gridView1.GetFocusedRow() as Holdings; ;
                if (holding != null)
                {
                    frmAddOrder addOrder = new frmAddOrder(_protofolioAPIClient, _orders, holding, OrderType.SELL);
                    addOrder.ShowDialog();
                    if (addOrder.RefreshRequried)
                    {
                        await LoadOrders();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "An Error Occured");
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string path = "D:\\transcation.xlsx";
            gcTranscation.ExportToXlsx(path);

            Process.Start(path);
        }

        #endregion

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                await LoadOrders();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "An Error Occured");
            }
        }
    }
}
