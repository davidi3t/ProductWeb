using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Web.Api
{
    public class Product
    {

        private int productId;
        private string name;
        private string productNumber;
        private decimal listPrice;
        private string color;
        private string size;
        private List<ProductCost> productHistory = new List<ProductCost>();

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ProductNumber
        {
            get { return productNumber; }
            set { productNumber = value; }
        }

        public decimal ListPrice
        {
            get { return listPrice; }
            set { listPrice = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Size
        {
            get { return size; }
            set { size = value; }
        }

        public List<ProductCost> ProductHistory
        {
            get { return productHistory; }
            set { productHistory = value; }
        }

    }
}
