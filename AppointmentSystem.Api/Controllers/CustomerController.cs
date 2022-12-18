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
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;
        public CustomerController(ICustomerService customer)
        {
            customerService = customer;
        }

        [HttpPut]
        [Authorize]
        [Route("/updateCustomer")]
        public IActionResult updateCustomer([FromBody] Customer customer)
        {
            var response = customerService.update(customer);
            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        [Route("/getCustomer/{id}")]
        public IActionResult getCustomer(int id)
        {
            var response = customerService.get(x=>x.ID == id);
            return Ok(response);
        }
        [HttpGet]
        [Authorize]
        [Route("/getCustomers")]
        public IActionResult getCustomers()
        {
            var response = customerService.getList();
            return Ok(response);
        }
    }
}

