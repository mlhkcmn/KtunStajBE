using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Data;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PostsController : ControllerBase
    {
        private ApiDbContext _dbContext;
        public PostsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return _dbContext.Posts.OrderByDescending(Post => Post.CreateDate);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _dbContext.Posts.Find(id);
            if (post != null)
            {
                return Ok(post);
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
        [HttpGet("byUserId/{id}")]
        public IActionResult GetByUserId(int id)
        {
            int UserId = Convert.ToInt32(id);
            var post = _dbContext.Posts.Where(pst => pst.UserId == UserId);
            if (post != null) {
                return Ok(post);
            } else {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
        [HttpPost]
        public void Post([FromBody] Post post)
        {
            post.CreateDate = DateTime.UtcNow;
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Post postObj)
        {
            var post = _dbContext.Posts.Find(id);
            post.StudentName = postObj.StudentName;
            post.StudentNo = postObj.StudentNo;
            post.StudentDepartment = postObj.StudentDepartment;
            post.StudentClass = postObj.StudentClass;
            post.StudentTcNo = postObj.StudentTcNo;
            post.StudentMail = postObj.StudentMail;
            post.StudentGsmNo = postObj.StudentGsmNo;
            post.InternshipSelection = postObj.InternshipSelection;
            post.CorporationName = postObj.CorporationName;
            post.CorporationAddress = postObj.CorporationAddress;
            post.CorporationProduction = postObj.CorporationProduction;
            post.CorporationWorkerCount = postObj.CorporationWorkerCount;
            post.CorporationPersonalityTcNo = postObj.CorporationPersonalityTcNo;
            post.CorporationGsmNo = postObj.CorporationGsmNo;
            post.CorporationFax = postObj.CorporationFax;
            post.CorporationTaxNo = postObj.CorporationTaxNo;
            post.CorporationDepartment = postObj.CorporationDepartment;
            post.CorporationAuthorizedPerson = postObj.CorporationAuthorizedPerson;
            post.CorporationWebAddress = postObj.CorporationWebAddress;
            post.CorporationMail = postObj.CorporationMail;
            post.CorporationShef = postObj.CorporationShef;
            _dbContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var post = _dbContext.Posts.Find(id);
            _dbContext.Posts.Remove(post);
            _dbContext.SaveChanges();
        }
    }
}