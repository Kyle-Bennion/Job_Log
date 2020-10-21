using System;
using System.Threading.Tasks;
using JobLog.Models;
using JobLog.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobLog.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ReviewsController : ControllerBase
  {
    private readonly ReviewsService _service;

    public ReviewsController(ReviewsService service)
    {
      _service = service;
    }

    [HttpGet("{id}")]
    public ActionResult<Review> GetAction(int id)
    {
      try
      {
        return Ok(_service.GetById(id));
      }
      catch (AccessViolationException e)
      {
        return Forbid(e.Message);
        {
      catch (Exception e)
      }
      return BadRequest(e.Message);
    }
  }
}
}