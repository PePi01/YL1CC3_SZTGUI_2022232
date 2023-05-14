using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YL1CC3_HFT_2022231.Models;
using YL1CC3_HFT_2022231.Repository;

namespace YL1CC3_HFT_2022231.Logic
{
    public class RentLogic : IRentLogic
    {
        IRepository<Rent> repo;
        // NON CRUD: egyes kocsikat hany napra berelnek ki
        public IEnumerable<Renting> RentTimes()
        {

            return (from x in repo.ReadAll()
                   select new Renting
                   {
                       Days = x.Interval,
                       Model=x.Car.Model,
                   }).AsEnumerable().OrderBy(t=>t.Days);
            
        }

        public RentLogic(IRepository<Rent> repo)
        {
            this.repo = repo;
        }

        public void Create(Rent item)
        {
            if (item.Interval<0)
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

        public Rent Read(int id)
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

        public IQueryable<Rent> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Rent item)
        {
            if (item.Interval < 0)
            {
                throw new ArgumentException();
            }
            this.repo.Update(item);
        }
    }

    
}
