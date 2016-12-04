using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public abstract class Products
    {
        /// <summary>
        /// The name of the product
        /// </summary>
        public string Name { get; protected set; }

        public decimal Price { get; protected set; }
    }

    public class Cola : Products
    {
        public Cola()
        {
            Name = "Cola";
            Price = 1.00M;
        }
    }

    public class Chips : Products
    {
        public Chips()
        {
            Name = "Chips";
            Price = .50M;
        }
    }

    public class Candy : Products
    {
        public Candy()
        {
            Name = "Candy";
            Price = .65M;
        }
    }
}
