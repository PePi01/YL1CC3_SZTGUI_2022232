using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YL1CC3_HFT_2022231.Logic;
using YL1CC3_HFT_2022231.Models;

namespace YL1CC3_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AvgPriceOfBrandsController : ControllerBase
    {
        IBrandLogic logic;
        public AvgPriceOfBrandsController(IBrandLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<AvgPriceOfBrands> AvgPriceByBrand()
        {
            return this.logic.AvgPriceByBrand();
        }
    }
}
