using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ScannerApplication
{
    public class ScannerData
    {
        public static long id { get; set; }
        public static string machine { get; set; }
        public static string workOrder { get; set; }
        public static string employee { get; set; }
        public static string scanInDt { get; set; }
        public static string scanOutDt { get; set; }

        private static Dictionary<string, int> partsDict;
        public static Dictionary<string, int> parts
        {   get 
            {
                if (partsDict == null) 
                    return new Dictionary<string,int>();
                else
                    return partsDict;
            }
            set
            {
                partsDict = value;
            }
        }
    }
}
