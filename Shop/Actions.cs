using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public static class Actions
    {
        private static Goods[] productInBasket = new Goods[0];

        public static void CategorySelection()
        {
            Console.WriteLine("1 - " + ProductCategory.Notebooks);
            Console.WriteLine();
            Console.WriteLine("2 - " + ProductCategory.Pens);
            Console.WriteLine();
            Console.WriteLine("3 - " + ProductCategory.Pencils);
            Console.WriteLine();
            Console.WriteLine("4 - " + ProductCategory.Textbooks);

            var answer = Console.ReadKey();

            if (answer.KeyChar == '1')
            {
                Console.Clear();
                PrintProduct(CatalogOfGoods.ProductCatalog(ProductCategory.Notebooks));
                ProductSelection(CatalogOfGoods.ProductCatalog(ProductCategory.Notebooks));
            }
            else if (answer.KeyChar == '2')
            {
                Console.Clear();
                PrintProduct(CatalogOfGoods.ProductCatalog(ProductCategory.Pens));
                ProductSelection(CatalogOfGoods.ProductCatalog(ProductCategory.Pens));
            }
            else if (answer.KeyChar == '3')
            {
                Console.Clear();
                PrintProduct(CatalogOfGoods.ProductCatalog(ProductCategory.Pencils));
                ProductSelection(CatalogOfGoods.ProductCatalog(ProductCategory.Pencils));
            }
            else if (answer.KeyChar == '4')
            {
                Console.Clear();
                PrintProduct(CatalogOfGoods.ProductCatalog(ProductCategory.Textbooks));
                ProductSelection(CatalogOfGoods.ProductCatalog(ProductCategory.Textbooks));
            }
            else if (answer.KeyChar == 'Q' || answer.KeyChar == 'q')
            {
                return;
            }
            else if (answer.KeyChar == 'y' || answer.KeyChar == 'Y')
            {
                Basket basket = new Basket(productInBasket);
                Console.Clear();
                Console.WriteLine("Congratulations on your order number: " + basket.MyId());
                Console.WriteLine();
                PrintProduct(basket.MyBasket());
            }
            else if (answer.KeyChar == 'd' || answer.KeyChar == 'D')
            {
                productInBasket = new Goods[0];
                Console.Clear();
                Console.WriteLine("Your order deleted.");
                Console.WriteLine();
                CategorySelection();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter the section number you are interested in.");
                Console.WriteLine();
                CategorySelection();
            }
        }

        public static void PrintProduct(Goods[] product)
        {
            int index = 1;
            for (int i = 0; i < product.Length; i++)
            {
                Console.WriteLine(index + " - " + product[i].GoodsName() + ", price - " + product[i].GoodsPrice() + ".");
                Console.WriteLine();
                index++;
            }
        }

        public static void PrintProduct(Goods product)
        {
                Console.WriteLine("Your choice: " + product.GoodsName() + ", price - " + product.GoodsPrice() + ".");
                Console.WriteLine();
        }

        private static void ProductSelection(Goods[] product)
        {
            int countProductInCategory = product.Length;

            Console.WriteLine("To add a product to the basket, enter the corresponding product number.");
            Console.WriteLine();
            Console.WriteLine("To return to the previous menu, press 'R' or 'Q' for quit.");
            var answer = Console.ReadKey();
            Console.Clear();

            int answerInt = (answer.KeyChar - '0') - 1;

            if (answerInt < countProductInCategory)
            {
                PrintProduct(product[answerInt]);
                AddToBasket(product[answerInt], SetCountProduct(product[answerInt]));
                Console.WriteLine();
                CategorySelection();
            }
            else if (answer.KeyChar == 'r' || answer.KeyChar == 'R')
            {
                CategorySelection();
            }
            else if (answer.KeyChar == 'q' || answer.KeyChar == 'Q')
            {
                return;
            }
            else
            {
                Console.WriteLine("Please enter the section number you are interested in.");
                Console.WriteLine();
                PrintProduct(product);
                ProductSelection(product);
            }
        }

        private static int SetCountProduct(Goods produckt)
        {
            int result = 0;

            Console.WriteLine("Enter the quantity of the product you want to add to your cart and press 'Enter'.");
            if (!int.TryParse(Console.ReadLine(), out result))
            {
                return result;
            }
            else
            {
                int answer = Convert.ToInt32(result);
                return answer;
            }
        }

        private static void AddToBasket(Goods product, int count)
        {
            if (count <= 0)
            {
                Console.Clear();
                Console.WriteLine("Please, enter correct data.");
                Console.WriteLine();
                CategorySelection();
                return;
            }
            else
            {
                decimal price = product.GoodsPrice() * count;
                Goods addetProduct = new Goods(product.GoodsCategory(), product.GoodsName(), price);

                if (productInBasket.Length == 0)
                {
                    productInBasket = new Goods[1];
                    productInBasket[0] = addetProduct;
                    TheContentsOfTheShoppingCart();
                    return;
                }

                var newProductInBasket = new Goods[productInBasket.Length + 1];

                for (int i = 0; i < productInBasket.Length; i++)
                {
                    newProductInBasket[i] = productInBasket[i];
                }

                newProductInBasket[^1] = addetProduct;
                productInBasket = newProductInBasket;
                TheContentsOfTheShoppingCart();
            }
        }

        private static void TheContentsOfTheShoppingCart()
        {
            Console.Clear();
            Console.WriteLine("Your basket");
            Console.WriteLine("-------------------------------");
            PrintProduct(productInBasket);
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Press 'Y' to save the order or 'D' to delete the order.");
            Console.WriteLine();
        }
    }
}
