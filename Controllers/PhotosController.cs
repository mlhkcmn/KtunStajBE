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