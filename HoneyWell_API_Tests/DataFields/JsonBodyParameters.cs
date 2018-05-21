using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyWellAPITests.DataFields
{
    class JsonBodyParameters
    {
        public string dealerName { get; set; }
        public string dealerId { get; set; }
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
    }
}
