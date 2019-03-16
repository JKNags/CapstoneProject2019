namespace ScannerApplication
{
    partial class Form2
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
            this.ButtonScanOut = new System.Windows.Forms.Button();
            this.LabelMachine = new System.Windows.Forms.Label();
            this.LabelMachineValue = new System.Windows.Forms.Label();
            this.LabelWorkOrder = new System.Windows.Forms.Label();
            this.LabelWorkOrderValue = new System.Windows.Forms.Label();
            this.LabelEmployee = new System.Windows.Forms.Label();
            this.LabelEmployeeValue = new System.Windows.Forms.Label();
            this.LabelScanIn = new System.Windows.Forms.Label();
            this.LabelScanInValue = new System.Windows.Forms.Label();
            this.ButtonParts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelTitle
            // 
            this.LabelTitle.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.LabelTitle.Location = new System.Drawing.Point(131, 9);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(273, 27);
            this.LabelTitle.Text = "Successfully Scanned In";
            this.LabelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ButtonScanOut
            // 
            this.ButtonScanOut.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ButtonScanOut.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.ButtonScanOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ButtonScanOut.Location = new System.Drawing.Point(287, 262);
            this.ButtonScanOut.Name = "ButtonScanOut";
            this.ButtonScanOut.Size = new System.Drawing.Size(100, 37);
            this.ButtonScanOut.TabIndex = 13;
            this.ButtonScanOut.Text = "Scan Out";
            this.ButtonScanOut.Click += new System.EventHandler(this.ButtonScanOut_Click);
            // 
            // LabelMachine
            // 
            this.LabelMachine.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.LabelMachine.Location = new System.Drawing.Point(179, 67);
            this.LabelMachine.Name = "LabelMachine";
            this.LabelMachine.Size = new System.Drawing.Size(100, 20);
            this.LabelMachine.Text = "Equipment:";
            // 
            // LabelMachineValue
            // 
            this.LabelMachineValue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.LabelMachineValue.Location = new System.Drawing.Point(304, 67);
            this.LabelMachineValue.Name = "LabelMachineValue";
            this.LabelMachineValue.Size = new System.Drawing.Size(100, 20);
            this.LabelMachineValue.Text = "label2";
            // 
            // LabelWorkOrder
            // 
            this.LabelWorkOrder.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.LabelWorkOrder.Location = new System.Drawing.Point(179, 106);
            this.LabelWorkOrder.Name = "LabelWorkOrder";
            this.LabelWorkOrder.Size = new System.Drawing.Size(100, 20);
            this.LabelWorkOrder.Text = "Work Order:";
            // 
            // LabelWorkOrderValue
            // 
            this.LabelWorkOrderValue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.LabelWorkOrderValue.Location = new System.Drawing.Point(304, 106);
            this.LabelWorkOrderValue.Name = "LabelWorkOrderValue";
            this.LabelWorkOrderValue.Size = new System.Drawing.Size(100, 20);
            this.LabelWorkOrderValue.Text = "label4";
            // 
            // LabelEmployee
            // 
            this.LabelEmployee.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.LabelEmployee.Location = new System.Drawing.Point(179, 149);
            this.LabelEmployee.Name = "LabelEmployee";
            this.LabelEmployee.Size = new System.Drawing.Size(100, 20);
            this.LabelEmployee.Text = "Employee:";
            // 
            // LabelEmployeeValue
            // 
            this.LabelEmployeeValue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.LabelEmployeeValue.Location = new System.Drawing.Point(304, 149);
            this.LabelEmployeeValue.Name = "LabelEmployeeValue";
            this.LabelEmployeeValue.Size = new System.Drawing.Size(100, 20);
            this.LabelEmployeeValue.Text = "label6";
            // 
            // LabelScanIn
            // 
            this.LabelScanIn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.LabelScanIn.Location = new System.Drawing.Point(179, 193);
            this.LabelScanIn.Name = "LabelScanIn";
            this.LabelScanIn.Size = new System.Drawing.Size(100, 20);
            this.LabelScanIn.Text = "Scan In:";
            // 
            // LabelScanInValue
            // 
            this.LabelScanInValue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.LabelScanInValue.Location = new System.Drawing.Point(304, 193);
            this.LabelScanInValue.Name = "LabelScanInValue";
            this.LabelScanInValue.Size = new System.Drawing.Size(100, 20);
            this.LabelScanInValue.Text = "label8";
            // 
            // ButtonParts
            // 
            this.ButtonParts.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ButtonParts.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.ButtonParts.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ButtonParts.Location = new System.Drawing.Point(169, 262);
            this.ButtonParts.Name = "ButtonParts";
            this.ButtonParts.Size = new System.Drawing.Size(100, 37);
            this.ButtonParts.TabIndex = 30;
            this.ButtonParts.Text = "Parts";
            this.ButtonParts.Click += new System.EventHandler(this.ButtonParts_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.ButtonParts);
            this.Controls.Add(this.LabelScanInValue);
            this.Controls.Add(this.LabelScanIn);
            this.Controls.Add(this.LabelEmployeeValue);
            this.Controls.Add(this.LabelEmployee);
            this.Controls.Add(this.LabelWorkOrderValue);
            this.Controls.Add(this.LabelWorkOrder);
            this.Controls.Add(this.LabelMachineValue);
            this.Controls.Add(this.LabelMachine);
            this.Controls.Add(this.ButtonScanOut);
            this.Controls.Add(this.LabelTitle);
            this.Menu = this.mainMenu1;
            this.Name = "Form2";
            this.Text = "Machine Maintenance";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.Button ButtonScanOut;
        private System.Windows.Forms.Label LabelMachine;
        private System.Windows.Forms.Label LabelMachineValue;
        private System.Windows.Forms.Label LabelWorkOrder;
        private System.Windows.Forms.Label LabelWorkOrderValue;
        private System.Windows.Forms.Label LabelEmployee;
        private System.Windows.Forms.Label LabelEmployeeValue;
        private System.Windows.Forms.Label LabelScanIn;
        private System.Windows.Forms.Label LabelScanInValue;
        private System.Windows.Forms.Button ButtonParts;
    }
}