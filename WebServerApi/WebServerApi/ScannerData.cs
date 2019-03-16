using System;

namespace WebServerApi
{
    public class ScannerData
    {
        public string action { get; set; }
        public long machineMaintId { get; set; }
        public string machine { get; set; }
        public string workOrder { get; set; }
        public string employee { get; set; }
        public DateTime scanInDt { get; set; }
        public string scanInDtFormatted { get; set; }
        public DateTime scanOutDt { get; set; }
        public string scanOutDtFormatted { get; set; }

        public long machineMaintPartId { get; set; }
        public string part { get; set; }
        public int quantity { get; set; }
        public string duration { get; set; }

        public string partsXml { get; set; }
    }
}