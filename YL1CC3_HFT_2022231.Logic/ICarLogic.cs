using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YL1CC3_HFT_2022231.Models;

namespace YL1CC3_HFT_2022231.Logic
{
    public interface ICarLogic
    {
        void Create(Car item);
        void Delete(int id);
        Car Read(int id);
        IQueryable<Car> ReadAll();
        void Update(Car item);
        IEnumerable<RentFrequency> FreqOfCarsRented();
        IEnumerable<ParametricBrand> ParametricBrand(int num);
    }
}
