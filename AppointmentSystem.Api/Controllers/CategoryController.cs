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
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService category)
        {
            categoryService = category;
        }
        [HttpPost]
        [Authorize]
        [Route("/addCategory")]
        public IActionResult addCategory([FromBody] Category category)
        {
            var response = categoryService.add(category);
            return Ok(response);
        }
        [HttpPut]
        [Authorize]
        [Route("/updateCategory")]
        public IActionResult updateCategory([FromBody] Category category)
        {
            var response = categoryService.update(category);
            return Ok(response);
        }
        [HttpDelete]
        [Authorize]
        [Route("/deleteCategory/{id}")]
        public IActionResult deleteCategory(int id)
        {
            var response = categoryService.delete(x=>x.ID == id);
            return Ok(response);
        }
        [HttpGet]
        [Route("/getCategory/{id}")]
        public IActionResult getCategory(int id)
        {
            var response = categoryService.get(x => x.ID == id);
            return Ok(response);
        }
        [HttpGet]
        [Route("/getCategories")]
        public IActionResult getCategories()
        {
            var response = categoryService.getList();
            return Ok(response);
        }
    }
}

