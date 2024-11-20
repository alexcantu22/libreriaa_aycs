  using libreriaa_AYCS.Data.Services;
using libreriaa_AYCS.Data.ViewModels;
using libreriaa_AYCS.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace libreriaa_AYCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublishersService _PublishersServices;

        public PublishersController(PublishersService PublishersServices)
        {
            _PublishersServices = PublishersServices;
        }

        [HttpPost("add-Publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            try
            { 
                    var newPublisher = _PublishersServices.AddPublisher(publisher);
                    return Created(nameof(AddPublisher), newPublisher);
                
            }
            catch (PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Nombre de la editora: {ex.PublisherName}");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-publisher-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var _response = _PublishersServices.GetPublisherByID(id);
            if (_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        { 
          var  _response = _PublishersServices.GetPublisherData(id);
            return Ok( _response );
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            
            try
            {
                _PublishersServices.DeletePublisherById(id);
                return Ok();
            }
           
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
