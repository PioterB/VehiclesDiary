using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using VehiclesDiary.BuisnessLayer.Vehicles;

namespace VehiclesDiary.Services
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