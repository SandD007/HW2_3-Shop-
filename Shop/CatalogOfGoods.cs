using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public static class CatalogOfGoods
    {
        private static Goods[] catalogOfGoods = new Goods[]
        {
            new Goods(ProductCategory.Pens, "Blue pen", 1.25m),
            new Goods(ProductCategory.Pens, "Red pen", 1.25m),
            new Goods(ProductCategory.Pens, "Black pen", 1.25m),
            new Goods(ProductCategory.Pens, "Golden pen", 700m),
            new Goods(ProductCategory.Pencils, "Black Pencils", 0.15m),
            new Goods(ProductCategory.Pencils, "A set of multi-colored pencils", 7.25m),
            new Goods(ProductCategory.Notebooks, "Notebook in a cell", 4.50m),
            new Goods(ProductCategory.Notebooks, "Notebook in an oblique line", 4.50m),
            new Goods(ProductCategory.Notebooks, "Notebook in a cell on 48 pages", 9m),
            new Goods(ProductCategory.Notebooks, "Notebook in oblique line on 48 pages", 9m),
            new Goods(ProductCategory.Textbooks, "Biology textbook", 130m),
            new Goods(ProductCategory.Textbooks, "Textbook on mathematics", 130m),
            new Goods(ProductCategory.Textbooks, "Textbook on chemistry", 120m),
            new Goods(ProductCategory.Textbooks, "Textbook on geography", 120m),
        };

        public static Goods[] ViewCatalog()
        {
            Goods[] catalog = catalogOfGoods;
            return catalog;
        }

        public static Goods[] ProductCatalog(ProductCategory category)
        {
            int index = 0;

            for (int i = 0; i < catalogOfGoods.Length; i++)
            {
                if (catalogOfGoods[i].GoodsCategory() == category)
                {
                    index++;
                }
            }

            Goods[] productByCategory = new Goods[index];
            index = 0;

            for (int i = 0; i < catalogOfGoods.Length; i++)
            {
                if (catalogOfGoods[i].GoodsCategory() == category)
                {
                    productByCategory[index] = catalogOfGoods[i];
                    index++;
                }
            }

            return productByCategory;
        }
    }
}
