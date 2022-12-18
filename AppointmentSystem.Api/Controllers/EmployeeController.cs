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
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employee)
        {
            employeeService = employee;
        }
        [HttpPost]
        //[Authorize]//araştır, jwt token araştır
        [Route("/addEmployee")]
        public IActionResult addEmployee([FromBody] Employee employee)
        {
            var response = employeeService.add(employee);
            //burası bir endpoint yani iletişim kanalı bu iletişim kanalı http isteekleri ile iletişim kuruyoruz
            return Ok(response);
        }
        [HttpPut]
        //[Authorize]
        [Route("/updateEmployee")]
        public IActionResult updateEmployee([FromBody] Employee employee)
        {
            var response = employeeService.update(employee);
            return Ok(response);
        }
        [HttpDelete]
        [Authorize]
        [Route("/deleteEmployee/{id}")]
        public IActionResult deleteEmployee(int id)
        {
            var response = employeeService.delete(x => x.ID == id);
            return Ok(response);
        }
        [HttpGet]
        [Route("/getEmployee/{id}")]
        public IActionResult getEmployee(int id)
        {
            var response = employeeService.get(x => x.ID == id);
            return Ok(response);
        }
        [HttpGet]
        [Route("/getEmployees")]
        public IActionResult getEmployees()
        {
            var response = employeeService.getList();
            return Ok(response);
        }
    }
}

