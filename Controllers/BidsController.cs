using System;
using JobLog.Models;
using JobLog.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobLog.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BidsController : ControllerBase
  {
    private readonly BidsService _service;
    public BidsController(BidsService service)
    {
      _service = service;
    }
    [HttpPost]
    public ActionResult<Bid> Create([FromBody] Bid newBid)
    {
      try
      {
        Bid created = _service.Create(newBid);
        return Ok(created);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        _service.Delete(id);
        return Ok("success");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}