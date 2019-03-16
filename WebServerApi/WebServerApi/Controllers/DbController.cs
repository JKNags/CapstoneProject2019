using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using Dapper;

namespace WebApplication3.Controllers
{
    public class DbController : ApiController
    {
        private readonly string connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];

        [HttpGet]
        public string Get()
        {
            return "Please use a POST request to interact with Database.";
        }

        [HttpPost]
        public async Task<string> Post(WebServerApi.ScannerData data)
        {
            XmlDocument xml = new XmlDocument();
            XmlElement parent = (XmlElement)xml.AppendChild(xml.CreateElement("output"));
            XmlElement statusElement = (XmlElement)parent.AppendChild(xml.CreateElement("status"));
            XmlElement dataElement = (XmlElement)parent.AppendChild(xml.CreateElement("data"));

            try
            {
                int errorNumber = 0;
                string errorMessage = "";

                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    await sqlConnection.OpenAsync();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("error_number", errorNumber, DbType.Int32, ParameterDirection.InputOutput);
                    dynamicParameters.Add("error_message", errorMessage, DbType.String, ParameterDirection.InputOutput);

                    // Choose which sp to execute
                    switch (data.action)
                    {
                        case "scan_in":
                            // Scan In
                            dynamicParameters.Add("id", 0, DbType.Int64, ParameterDirection.InputOutput);
                            dynamicParameters.Add("work_order", data.workOrder, DbType.String, ParameterDirection.Input);
                            dynamicParameters.Add("machine", data.machine, DbType.String, ParameterDirection.Input);
                            dynamicParameters.Add("employee", data.employee, DbType.String, ParameterDirection.Input);
                            dynamicParameters.Add("scan_in_dt", "", DbType.String, ParameterDirection.InputOutput);

                            await sqlConnection.ExecuteAsync(
                                "sp_machine_maint_scan_in",
                                dynamicParameters,
                                commandType: CommandType.StoredProcedure);

                            // Set Status
                            data.machineMaintId = dynamicParameters.Get<dynamic>("id");
                            errorNumber = dynamicParameters.Get<dynamic>("error_number");
                            errorMessage = dynamicParameters.Get<dynamic>("error_message");

                            // Set Machine Maint Data
                            XmlElement row = (XmlElement)dataElement.AppendChild(xml.CreateElement("machineMaint"));
                            row.SetAttribute("id", data.machineMaintId.ToString());
                            row.SetAttribute("machine", data.machine);
                            row.SetAttribute("workOrder", data.workOrder);
                            row.SetAttribute("employee", data.employee);
                            row.SetAttribute("scanInDt", dynamicParameters.Get<dynamic>("scan_in_dt"));
                            row.SetAttribute("scanOutDt", "");

                            // Select Parts
                            /*var selectDynamicParameters = new DynamicParameters();
                            selectDynamicParameters.Add("machine_maint_id", data.machineMaintId, DbType.String, ParameterDirection.Input);

                            IEnumerable<WebServerApi.ScannerData> result;
                            IEnumerator<WebServerApi.ScannerData> resultEnum;

                            result = await sqlConnection.QueryAsync<ScannerData>(
                                "sp_machine_maint_parts_select",
                                selectDynamicParameters,
                                commandType: CommandType.StoredProcedure);

                            resultEnum = result.GetEnumerator();

                            // Set Machine Maint Parts Data
                            XmlElement parts = (XmlElement)dataElement.AppendChild(xml.CreateElement("machineMaintParts"));
                            while (resultEnum.MoveNext())
                            {
                                XmlElement partRow = (XmlElement)parts.AppendChild(xml.CreateElement("machineMaintPart"));
                                partRow.SetAttribute("machineMaintId", resultEnum.Current.machineMaintId.ToString());
                                partRow.SetAttribute("machineMaintPartId", resultEnum.Current.machineMaintPartId.ToString());
                                partRow.SetAttribute("part", resultEnum.Current.part);
                                partRow.SetAttribute("quantity", resultEnum.Current.quantity.ToString());
                            }*/

                            break;

                        case "scan_out":
                            dynamicParameters.Add("id", data.machineMaintId, DbType.String, ParameterDirection.Input);
                            dynamicParameters.Add("parts_xml", data.partsXml, DbType.String, ParameterDirection.Input);

                            await sqlConnection.ExecuteAsync(
                                "sp_machine_maint_scan_out",
                                dynamicParameters,
                                commandType: CommandType.StoredProcedure);

                            errorNumber = dynamicParameters.Get<dynamic>("error_number");
                            errorMessage = dynamicParameters.Get<dynamic>("error_message");

                            break;

                        default:
                            errorNumber = 1;
                            errorMessage = "Stored Procedure not set up in the Web API.";

                            break;
                    }
                }

                // Set Status
                statusElement.SetAttribute("errorNumber", errorNumber.ToString());
                statusElement.SetAttribute("errorMessage", errorMessage);
            }
            catch (Exception e)
            {
                // Set Status
                statusElement.SetAttribute("errorNumber", e.Message);
                statusElement.SetAttribute("errorMessage", e.StackTrace);
            }

            return xml.InnerXml;
        }

    }
}
