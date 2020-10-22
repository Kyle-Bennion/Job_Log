using System;
using JobLog.Models;
using JobLog.Repositories;

namespace JobLog.Services
{
  public class BidsService
  {
    private readonly BidsRepository _repo;
    public BidsService(BidsRepository repo)
    {
      _repo = repo;
    }
    internal void Create(Bid newBid)
    {
      _repo.Create(newBid);
    }
    internal void Delete(int id)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.Delete(id);
    }
  }
}