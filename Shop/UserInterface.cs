using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public static class UserInterface
    {
        public static void Start()
        {
            CatalogOfGoods.ProductCatalog(ProductCategory.Textbooks);
            Goods[] goods = CatalogOfGoods.ViewCatalog();
            Console.WriteLine("Welcome to the 'abracadabra store', select the product category that interests you, or press 'Q' for quit.");
            Console.WriteLine();
            Actions.CategorySelection();
            Console.ReadKey();
        }
    }
}
