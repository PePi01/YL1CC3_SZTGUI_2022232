using System;
using System.Collections.Generic;
using System.Linq;
using YL1CC3_HFT_2022231.Models;
using YL1CC3_HFT_2022231.Repository;

namespace YL1CC3_HFT_2022231.Logic
{
    public class BrandLogic : IBrandLogic
    {
        IRepository<Brand> repo;
        public IEnumerable<PriceOfBrands> SumPriceByBrand()
        {
            return (from x in repo.ReadAll()
                    where x.Cars.Sum(t => t.Price) > 0
                    select new PriceOfBrands()
                    {
                        Brand = x.Name,
                        Price=x.Cars.Select(t=>t.Price).Sum()
                    }).OrderBy(x=>x.Price);
        }

        public IEnumerable<RentBrandFrequency> FreqOfBrandsRented()
        {
            return (from x in repo.ReadAll()
                   select new RentBrandFrequency
                   {
                       Brand = x.Name,
                       Frequency = x.Cars.Select(t=>t.Brand.Name).Count()
                   }).OrderBy(t=>t.Frequency);
        }
        // markak atlagosan mennyibe kerulnek
        public IEnumerable<AvgPriceOfBrands> AvgPriceByBrand()
        {

            return (from x in repo.ReadAll().AsEnumerable()
                    where x.Cars.Sum(t=>t.Price)>0
                    select new AvgPriceOfBrands()
                    {
                        Brand = x.Name,
                        
                        Price =  Math.Round(x.Cars.Average(t=>t.Price),0)
                    }).OrderBy(x => x.Price);
        }
        public BrandLogic(IRepository<Brand> repo)
        {
            this.repo = repo;
        }

        public void Create(Brand item)
        {
            if (item.Name.Length>8)
            {
                throw new ArgumentException();
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                this.repo.Delete(id);
            }
            
        }

        public Brand Read(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                return this.repo.Read(id);
            }
        }

        public IQueryable<Brand> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Brand item)
        {
            if (item.Name.Length > 8)
            {
                throw new ArgumentException();
            }
            this.repo.Update(item);
        }
    }
}
