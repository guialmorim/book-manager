using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace book_manager.ViewModels
{
    public class PaginationParameters
    {
        public PaginationParameters(NameValueCollection data)
        {
            string sortKey = data.AllKeys.Where(k => k.StartsWith("sort")).First();
            string ordination = data[sortKey];
            string selectedField = sortKey.Replace("sort[", string.Empty).Replace("]", string.Empty);

            OrderedField = String.Format("{0} {1}", selectedField, ordination);
            Current = int.Parse(data["current"]);
            RowCount = int.Parse(data["rowCount"]);
            SearchPhrase = data["searchPhrase"];
            Id = int.Parse(data["id"]);
        }

        public int Current { get; set; }
        public int RowCount { get; set; }
        public string SearchPhrase { get; set; }
        public int Id { get; set; }
        public string OrderedField { get; set; }
    }
}