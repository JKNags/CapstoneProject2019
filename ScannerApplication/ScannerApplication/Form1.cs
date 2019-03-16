using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace ScannerApplication
{
    public partial class Form1 : Form
    {
        #region Page Open

        public Form1()
        {
            InitializeComponent();

            FitElementsToScreen();
            DefaultInputs();
        }

        private void DefaultInputs()
        {
            //TextBoxMachine.Text = "M005";
            //TextBoxWorkOrder.Text = "WO005";
            //TextBoxEmployee.Text = "E005";

            TextBoxMachine.Focus();
        }

        private void FitElementsToScreen()
        {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int labelTextBoxSeparation = 5;
            int inputSeparation = 15;

            if (!this.WindowState.Equals(FormWindowState.Maximized))
                this.WindowState = FormWindowState.Maximized;

            // Title
            LabelTitle.Width = screenWidth;
            LabelTitle.Location = new Point(0, 10);

            // Machine
            LabelMachine.Width = (int)(screenWidth * 0.9);
            LabelMachine.Location = new Point(screenWidth / 2 - LabelMachine.Width / 2,
                LabelTitle.Location.Y + LabelTitle.Height + inputSeparation);

            TextBoxMachine.Width = (int)(screenWidth * 0.9);
            TextBoxMachine.Location = new Point(screenWidth / 2 - TextBoxMachine.Width / 2,
                LabelMachine.Location.Y + LabelMachine.Height + labelTextBoxSeparation);

            // Work Order
            LabelWorkOrder.Width = (int)(screenWidth * 0.9);
            LabelWorkOrder.Location = new Point(screenWidth / 2 - LabelWorkOrder.Width / 2,
                TextBoxMachine.Location.Y + TextBoxMachine.Height + inputSeparation);

            TextBoxWorkOrder.Width = (int)(screenWidth * 0.9);
            TextBoxWorkOrder.Location = new Point(screenWidth / 2 - TextBoxWorkOrder.Width / 2,
                LabelWorkOrder.Location.Y + LabelWorkOrder.Height + labelTextBoxSeparation);

            // Employee
            LabelEmployee.Width = (int)(screenWidth * 0.9);
            LabelEmployee.Location = new Point(screenWidth / 2 - LabelEmployee.Width / 2,
                TextBoxWorkOrder.Location.Y + TextBoxWorkOrder.Height + inputSeparation);

            TextBoxEmployee.Width = (int)(screenWidth * 0.9);
            TextBoxEmployee.Location = new Point(screenWidth / 2 - TextBoxEmployee.Width / 2,
                LabelEmployee.Location.Y + LabelEmployee.Height + labelTextBoxSeparation);
            
            // Buttons
            int separation = (screenWidth - ButtonScanIn.Width) / 2;
            ButtonScanIn.Location = new Point(separation,
                TextBoxEmployee.Location.Y + TextBoxEmployee.Height + inputSeparation);

            //ButtonScanOut.Location = new Point(2 * separation + ButtonScanIn.Width,
            //    TextBoxEmployee.Location.Y + TextBoxEmployee.Height + inputSeparation);
        }

        #endregion

        #region Methods

        private bool ScanIn()
        {
            string requestData = "action=scan_in";
            requestData += "&machine=" + TextBoxMachine.Text;
            requestData += "&workOrder=" + TextBoxWorkOrder.Text;
            requestData += "&employee=" + TextBoxEmployee.Text;

            try
            {
                Status status = WebApiRequest.ApiPostRequest(requestData);

                if (status.errorNumber != 0)
                {
                    System.Diagnostics.Debug.Write("API Error: " + status.errorNumber + " - \n\t" + status.errorMessage + "\n");
                    MessageBox.Show(status.errorMessage, "Error scanning into equipment");
                    return false;
                }

                //MessageBox.Show("Successfully scanned into equipment");
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write("API Exception: " + e.Message + "\n");
                MessageBox.Show(e.Message, "Exception scanning into equipment");
                return false;
            }
        }

        /*private void GetPartsFromDb()
        {
            string requestData = "action=select_part";
            requestData += "&machine_maint_id=" + TextBoxMachine.Text;

            try
            {
                Status status = WebApiRequest.ApiPostRequest(requestData);

                if (status.errorNumber != 0)
                {
                    System.Diagnostics.Debug.Write("API Error: " + status.errorNumber + " - \n\t" + status.errorMessage + "\n");
                    MessageBox.Show(status.errorMessage, "Error getting parts");
                    return false;
                }

                //MessageBox.Show("Successfully scanned into equipment");
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write("API Exception: " + e.Message + "\n");
                MessageBox.Show(e.Message, "Exception scanning into equipment");
                return false;
            }
        }*/

        private void RedirectForm2()
        {
            Form2 form2 = new Form2();
            form2.Show();
            Hide();
        }

        #endregion

        #region Events

        private void ButtonScanIn_Click(object sender, EventArgs e)
        {
            if(!ScanIn()) return;

            //GetPartsFromDb();
            RedirectForm2();
        }

        #endregion
    }
}


