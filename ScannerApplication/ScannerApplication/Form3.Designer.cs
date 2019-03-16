namespace ScannerApplication
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.LabelTitle = new System.Windows.Forms.Label();
            this.ButtonReturn = new System.Windows.Forms.Button();
            this.TextBoxPart = new System.Windows.Forms.TextBox();
            this.TextBoxPartQuantity = new System.Windows.Forms.TextBox();
            this.ButtonAddPart = new System.Windows.Forms.Button();
            this.ListViewParts = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // LabelTitle
            // 
            this.LabelTitle.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.LabelTitle.Location = new System.Drawing.Point(228, 4);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(100, 27);
            this.LabelTitle.Text = "Parts";
            this.LabelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ButtonReturn
            // 
            this.ButtonReturn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ButtonReturn.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.ButtonReturn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ButtonReturn.Location = new System.Drawing.Point(312, 298);
            this.ButtonReturn.Name = "ButtonReturn";
            this.ButtonReturn.Size = new System.Drawing.Size(100, 37);
            this.ButtonReturn.TabIndex = 18;
            this.ButtonReturn.Text = "Return";
            this.ButtonReturn.Click += new System.EventHandler(this.ButtonReturn_Click);
            // 
            // TextBoxPart
            // 
            this.TextBoxPart.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.TextBoxPart.Location = new System.Drawing.Point(155, 236);
            this.TextBoxPart.Name = "TextBoxPart";
            this.TextBoxPart.Size = new System.Drawing.Size(173, 26);
            this.TextBoxPart.TabIndex = 20;
            // 
            // TextBoxPartQuantity
            // 
            this.TextBoxPartQuantity.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.TextBoxPartQuantity.Location = new System.Drawing.Point(341, 236);
            this.TextBoxPartQuantity.Name = "TextBoxPartQuantity";
            this.TextBoxPartQuantity.Size = new System.Drawing.Size(60, 26);
            this.TextBoxPartQuantity.TabIndex = 21;
            // 
            // ButtonAddPart
            // 
            this.ButtonAddPart.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ButtonAddPart.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.ButtonAddPart.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ButtonAddPart.Location = new System.Drawing.Point(155, 298);
            this.ButtonAddPart.Name = "ButtonAddPart";
            this.ButtonAddPart.Size = new System.Drawing.Size(100, 37);
            this.ButtonAddPart.TabIndex = 22;
            this.ButtonAddPart.Text = "Add";
            this.ButtonAddPart.Click += new System.EventHandler(this.ButtonAddPart_Click);
            // 
            // ListViewParts
            // 
            this.ListViewParts.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.ListViewParts.FullRowSelect = true;
            this.ListViewParts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ListViewParts.Location = new System.Drawing.Point(155, 34);
            this.ListViewParts.Name = "ListViewParts";
            this.ListViewParts.Size = new System.Drawing.Size(246, 200);
            this.ListViewParts.TabIndex = 24;
            this.ListViewParts.View = System.Windows.Forms.View.Details;
            this.ListViewParts.SelectedIndexChanged += new System.EventHandler(this.ListViewParts_SelectedIndexChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.ListViewParts);
            this.Controls.Add(this.ButtonAddPart);
            this.Controls.Add(this.TextBoxPartQuantity);
            this.Controls.Add(this.TextBoxPart);
            this.Controls.Add(this.ButtonReturn);
            this.Controls.Add(this.LabelTitle);
            this.Menu = this.mainMenu1;
            this.Name = "Form3";
            this.Text = "Machine Maintenance";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.Button ButtonReturn;
        private System.Windows.Forms.TextBox TextBoxPart;
        private System.Windows.Forms.TextBox TextBoxPartQuantity;
        private System.Windows.Forms.Button ButtonAddPart;
        private System.Windows.Forms.ListView ListViewParts;
    }
}