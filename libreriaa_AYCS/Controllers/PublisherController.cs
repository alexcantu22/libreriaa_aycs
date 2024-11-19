  using libreriaa_AYCS.Data.Services;
using libreriaa_AYCS.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            _PublishersServices.AddPublisher(publisher);
            return Ok();
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
            _PublishersServices.DeletePublisherById(id);
            return Ok();    
        }
    }
}
