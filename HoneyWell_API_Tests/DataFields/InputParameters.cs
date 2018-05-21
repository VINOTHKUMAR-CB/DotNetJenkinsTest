using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyWellAPITests.DataFields
{
    public class InputParameters
    {
        public string type { get; set; }
        public string url { get; set; }
        public string dealerName { get; set; }
        public string dealerId { get; set; }
        public object parentDealerId { get; set; }
        public string locationId { get; set; }
        public string aliase { get; set; }
        public string contactPerson { get; set; }
        public string email { get; set; }
        public long contactNumber { get; set; }
        public string location { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public bool status { get; set; }
        public string partitionKey { get; set; }
        public string rowKey { get; set; }
        public DateTime timestamp { get; set; }
        public string eTag { get; set; }
        public int Expected_statuscode { get; set; }
    }
}
