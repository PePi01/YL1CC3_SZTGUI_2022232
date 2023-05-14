using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YL1CC3_HFT_2022231.Models;

namespace YL1CC3_HFT_2022231.Logic
{
    public interface IBrandLogic
    {
        void Create(Brand item);
        void Delete(int id);
        Brand Read(int id);
        IQueryable<Brand> ReadAll();
        void Update(Brand item);
        IEnumerable<PriceOfBrands> SumPriceByBrand();
        IEnumerable<RentBrandFrequency> FreqOfBrandsRented();
        IEnumerable<AvgPriceOfBrands> AvgPriceByBrand();
    }
}
