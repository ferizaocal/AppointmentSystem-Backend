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
    public class CommentController : Controller
    {
        private ICommentService commentService;
        public CommentController(ICommentService comment)
        {
            commentService = comment;
        }
        [HttpPost]
        [Route("/addComment")]
        public IActionResult addGallery([FromBody] Comment comment)
        {
            var response = commentService.add(comment);
           
            return Ok(response);
        }
        [HttpPut]
        [Route("/updateComment")]
        public IActionResult updateComment([FromBody] Comment comment)
        {
            var response = commentService.update(comment);
            return Ok(response);
        }
        [HttpDelete]
        [Route("/deleteComment/{id}")]
        public IActionResult deleteComment(int id)
        {
            var response = commentService.delete(x => x.ID == id);
            return Ok(response);
        }
        [HttpGet]
        [Route("/getComment/{id}")]
        public IActionResult getComment(int id)
        {
            var response = commentService.get(x => x.ID == id);
            return Ok(response);
        }
        [HttpGet]
        [Route("/getComments")]
        public IActionResult getComments()
        {
            var response = commentService.getList();
            return Ok(response);
        }
    }
}

