using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace VehiclesDiary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehiclesManager _vehiclesManager;

        public VehiclesController(IVehiclesManager vehiclesManager)
        {
            _vehiclesManager = vehiclesManager;
        }

        [HttpPost]
        public IStatusCodeActionResult Add(VehicleCreationRequest input)
        {
            if (input.Name == null)
            {
                return BadRequest("Name is required");
            }

            Vehicle vehicle = input.ToModel();

            try
            {
                _vehiclesManager.Create(vehicle);
            }
            catch (Exception e)
            {
	            return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpDelete]
        public IStatusCodeActionResult Del(string name)
        {
            _vehiclesManager.Remove(name);
            return Ok();
        }
    }
}