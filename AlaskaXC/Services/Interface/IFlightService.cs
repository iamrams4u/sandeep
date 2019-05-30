using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlaskaXC.Models;
namespace AlaskaXC.Services.Interface
{
    public interface IFlightService
    {
        Task<List<FlightModel>> GetFlightData();
    }
}