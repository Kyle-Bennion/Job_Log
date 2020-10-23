using System;
using JobLog.Models;
using JobLog.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobLog.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ContractorsController : ControllerBase
  {
    private readonly ContractorsService _service;

    public ContractorsController(ContractorsService cs)
    {
      _service = cs;
    }
    [HttpGet]
    public ActionResult<Contractor> GetAction()
    {
      try
      {
        return Ok(_service.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Contractor> GetAction(int id)
    {
      try
      {
        return Ok(_service.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // THIS IS THE GET JOBS BID Many TO Many
    [HttpGet("{contractorId}/jobBids")]
    public ActionResult<Job> GetJobBidsByContractorId(int contractorId)
    {
      try
      {
        return Ok(_service.GetJobBidsByContractorId(contractorId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Contractor> Create([FromBody] Contractor newCont)
    {
      try
      {
        return Ok(_service.Create(newCont));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Contractor> Edit([FromBody] Contractor updated, int id)
    {
      try
      {
        updated.Id = id;
        return Ok(_service.Edit(updated));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Contractor> Delete(int id)
    {
      try
      {
        return Ok(_service.Delete(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
  }

}