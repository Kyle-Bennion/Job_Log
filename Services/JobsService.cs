using System;
using System.Collections.Generic;
using JobLog.Models;
using JobLog.Repositories;

namespace JobLog.Services
{
  public class JobsService
  {
    private readonly JobsRespository _repo;
    public JobsService(JobsRespository repo)
    {
      _repo = repo;
    }
    internal IEnumerable<Job> GetAll()
    {
      return _repo.GetAll();
    }
    internal Job GetById(int id)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }
    internal Job Create(Job newJob)
    {
      return _repo.Create(newJob);
    }
    internal Job Edit(Job updated)
    {
      var data = GetById(updated.Id);
      return _repo.Edit(updated);
    }
    internal string Delete(int id)
    {
      var data = GetById(id);
      _repo.Delete(id);
      return "Deleted This Crap";

    }
  }
}