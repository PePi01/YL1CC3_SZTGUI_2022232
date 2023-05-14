using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YL1CC3_HFT_2022231.Endpoint.Services;
using YL1CC3_HFT_2022231.Logic;
using YL1CC3_HFT_2022231.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YL1CC3_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NCBrandController : ControllerBase
    {
        IBrandLogic logic;
        IHubContext<SignalRHub> hub;
        public NCBrandController(IBrandLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }
        [HttpGet]

        public IEnumerable<PriceOfBrands> SumPriceByBrand()
        {
            return this.logic.SumPriceByBrand();
        }
        [HttpGet]

        public IEnumerable<RentBrandFrequency> FreqOfBrandsRented()
        {
            return this.logic.FreqOfBrandsRented();
        }
        [HttpGet]

        public IEnumerable<AvgPriceOfBrands> AvgPriceByBrand()
        {
            return this.logic.AvgPriceByBrand();
        }
    }
}
