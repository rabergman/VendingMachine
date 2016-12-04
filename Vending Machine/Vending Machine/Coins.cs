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
            this.Weight = 2.5M;
            this.Diameter = 19.05M;
            this.Thickness = 1.55M;
            this.Value = .01M;
        }
    }

    public class Nickel : Coin
    {
        public Nickel()
        {
            this.Weight = 5.0M;
            this.Diameter = 21.21M;
            this.Thickness = 1.95M;
            this.Value = .05M;
        }
    }

    public class Dime : Coin
    {
        public Dime()
        {
            this.Weight = 2.268M;
            this.Diameter = 17.91M;
            this.Thickness = 1.35M;
            this.Value = .10M;
        }
    }

    public class Quarter : Coin
    {
        public Quarter()
        {
            this.Weight = 5.67M;
            this.Diameter = 24.26M;
            this.Thickness = 1.75M;
            this.Value = .25M;
        }
    }
}
