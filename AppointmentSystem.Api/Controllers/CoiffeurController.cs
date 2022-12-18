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
    public class CoiffeurController : Controller
    {
        private readonly ICoiffeurService coiffeurService;
        public CoiffeurController(ICoiffeurService coiffeur)
        {
            coiffeurService = coiffeur;
        }
        [HttpPost]
        [Route("/auth/{email}/{password}")]
        public IActionResult login(string email,string password)
        {
            var response = coiffeurService.Authentication(email,password);
            return Ok(response);
        }
        [HttpPut]
        [Authorize]
        [Route("/updateCoiffeur")]
        public IActionResult updateCoiffeur([FromBody] Coiffeur coiffeur)
        {
            var response = coiffeurService.update(coiffeur);
            return Ok(response);
        }
        [HttpGet]
        [Route("/getCoiffeur")]
        public IActionResult getCoiffeur()
        {
            var response = coiffeurService.get(x => true);
            return Ok(response);
        }
    }
}

