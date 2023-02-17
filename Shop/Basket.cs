using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Basket
    {
        public Basket(Goods[] product)
        {
            this.GoodsInBasket = product;
            this.Id = Guid.NewGuid();
        }

        private Goods[] GoodsInBasket { get; set; }

        private Guid Id { get; set; }

        public Goods[] MyBasket()
        {
            return this.GoodsInBasket;
        }

        public Guid MyId()
        {
            return this.Id;
        }
    }
}
