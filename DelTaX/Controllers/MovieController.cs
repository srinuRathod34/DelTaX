using DelTaX.Manager;
using DelTaX.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DelTaX.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        private MoviesManager moviesManager{get;set;}
        public MovieController()
        {
            this.moviesManager = new MoviesManager();
        }
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet("GetAllMovieDetails")]
        public ActionResult GetAllMovieDetails()
        {
            try
            {
                var moviesDetails = moviesManager.GetAllMovieDetails();
                if(moviesDetails!=null && moviesDetails.Count>0)
                    return StatusCode(200,moviesDetails);
            }
            catch (Exception ex)
            {
                Models.Utilities.HandleException(ex);
                return StatusCode(500);
            }
            return NoContent();
        }

        [HttpPost("AddMovieDetails")]
        public ActionResult AddMovieDetails(AddMovieDetails addEditMovieDetails)
        {
            int AddedId = 0;
            try
            {
                AddedId = moviesManager.AddMovieDetails(addEditMovieDetails);
                if (AddedId >0)
                {
                    return Ok(AddedId);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                Models.Utilities.HandleException(ex);
                return StatusCode(500);
            }
        }

        [HttpPut("EditMovieDetails")]
        public ActionResult EditMovieDetails(EditMovieDetails editMovieDetails)
        {
            int editedId = 0;
            try
            {
                editedId = moviesManager.EditMovieDetails(editMovieDetails);
                if (editedId > 0)
                {
                    return Ok(editedId);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                Models.Utilities.HandleException(ex);
                return StatusCode(500);
            }

        }
    }
}
