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

    /// <summary>
    /// A class to hold pennies
    /// </summary>
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

    /// <summary>
    /// A class to hold nickels
    /// </summary>
    public class Nickel : Coin
    {
        //Construct a real nickel
        public Nickel()
        {
            Weight = 5.0M;
            Diameter = 21.21M;
            Thickness = 1.95M;
            Value = .05M;
        }

        //Construct a fake nickel
        public Nickel(decimal weight)
        {
            Weight = weight;
            Diameter = 21.21M;
            Thickness = 1.95M;
            Value = 0;
        }
    }

    /// <summary>
    /// A class to hold dimes
    /// </summary>
    public class Dime : Coin
    {
        //Construct a real dime
        public Dime()
        {
            Weight = 2.268M;
            Diameter = 17.91M;
            Thickness = 1.35M;
            Value = .10M;
        }

        //Construct a fake dime
        public Dime(decimal diameter)
        {
            Weight = 2.268M;
            Diameter = diameter;
            Thickness = 1.35M;
            Value = 0;
        }
    }

    /// <summary>
    /// A class to hold quarters
    /// </summary>
    public class Quarter : Coin
    {
        //Construct a real quarter
        public Quarter()
        {
            Weight = 5.67M;
            Diameter = 24.26M;
            Thickness = 1.75M;
            Value = .25M;
        }

        //Construct a fake quarter
        public Quarter(decimal thickness)
        {
            Weight = 5.67M;
            Diameter = 24.26M;
            Thickness = thickness;
            Value = 0;
        }
    }

    /// <summary>
    /// An extension method for validating coins
    /// </summary>
    public static class ValidateCoin
    {
        public static bool ValidCoin(this Coin coin)
        {
            bool returnValue = false;

            if (coin.GetType() == typeof(Penny))
                returnValue = false;
            else if (coin.GetType() == typeof(Nickel))
            {
                Nickel validNickel = new Nickel();
                if (validNickel.Weight == coin.Weight &&
                    validNickel.Diameter == coin.Diameter &&
                    validNickel.Thickness == coin.Thickness)
                    returnValue = true;
                else
                    returnValue = false;
            }
            else if (coin.GetType() == typeof(Dime))
            {
                Dime validDime = new Dime();
                if (validDime.Weight == coin.Weight &&
                    validDime.Diameter == coin.Diameter &&
                    validDime.Thickness == coin.Thickness)
                    returnValue = true;
                else
                    returnValue = false;
            }
            else if (coin.GetType() == typeof(Quarter))
            {
                Quarter validQuarter = new Quarter();
                if (validQuarter.Weight == coin.Weight &&
                    validQuarter.Diameter == coin.Diameter &&
                    validQuarter.Thickness == coin.Thickness)
                    returnValue = true;
                else
                    returnValue = false;
            }

            return returnValue;
        }
    }
}
