using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hometheaterbuilderv2.Model
{
    public class TelevisionsNavigation
    {
        public string Description { get; set; }
        public int CategoryType { get; set; }
        public int CategoryID { get; set; }
        public int StoreID { get; set; }
        public int NodeId { get; set; }
        public bool ShowSeeAllDeals { get; set; }
    }
}