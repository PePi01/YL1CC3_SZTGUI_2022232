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
    [Route("[controller]/[action]")]
    [ApiController]
    public class NCRentController : ControllerBase
    {
        IRentLogic logic;

        public NCRentController(IRentLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        //rent duration
        public IEnumerable<Renting> RentTimes()
        {
            return this.logic.RentTimes();
        }

    }
}
