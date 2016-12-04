using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public abstract class Coin
    {
        /// <summary>
        /// The weight of the coin expressed in grams
        /// </summary>
        public decimal Weight { get; protected set; }

        /// <summary>
        /// The diameter of the coin expressed in millimeters
        /// </summary>
        public decimal Diameter { get; protected set; }

        /// <summary>
        /// The Thickness of the coin expressed in millimeters
        /// </summary>
        public decimal Thickness { get; protected set; }

        /// <summary>
        /// The value of the coin expressed in US dollars
        /// </summary>
        public decimal Value { get; protected set; }
    }

    public class Penny : Coin
    {
        public Penny()
        {
            Weight = 2.5M;
            Diameter = 19.05M;
            Thickness = 1.55M;
            Value = .01M;
        }
    }

    public class Nickel : Coin
    {
        public Nickel()
        {
            Weight = 5.0M;
            Diameter = 21.21M;
            Thickness = 1.95M;
            Value = .05M;
        }
    }

    public class Dime : Coin
    {
        public Dime()
        {
            Weight = 2.268M;
            Diameter = 17.91M;
            Thickness = 1.35M;
            Value = .10M;
        }
    }

    public class Quarter : Coin
    {
        public Quarter()
        {
            Weight = 5.67M;
            Diameter = 24.26M;
            Thickness = 1.75M;
            Value = .25M;
        }
    }
}
