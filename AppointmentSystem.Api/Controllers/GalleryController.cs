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
    public class GalleryController : Controller
    {
        private readonly IGalleryService galleryService;
        public GalleryController(IGalleryService gallery)
        {
            galleryService = gallery;
        }

        [HttpPost]
        [Authorize]
        [Route("/addGallery")]
        public IActionResult addGallery([FromBody] Gallery gallery)
        {
            var response = galleryService.add(gallery);
            return Ok(response);
        }
        [HttpPut]
        [Authorize]
        [Route("/updateGallery")]
        public IActionResult updateGallery([FromBody] Gallery gallery)
        {
            var response = galleryService.update(gallery);
            return Ok(response);
        }
        [HttpDelete]
        [Authorize]
        [Route("/deleteGallery/{id}")]
        public IActionResult deleteGallery(int id)
        {
            var response = galleryService.delete(x => x.ID == id);
            return Ok(response);
        }
        [HttpGet]
        [Route("/getGallery/{id}")]
        public IActionResult getGallery(int id)
        {
            var response = galleryService.get(x => x.ID == id);
            return Ok(response);
        }
        [HttpGet]
        [Route("/getGalleries")]
        public IActionResult getGalleries()
        {
            var response = galleryService.getList();
            return Ok(response);
        }
    }
}

