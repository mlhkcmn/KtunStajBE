using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Data;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PhotosController : ControllerBase
    {
        private ApiDbContext _dbContext;
        public PhotosController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var photo = _dbContext.Photos.Find(id);
            if (photo != null)
            {
                return Ok(photo);
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
        [HttpPost]
        public PhotoReturnType Post([FromBody] Photo photo)
        {
            _dbContext.Photos.Add(photo);
            _dbContext.SaveChanges();

            PhotoReturnType returnData = new PhotoReturnType();

            returnData.id = photo.Photo_Id;

            return returnData;
        }
    }
}