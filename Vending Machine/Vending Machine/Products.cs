using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    /// <summary>
    /// Parent class of all products
    /// </summary>
    public abstract class Products
    {
        /// <summary>
        /// The name of the product
        /// </summary>
        public string Name { get; protected set; }

        public decimal Price { get; protected set; }
    }

    /// <summary>
    /// The cola object
    /// </summary>
    public class Cola : Products
    {
        public Cola()
        {
            Name = "Cola";
            Price = 1.00M;
        }
    }

    /// <summary>
    /// The chips object
    /// </summary>
    public class Chips : Products
    {
        public Chips()
        {
            Name = "Chips";
            Price = .50M;
        }
    }

    /// <summary>
    /// The candy object
    /// </summary>
    public class Candy : Products
    {
        public Candy()
        {
            Name = "Candy";
            Price = .65M;
        }
    }
}
