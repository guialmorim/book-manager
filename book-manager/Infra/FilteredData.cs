using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book_manager.Infra
{
    public class FilteredData
    {
        public int current { get; set; }
        public int rowCount { get; set; }
        public int total { get; set; }
        public dynamic rows { get; set; }
    }
}