using libreriaa_AYCS.Data.Services;
using libreriaa_AYCS.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace libreriaa_AYCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorService _authorsServices;

        public AuthorsController(AuthorService authorsServices) 
        {
            _authorsServices = authorsServices;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorsServices.AddAuthor(author);
            return Ok();
        }

    }
}
