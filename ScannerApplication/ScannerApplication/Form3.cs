using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ScannerApplication
{
    public partial class Form3 : Form
    {
        #region Page Open

        public Form3()
        {
            InitializeComponent();
            
            FitElementsToScreen();
            BindListViewParts();
            DefaultInputs();
        }

        private void DefaultInputs()
        {
            TextBoxPartQuantity.Text = "1";

            TextBoxPart.Focus();
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

            // Parts View
            ListViewParts.Width = (int)(screenWidth * 0.9);
            ListViewParts.Height = (int)(screenHeight * 0.5);
            ListViewParts.Location = new Point(screenWidth / 2 - ListViewParts.Width / 2,
                LabelTitle.Location.Y + LabelTitle.Height + labelTextBoxSeparation);

            ListViewParts.Columns.Add("Part", (int)(ListViewParts.Width * 0.75 - 1), HorizontalAlignment.Center);
            ListViewParts.Columns.Add("Qty", (int)(ListViewParts.Width * 0.20), HorizontalAlignment.Left);

            // Parts Input
            TextBoxPart.Width = (int)(screenWidth * 0.7);
            TextBoxPartQuantity.Width = (int)(screenWidth * 0.2);

            TextBoxPart.Location = new Point(ListViewParts.Location.X,
                ListViewParts.Location.Y + ListViewParts.Height + labelTextBoxSeparation);
            TextBoxPartQuantity.Location = new Point(ListViewParts.Location.X + ListViewParts.Width - TextBoxPartQuantity.Width,
                ListViewParts.Location.Y + ListViewParts.Height + labelTextBoxSeparation);

            // Buttons
            int separation = (screenWidth - ButtonReturn.Width - ButtonAddPart.Width) / 3;
            ButtonAddPart.Location = new Point(separation,
                TextBoxPart.Location.Y + TextBoxPart.Height + inputSeparation);
            ButtonReturn.Location = new Point(separation * 2 + ButtonReturn.Width,
                TextBoxPart.Location.Y + TextBoxPart.Height + inputSeparation);
        }

        #endregion

        #region Methods

        private void RedirectForm2()
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void SelectPart()
        {
            try
            {
                ListViewItem item = ListViewParts.FocusedItem;
                if (item == null) return;

                if (item.SubItems.Count != 2) return;

                TextBoxPart.Text = item.SubItems[0].Text;
                //TextBoxPartQuantity.Text = item.SubItems[1].Text;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error selecting part");
            }
        }

        private bool AddPart()
        {
            // Validate input
            if (string.IsNullOrEmpty(TextBoxPart.Text)
                || string.IsNullOrEmpty(TextBoxPartQuantity.Text))
            {
                MessageBox.Show("Part ID and Quantity are required.", "Input Error");
                return false;
            }

            string newPart;
            int newPartQuantity;
            Dictionary<string, int> newParts = ScannerData.parts;

            try
            {
                newPart = TextBoxPart.Text;
                newPartQuantity = int.Parse(TextBoxPartQuantity.Text);
            } catch (Exception e)
            {
                System.Diagnostics.Debug.Write("Error parsing part input:\n\t" + e.Message);
                MessageBox.Show("Part quantity must be numeric.", "Input Error");
                return false;
            }

            // Add new part to existing
            foreach (string part in ScannerData.parts.Keys)
            {
                if (part.Equals(newPart))
                {
                    // Remove part if input quantity is 0 or addition will result in 0
                    if (newPartQuantity == 0 || newParts[part] + newPartQuantity <= 0)
                        newParts.Remove(part);
                    else
                        ScannerData.parts[part] += newPartQuantity;
                    ScannerData.parts = newParts;
                    return true;
                }
            }

            if (newPartQuantity < 0)
            {
                System.Diagnostics.Debug.Write("New part quantity must be greater than 0.\n");
                MessageBox.Show("New part quantity must be greater than 0.", "Input Error");
                return false;
            }

            // Add new part
            newParts.Add(newPart, newPartQuantity);

            ScannerData.parts = newParts;
            return true;
        }

        private void BindListViewParts()
        {
            ListViewParts.Items.Clear();
            foreach (var part in ScannerData.parts.Keys)
            {
                ListViewParts.Items.Add(new ListViewItem(new[] { part, ScannerData.parts[part].ToString() }));
            }
        }

        private void ClearFields()
        {
            TextBoxPart.Text = "";
            TextBoxPartQuantity.Text = "";
        }

        #endregion

        #region Events

        private void ListViewParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectPart();
        }

        private void ButtonReturn_Click(object sender, EventArgs e)
        {
            RedirectForm2();
        }

        private void ButtonAddPart_Click(object sender, EventArgs e)
        {
            if(!AddPart()) return;

            BindListViewParts();
            ClearFields();
            DefaultInputs();
        }

        #endregion
    }
}