using System;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Net;
using System.IO;

namespace ScannerApplication
{
    class WebApiRequest
    {
        private const string ApiUrl = "http://192.168.0.11/DbApiv1/api/db";

        public static Status ApiPostRequest(string requestData)
        {
            Status status = new Status();

            try
            {
                // Request Data
                byte[] requestContent = Encoding.ASCII.GetBytes(requestData);

                // Generate Request
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ApiUrl);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = requestContent.Length;

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(requestContent, 0, requestContent.Length);
                }

                // Get Response and read stream
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader streamReader = new StreamReader(responseStream))
                        {
                            string responseContent = streamReader.ReadToEnd();

                            // Fix up content string
                            responseContent = responseContent.Substring(1, responseContent.Length - 2).Replace("\\", "");
                            System.Diagnostics.Debug.Write("Response content: " + responseContent + "\n");

                            // Load XML from content
                            XmlDocument xml = new XmlDocument();
                            xml.LoadXml(responseContent);
                            XmlNodeList parentElement = xml.GetElementsByTagName("output");
                            XmlNode children = parentElement.Item(0);

                            foreach (XmlNode node in children.ChildNodes)
                            {
                                // Status Node
                                if(node.Name.Equals("status"))
                                {
                                    // Set Status
                                    XmlAttributeCollection statusAttributes = node.Attributes;
                                    foreach (XmlAttribute a in statusAttributes)
                                    {
                                        if (a.Name.Equals("errorNumber")) status.errorNumber = int.Parse(a.Value);
                                        if (a.Name.Equals("errorMessage")) status.errorMessage = a.Value;
                                    }

                                    continue;
                                }

                                // Data Node
                                if (node.Name.Equals("data"))
                                {
                                    foreach (XmlNode dataNode in node.ChildNodes)
                                    {
                                        // Machine Maint Node
                                        if (dataNode.Name.Equals("machineMaint"))
                                        {
                                            // Set Machine Maint Data
                                            XmlAttributeCollection dataAttributes = dataNode.Attributes;
                                            foreach (XmlAttribute a in dataAttributes)
                                            {
                                                if (a.Name.Equals("id")) { ScannerData.id = int.Parse(a.Value); continue; }
                                                if (a.Name.Equals("machine")) { ScannerData.machine = a.Value; continue; }
                                                if (a.Name.Equals("workOrder")) { ScannerData.workOrder = a.Value; continue; }
                                                if (a.Name.Equals("employee")) { ScannerData.employee = a.Value; continue; }
                                                if (a.Name.Equals("scanInDt")) { ScannerData.scanInDt = a.Value; continue; }
                                                if (a.Name.Equals("scanOutDt")) { ScannerData.scanOutDt = a.Value; continue; }
                                            }

                                            continue;
                                        }

                                        // Part Node
                                        /*if (dataNode.Name.Equals("machineMaintParts"))
                                        {
                                            Dictionary<string, int> newParts = new Dictionary<string, int>();

                                            foreach (XmlNode partNode in dataNode.ChildNodes)
                                            {
                                                // Set Part Data
                                                XmlAttributeCollection partAttributes = partNode.Attributes;
                                                string newPart = "";
                                                int newQuantity = -1;

                                                foreach (XmlAttribute a in partAttributes)
                                                {
                                                    //if (a.Name.Equals("machineMaintId")) { ScannerData.id = int.Parse(a.Value); continue; }
                                                    //if (a.Name.Equals("machineMaintPartId")) { ScannerData.machine = a.Value; continue; }
                                                    if (a.Name.Equals("part"))
                                                    {
                                                        newPart = a.Value;
                                                    }
                                                    if (a.Name.Equals("quantity"))
                                                    {
                                                        newQuantity = int.Parse(a.Value);
                                                    }
                                                }

                                                newParts.Add(newPart, newQuantity);
                                            }

                                            ScannerData.parts = newParts;

                                            continue;
                                        }*/
                                    }

                                    continue;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                status.errorNumber = 1;
                status.errorMessage = e.Message;
            }

            return status;
        }
    }
}
