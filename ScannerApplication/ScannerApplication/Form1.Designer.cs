namespace ScannerApplication
{
    partial class Form1
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
            this.TextBoxMachine = new System.Windows.Forms.TextBox();
            this.ButtonScanIn = new System.Windows.Forms.Button();
            this.LabelTitle = new System.Windows.Forms.Label();
            this.LabelMachine = new System.Windows.Forms.Label();
            this.TextBoxWorkOrder = new System.Windows.Forms.TextBox();
            this.LabelWorkOrder = new System.Windows.Forms.Label();
            this.TextBoxEmployee = new System.Windows.Forms.TextBox();
            this.LabelEmployee = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxMachine
            // 
            this.TextBoxMachine.Location = new System.Drawing.Point(162, 51);
            this.TextBoxMachine.Name = "TextBoxMachine";
            this.TextBoxMachine.Size = new System.Drawing.Size(26, 23);
            this.TextBoxMachine.TabIndex = 1;
            // 
            // ButtonScanIn
            // 
            this.ButtonScanIn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ButtonScanIn.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.ButtonScanIn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ButtonScanIn.Location = new System.Drawing.Point(62, 203);
            this.ButtonScanIn.Name = "ButtonScanIn";
            this.ButtonScanIn.Size = new System.Drawing.Size(100, 37);
            this.ButtonScanIn.TabIndex = 0;
            this.ButtonScanIn.Text = "Scan In";
            this.ButtonScanIn.Click += new System.EventHandler(this.ButtonScanIn_Click);
            // 
            // LabelTitle
            // 
            this.LabelTitle.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.LabelTitle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LabelTitle.Location = new System.Drawing.Point(52, 14);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(189, 27);
            this.LabelTitle.Text = "Machine Maintenance";
            this.LabelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LabelMachine
            // 
            this.LabelMachine.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.LabelMachine.Location = new System.Drawing.Point(52, 51);
            this.LabelMachine.Name = "LabelMachine";
            this.LabelMachine.Size = new System.Drawing.Size(100, 20);
            this.LabelMachine.Text = "Equipment:";
            // 
            // TextBoxWorkOrder
            // 
            this.TextBoxWorkOrder.Location = new System.Drawing.Point(162, 100);
            this.TextBoxWorkOrder.Name = "TextBoxWorkOrder";
            this.TextBoxWorkOrder.Size = new System.Drawing.Size(26, 23);
            this.TextBoxWorkOrder.TabIndex = 3;
            // 
            // LabelWorkOrder
            // 
            this.LabelWorkOrder.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.LabelWorkOrder.Location = new System.Drawing.Point(52, 100);
            this.LabelWorkOrder.Name = "LabelWorkOrder";
            this.LabelWorkOrder.Size = new System.Drawing.Size(100, 20);
            this.LabelWorkOrder.Text = "Work Order:";
            // 
            // TextBoxEmployee
            // 
            this.TextBoxEmployee.Location = new System.Drawing.Point(162, 146);
            this.TextBoxEmployee.Name = "TextBoxEmployee";
            this.TextBoxEmployee.Size = new System.Drawing.Size(26, 23);
            this.TextBoxEmployee.TabIndex = 8;
            // 
            // LabelEmployee
            // 
            this.LabelEmployee.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.LabelEmployee.Location = new System.Drawing.Point(56, 149);
            this.LabelEmployee.Name = "LabelEmployee";
            this.LabelEmployee.Size = new System.Drawing.Size(100, 20);
            this.LabelEmployee.Text = "Employee:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.LabelEmployee);
            this.panel1.Controls.Add(this.TextBoxEmployee);
            this.panel1.Controls.Add(this.LabelWorkOrder);
            this.panel1.Controls.Add(this.TextBoxWorkOrder);
            this.panel1.Controls.Add(this.LabelMachine);
            this.panel1.Controls.Add(this.LabelTitle);
            this.panel1.Controls.Add(this.ButtonScanIn);
            this.panel1.Controls.Add(this.TextBoxMachine);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 275);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(324, 275);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Machine Maintenance";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxMachine;
        private System.Windows.Forms.Button ButtonScanIn;
        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.Label LabelMachine;
        private System.Windows.Forms.TextBox TextBoxWorkOrder;
        private System.Windows.Forms.Label LabelWorkOrder;
        private System.Windows.Forms.TextBox TextBoxEmployee;
        private System.Windows.Forms.Label LabelEmployee;
        private System.Windows.Forms.Panel panel1;


    }
}

