using System;
using AlaskaXC.Services.Interface;
using System.Collections.Generic;
using AlaskaXC.Models;
using System.Threading.Tasks;

namespace AlaskaXC.ViewModels
{
    public class SecondViewModel
    {
        private readonly IFlightService flightService;

        public SecondViewModel(IFlightService flightService)
        {
            this.flightService = flightService;
        }

        public async Task<List<FlightModel>> GetFlights()
        {
            return await flightService.GetFlightData();
        }
    }
}