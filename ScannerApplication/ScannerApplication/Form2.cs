using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ScannerApplication
{
    public partial class Form2 : Form
    {
        #region Page Open

        public Form2()
        {
            InitializeComponent();

            FitElementsToScreen();
            SetDisplayData();
        }

        private void FitElementsToScreen()
        {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int inputSeparation = 15;
            int sideSeparation = (int)(screenWidth * 0.1 / 3);

            if (!this.WindowState.Equals(FormWindowState.Maximized))
                this.WindowState = FormWindowState.Maximized;

            // Title
            LabelTitle.Width = screenWidth;
            LabelTitle.Location = new Point(0, 10);

            // Machine
            LabelMachine.Width = (int)(screenWidth * 0.45);
            LabelMachineValue.Width = (int)(screenWidth * 0.45);

            LabelMachine.Location = new Point(sideSeparation,
                LabelTitle.Location.Y + LabelTitle.Height + inputSeparation);
            LabelMachineValue.Location = new Point(sideSeparation * 2 + LabelMachine.Location.X + LabelMachine.Width,
                LabelTitle.Location.Y + LabelTitle.Height + inputSeparation);

            // Work Order
            LabelWorkOrder.Width = (int)(screenWidth * 0.45);
            LabelWorkOrderValue.Width = (int)(screenWidth * 0.45);

            LabelWorkOrder.Location = new Point(sideSeparation,
                LabelMachine.Location.Y + LabelMachine.Height + inputSeparation);
            LabelWorkOrderValue.Location = new Point(sideSeparation * 2 + LabelWorkOrder.Location.X + LabelWorkOrder.Width,
                LabelMachine.Location.Y + LabelMachine.Height + inputSeparation);

            // Employee
            LabelEmployee.Width = (int)(screenWidth * 0.45);
            LabelEmployeeValue.Width = (int)(screenWidth * 0.45);

            LabelEmployee.Location = new Point(sideSeparation,
                LabelWorkOrder.Location.Y + LabelWorkOrder.Height + inputSeparation);
            LabelEmployeeValue.Location = new Point(sideSeparation * 2 + LabelEmployee.Location.X + LabelEmployee.Width,
                LabelWorkOrder.Location.Y + LabelWorkOrder.Height + inputSeparation);

            // Scan In Date
            LabelScanIn.Width = (int)(screenWidth * 0.45);
            LabelScanInValue.Width = (int)(screenWidth * 0.45);

            LabelScanIn.Location = new Point(sideSeparation,
                LabelEmployee.Location.Y + LabelEmployee.Height + inputSeparation);
            LabelScanInValue.Location = new Point(sideSeparation * 2 + LabelScanIn.Location.X + LabelScanIn.Width,
                LabelEmployee.Location.Y + LabelEmployee.Height + inputSeparation);

            // Buttons
            int separation = (screenWidth - ButtonScanOut.Width - ButtonParts.Width) / 3;
            ButtonParts.Location = new Point(separation,
                LabelScanIn.Location.Y + LabelScanIn.Height + inputSeparation);
            ButtonScanOut.Location = new Point(separation * 2 + ButtonParts.Width,
                LabelScanIn.Location.Y + LabelScanIn.Height + inputSeparation);
        }

        private void SetDisplayData()
        {
            LabelMachineValue.Text = ScannerData.machine;
            LabelWorkOrderValue.Text = ScannerData.workOrder;
            LabelEmployeeValue.Text = ScannerData.employee;

            try
            {
                DateTime date = DateTime.Parse(ScannerData.scanInDt);
                LabelScanInValue.Text = date.ToString("HH:mm");
            } catch (Exception e)
            {
                System.Diagnostics.Debug.Write("Error converting date (" + ScannerData.scanInDt + "):\n\t" + e.Message);
                LabelScanInValue.Text = ScannerData.scanInDt;
            }
        }

        #endregion

        #region Methods

        private bool ScanOut()
        {
            XmlDocument partsXml = new XmlDocument();
            XmlElement parent = (XmlElement)partsXml.AppendChild(partsXml.CreateElement("machineMaintParts"));

            foreach (string part in ScannerData.parts.Keys)
            {
                XmlElement partElement = (XmlElement)parent.AppendChild(partsXml.CreateElement("machineMaintPart"));
                partElement.SetAttribute("part", part);
                partElement.SetAttribute("quantity", ScannerData.parts[part].ToString());
            }

            string requestData = "action=scan_out";
            requestData += "&machineMaintId=" + ScannerData.id;
            requestData += "&partsXml=" + partsXml.InnerXml;

            try
            {
                Status status = WebApiRequest.ApiPostRequest(requestData);

                if (status.errorNumber != 0)
                {
                    System.Diagnostics.Debug.Write("API Error: " + status.errorNumber + " - \n\t" + status.errorMessage + "\n");
                    MessageBox.Show(status.errorMessage, "Error scanning out of equipment");
                    return false;
                }

                //MessageBox.Show("Successfully scanned out of equipment");
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write("API Exception: " + e.Message + "\n");
                MessageBox.Show(e.Message, "Exception scanning out of equipment");
                return false;
            }
        }

        private void ClearScannerData()
        {
            ScannerData.id = -1;
            ScannerData.machine = "";
            ScannerData.workOrder = "";
            ScannerData.employee = "";
            ScannerData.scanInDt = "";
            ScannerData.scanOutDt = "";
            ScannerData.parts = null;
        }

        private void RedirectForm1()
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

        private void RedirectForm3()
        {
            Form3 form3 = new Form3();
            form3.Show();
            Hide();
        }

        #endregion

        #region Events

        private void ButtonParts_Click(object sender, EventArgs e)
        {
            RedirectForm3();
        }

        private void ButtonScanOut_Click(object sender, EventArgs e)
        {
            if (!ScanOut()) return;

            ClearScannerData();
            RedirectForm1();
        }

        #endregion

    }
}