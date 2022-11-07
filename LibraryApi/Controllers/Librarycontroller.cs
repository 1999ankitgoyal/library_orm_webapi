using LibraryApi.EFcore;
using LibraryApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApi.Controllers
{
    [Route("api/library")]
    [ApiController]
    public class Librarycontroller : ControllerBase
    {
        private readonly DbHelper _db;

        public Librarycontroller(EF_DataContext eF_DataContext)
        {
            _db = new DbHelper(eF_DataContext);
        }

        [HttpGet]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<relationmodel> data = _db.Getrelation();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPost]
        public IActionResult Post(relationmodel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.postrelation(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] relationmodel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.deleterelation(model);
                return Ok(ResponseHandler.GetAppResponse(type, "Deleted Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

    }

    [ApiController]
    [Route("api/library/books")]
    public class BookController : ControllerBase
    {
        private readonly DbHelper _db;
        public BookController(EF_DataContext eF_DataContext)
        {
            _db = new DbHelper(eF_DataContext);
        }

        [HttpGet]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<bookmodel> data = _db.Getbooks();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
       
        [HttpPost]
        public IActionResult Post(bookmodel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.Postbook(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPut]
        public IActionResult Put(bookmodel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.Postbook(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpDelete]
        public IActionResult Delete(bookmodel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.Deletebook(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }

    [ApiController]
    [Route("api/library/authors")]
    public class AuthorController : ControllerBase
    {
        private readonly DbHelper _db;
        public AuthorController(EF_DataContext eF_DataContext)
        {
            _db = new DbHelper(eF_DataContext);
        }

        [HttpGet]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<authormodel> data = _db.Getauthors();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        
        [HttpPost]
        public IActionResult Post(authormodel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.Postauthor(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPut]
        public IActionResult Put(authormodel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.Postauthor(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpDelete]
        public IActionResult Delete(authormodel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.Deleteauthor(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }



}
