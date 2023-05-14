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
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarLogic logic;
        IHubContext<SignalRHub> hub;
        public CarController(ICarLogic logic,IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Car> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Car Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Car value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("CarCreated", value);
        }

        //---------ez lehet h update nek kell
        [HttpPut]
        public void Put([FromBody] Car value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("CarUpdated", value);
        }
        //---------

        

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var CarToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("CarDeleted", CarToDelete);
        }
    }
}
