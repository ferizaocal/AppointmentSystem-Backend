using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentSystem.Business.Abstract;
using AppointmentSystem.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppointmentSystem.Api.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService serviceService;
        public ServiceController(IServiceService service)
        {
            serviceService = service;
        }

        [HttpPost]
        [Authorize]
        [Route("/addService")]
        public IActionResult addService([FromBody] Service service)
        {
            var response = serviceService.add(service);
            return Ok(response);
        }
        [HttpPut]
        [Authorize]
        [Route("/updateService")]
        public IActionResult updateService([FromBody] Service service)
        {
            var response = serviceService.update(service);
            return Ok(response);
        }
        [HttpDelete]
        [Authorize]
        [Route("/deleteService/{id}")]
        public IActionResult deleteService(int id)
        {
            var response = serviceService.delete(x => x.ID == id);
            return Ok(response);
        }
        [HttpGet]
        [Route("/getService/{id}")]
        public IActionResult getService(int id)
        {
            var response = serviceService.get(x => x.ID == id);
            return Ok(response);
        }
        [HttpGet]
        [Route("/getServices")]
        public IActionResult getServices()
        {
            var response = serviceService.getList();
            return Ok(response);
        }
    }
}

