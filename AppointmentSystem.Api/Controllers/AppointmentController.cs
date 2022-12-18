using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentSystem.Business.Abstract;
using AppointmentSystem.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSystem.Api.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService appointmentService;
        public AppointmentController(IAppointmentService appointment)
        {
            appointmentService = appointment;
        }
        [HttpPost]
        [Route("/addAppointment")]
        public IActionResult addAppointment([FromBody] Appointment appointment,List<AppointmentService> appointmentServices)
        {
            var response = appointmentService.add(appointment);
            return Ok(response);
        }
        [HttpGet]
        [Authorize]
        [Route("/getAppointments")]
        public IActionResult getList()
        {
            var response = appointmentService.getList();
            return Ok(response);
        }
        [HttpGet]
        [Authorize]
        [Route("/getAppointment/{id}")]
        public IActionResult getAppointment(int id)
        {
            var response = appointmentService.get(x => x.ID == id);
            return Ok(response);
        }
        [HttpPost]
        [Route("/cancelAppointment/{id}")]
        public IActionResult cancelAppointment(int id)
        {
            var response = appointmentService.get(x => x.ID == id);
            return Ok(response);
        }
    }
}

