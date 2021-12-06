namespace Fc.Protofolio.Winforms
{
    partial class frmAddOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cmbOrderType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.symbolLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.toDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.txtQuantity = new DevExpress.XtraEditors.TextEdit();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.txtCost = new DevExpress.XtraEditors.TextEdit();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOrderType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.symbolLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCost.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(273, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(96, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Stock Symbol";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(482, 42);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(32, 19);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Date";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(691, 42);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 19);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Quantity";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(859, 42);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(79, 19);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Price/Stock";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(1026, 42);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(31, 19);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Cost";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(64, 42);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(38, 19);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Mode";
            // 
            // cmbOrderType
            // 
            this.cmbOrderType.EditValue = "Buy";
            this.cmbOrderType.Location = new System.Drawing.Point(64, 77);
            this.cmbOrderType.Name = "cmbOrderType";
            this.cmbOrderType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbOrderType.Size = new System.Drawing.Size(150, 26);
            this.cmbOrderType.TabIndex = 6;
            // 
            // symbolLookUpEdit
            // 
            this.symbolLookUpEdit.EditValue = "";
            this.symbolLookUpEdit.Location = new System.Drawing.Point(273, 77);
            this.symbolLookUpEdit.Name = "symbolLookUpEdit";
            this.symbolLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.symbolLookUpEdit.Properties.DisplayMember = "Symbol";
            this.symbolLookUpEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSuggest;
            this.symbolLookUpEdit.Properties.ValueMember = "Symbol";
            this.symbolLookUpEdit.Size = new System.Drawing.Size(150, 26);
            this.symbolLookUpEdit.TabIndex = 7;
            this.symbolLookUpEdit.AutoSuggest += new DevExpress.XtraEditors.Controls.LookUpEditAutoSuggestEventHandler(this.symbolLookUpEdit_AutoSuggest);
            this.symbolLookUpEdit.EditValueChanged += new System.EventHandler(this.symbolLookUpEdit_EditValueChanged);
            // 
            // toDateEdit
            // 
            this.toDateEdit.EditValue = null;
            this.toDateEdit.Location = new System.Drawing.Point(482, 77);
            this.toDateEdit.Name = "toDateEdit";
            this.toDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.toDateEdit.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.False;
            this.toDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.toDateEdit.Properties.MaxValue = new System.DateTime(2021, 12, 6, 0, 0, 0, 0);
            this.toDateEdit.Size = new System.Drawing.Size(150, 26);
            this.toDateEdit.TabIndex = 8;
            this.toDateEdit.DrawItem += new DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventHandler(this.toDateEdit_DrawItem);
            this.toDateEdit.EditValueChanged += new System.EventHandler(this.toDateEdit_EditValueChanged);
            // 
            // txtQuantity
            // 
            this.txtQuantity.EditValue = "";
            this.txtQuantity.Location = new System.Drawing.Point(691, 77);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQuantity.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.RegExpMaskManager));
            this.txtQuantity.Properties.MaskSettings.Set("mask", "\\d+");
            this.txtQuantity.Properties.MaxLength = 5;
            this.txtQuantity.Size = new System.Drawing.Size(109, 26);
            this.txtQuantity.TabIndex = 9;
            this.txtQuantity.EditValueChanged += new System.EventHandler(this.txtQuantity_EditValueChanged);
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.Location = new System.Drawing.Point(859, 77);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(109, 26);
            this.txtPrice.TabIndex = 10;
            // 
            // txtCost
            // 
            this.txtCost.Enabled = false;
            this.txtCost.Location = new System.Drawing.Point(1027, 77);
            this.txtCost.Name = "txtCost";
            this.txtCost.Properties.ReadOnly = true;
            this.txtCost.Size = new System.Drawing.Size(109, 26);
            this.txtCost.TabIndex = 11;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(1195, 72);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(134, 37);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmAddOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 167);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.toDateEdit);
            this.Controls.Add(this.symbolLookUpEdit);
            this.Controls.Add(this.cmbOrderType);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmAddOrder";
            this.Text = "AddOrder";
            ((System.ComponentModel.ISupportInitialize)(this.cmbOrderType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.symbolLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCost.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ComboBoxEdit cmbOrderType;
        private DevExpress.XtraEditors.LookUpEdit symbolLookUpEdit;
        private DevExpress.XtraEditors.DateEdit toDateEdit;
        private DevExpress.XtraEditors.TextEdit txtQuantity;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private DevExpress.XtraEditors.TextEdit txtCost;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
    }
}