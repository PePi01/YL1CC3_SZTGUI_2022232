using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YL1CC3_HFT_2022231.Logic;
using YL1CC3_HFT_2022231.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YL1CC3_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PriceOfBrandsController : ControllerBase
    {
        IBrandLogic logic;
        public PriceOfBrandsController(IBrandLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]

        public IEnumerable<PriceOfBrands> SumPriceByBrand()
        {
            return this.logic.SumPriceByBrand();
        }
    }
}
