using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YL1CC3_HFT_2022231.Models
{
    public class ParametricBrand
    {
        public string Model { get; set; }
    }
    public class PriceOfBrands
    {
        public string Brand { get; set; }
        public int Price { get; set; }
    }
    public class AvgPriceOfBrands
    {
        public string Brand { get; set; }
        public double Price { get; set; }
    }

    public class RentBrandFrequency
    {
        public string Brand { get; set; }
        public int Frequency { get; set; }
    }
    public class Renting
    {
        public int Days { get; set; }

        public string Model { get; set; }

    }
    public class RentFrequency
    {
        public int Frequency { get; set; }
        public string Model { get; set; }
    }
}
