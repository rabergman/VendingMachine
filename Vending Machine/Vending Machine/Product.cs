using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public abstract class Product
    {
        /// <summary>
        /// The name of the product
        /// </summary>
        public string Name { get; protected set; }

        public decimal Price { get; protected set; }
    }

    public class Cola : Product
    {
        public Cola()
        {
            this.Name = "Cola";
            this.Price = 1.00M;
        }
    }

    public class Chips : Product
    {
        public Chips()
        {
            this.Name = "Chips";
            this.Price = .50M;
        }
    }

    public class Candy : Product
    {
        public Candy()
        {
            this.Name = "Candy";
            this.Price = .65M;
        }
    }
}
