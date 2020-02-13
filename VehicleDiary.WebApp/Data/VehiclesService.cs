using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace VehicleDiary.WebApp.Data
{
    public class VehiclesService
    {
        private const string apiLocation = "http://localhost:54879/api/vehicles";

        public async Task<VehiclePreview[]> GetAsync()
        {
            using (var http = new HttpClient())
            {
                var response = http.GetStreamAsync(apiLocation);
                return await JsonSerializer.DeserializeAsync<VehiclePreview[]>(await response);
            }
            // return await Task.FromResult(new[] { new VehiclePreview { Name = "x", Type = "Car" } });
        }
    }
}
