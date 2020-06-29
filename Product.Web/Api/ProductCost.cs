using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Web.Api
{
    public class ProductCost
    {

        private decimal standardCost;
        private DateTime? startDate;
        private DateTime? endDate;

        public decimal StandardCost
        {
            get { return standardCost; }
            set { standardCost = value; }
        }

        public DateTime? StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime? EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

    }
}
