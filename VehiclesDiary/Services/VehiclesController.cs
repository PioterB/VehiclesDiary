using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using VehiclesDiary.BusinessLayer.Vehicles;
using VehiclesDiary.DataAccess;

namespace VehiclesDiary.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehiclesManager _vehiclesManager;
        private readonly IRepository<Vehicle> _vehiclesRepository;

        public VehiclesController(IVehiclesManager vehiclesManager, IRepository<Vehicle> vehiclesRepository)
        {
	        _vehiclesManager = vehiclesManager;
	        _vehiclesRepository = vehiclesRepository;
        }

        [HttpGet]
        public IEnumerable<VehiclePreview> Get()
        {
	        return _vehiclesRepository.Get().Select(item => new VehiclePreview(item));
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