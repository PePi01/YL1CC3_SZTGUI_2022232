using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YL1CC3_HFT_2022231.Models;
using YL1CC3_HFT_2022231.Repository;

namespace YL1CC3_HFT_2022231.Logic
{
    public class CarLogic : ICarLogic
    {
        IRepository<Car> repo;
        public IEnumerable<RentFrequency> FreqOfCarsRented()
        {
            
            return (from x in repo.ReadAll()
                    select new RentFrequency
                    {
                        Model = x.Model,
                        Frequency = x.Rents.Count()
                    }).OrderBy(t => t.Frequency);
            
        }
        public IEnumerable<ParametricBrand> ParametricBrand(int num)
        {

            return from x in repo.ReadAll()
                   where x.BrandId == num
                   select new ParametricBrand
                   {
                       Model = x.Model,
                   };

        }

        public CarLogic(IRepository<Car> repo)
        {
            this.repo = repo;
        }

        public void Create(Car item)
        {
            if (item.Price<0)
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

        public Car Read(int id)
        {
            if (id<1)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                return this.repo.Read(id);
            }
        }

        public IQueryable<Car> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Car item)
        {
            if (item.Price < 0)
            {
                throw new ArgumentException();
            }
            this.repo.Update(item);
        }

        
    }
    
}
