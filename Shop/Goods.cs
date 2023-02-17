using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public enum ProductCategory
    {
        Pens,
        Notebooks,
        Textbooks,
        Pencils,
    }

    public class Goods
    {
        private decimal price;

        public Goods(ProductCategory category, string name, decimal price)
        {
            this.Name = name;
            this.price = price;
            this.Category = category;
        }

        private ProductCategory Category { get; set; }

        private string Name { get; set; }

        private decimal Price
        {
            get => this.price;
            set
            {
                if (value < 0)
                {
                    this.price = 0;
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public string GoodsName()
        {
            return this.Name;
        }

        public decimal GoodsPrice()
        {
            return this.Price;
        }

        public ProductCategory GoodsCategory()
        {
            return this.Category;
        }
    }
}
