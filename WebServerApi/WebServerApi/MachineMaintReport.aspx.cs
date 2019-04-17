using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using Dapper;

namespace WebServerApi
{
    public partial class MachineMaintReport : Page
    {
        private readonly string connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];

        #region Page Open

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewMachineMaint.DataSource = null;
                GridViewMachineMaint.DataBind();
                GridViewMachineMaintParts.DataSource = null;
                GridViewMachineMaintParts.DataBind();

                return;
            };

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //GridViewMachineMaint.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion

        #region Events

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            SelectMaintenance();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            SelectMaintenance();
            ClearParts();
        }

        protected void GridViewMachineMaint_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var dataKey = GridViewMachineMaint.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())];

            SelectParts(dataKey.Value.ToString());
        }

        #endregion

        #region Methods

        private void SelectMaintenance()
        {
            try
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.OpenAsync();
                    var dynamicParameters = new DynamicParameters();

                    dynamicParameters.Add("work_order", TextBoxWorkOrder.Text, DbType.String, ParameterDirection.Input);
                    dynamicParameters.Add("machine", TextBoxMachine.Text, DbType.String, ParameterDirection.Input);
                    dynamicParameters.Add("employee", TextBoxEmployee.Text, DbType.String, ParameterDirection.Input);
                    dynamicParameters.Add("num_rows", 20, DbType.Int32, ParameterDirection.Input);

                    IEnumerable<ScannerData> result = sqlConnection.Query<ScannerData>(
                        "sp_machine_maint_select",
                        dynamicParameters,
                        commandType: CommandType.StoredProcedure);

                    GridViewMachineMaint.DataSource = result;
                    GridViewMachineMaint.DataBind();
                }
            } catch (Exception e)
            {
                SetErrorMessage("Error: " + e.Message);
            }
        }

        private void SelectParts(string machineMaintId)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.OpenAsync();
                    var dynamicParameters = new DynamicParameters();

                    dynamicParameters.Add("machine_maint_id", machineMaintId, DbType.String, ParameterDirection.Input);

                    IEnumerable<ScannerData> result = sqlConnection.Query<ScannerData>(
                        "sp_machine_maint_parts_select",
                        dynamicParameters,
                        commandType: CommandType.StoredProcedure);

                    GridViewMachineMaintParts.DataSource = result;
                    GridViewMachineMaintParts.DataBind();
                }
            }
            catch (Exception e)
            {
                SetErrorMessage("Error: " + e.Message);
            }
        }

        private void ClearParts()
        {
            GridViewMachineMaintParts.DataSource = null;
            GridViewMachineMaintParts.DataBind();

            ClearErrorMessage();
        }

        private void ClearFields()
        {
            TextBoxMachine.Text = "";
            TextBoxWorkOrder.Text = "";
            TextBoxEmployee.Text = "";

            ClearErrorMessage();
        }

        private void SetErrorMessage(string msg)
        {
            TextBoxError.Text = msg;
            TextBoxError.Visible = true;
        }

        private void ClearErrorMessage()
        {
            TextBoxError.Text = "";
            TextBoxError.Visible = false;
        }

        #endregion
    }
}