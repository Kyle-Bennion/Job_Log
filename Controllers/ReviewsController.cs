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
  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Review>> Create([FromBody] Review newReview)
  {
    try
    {
      Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
      newReview.CreatorId = userInfo.Id;
      return Ok(_service.Create(newReview));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]
  public async Task<ActionResult<Review>> Edit([FromBody] Review update, int id)
  {
    try
    {
      Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
      update.CreatorId = userInfo.Id;
      update.Id = id;
    }
    catch (Exception e)
    {
      return BadRequest(e.Message)
    }
  }
  [HttpDelete("{id}")]
  [Authorize]
  public async Task<ActionResult<string>> Delete(int id)
  {
    try
    {
      CacheProfile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
      return Ok(_service.Delete(id, userInfo.Id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
}