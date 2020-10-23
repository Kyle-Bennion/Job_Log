using System;
using System.Collections.Generic;
using JobLog.Models;
using JobLog.Repositories;

namespace JobLog.Services
{
  public class ContractorsService
  {
    private readonly ContractorsRepository _repo;
    private readonly BidsRepository _brepo;

    public ContractorsService(ContractorsRepository repo, BidsRepository brepo)
    {
      _repo = repo;
      _brepo = brepo;
    }
    internal IEnumerable<Contractor> GetAll()
    {
      return _repo.GetAll();
    }
    internal Contractor GetById(int id)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }
    internal Contractor Create(Contractor newCont)
    {
      return _repo.Create(newCont);
    }
    internal Contractor Edit(Contractor updated)
    {
      var data = GetById(updated.Id);
      return _repo.Edit(updated);
    }
    internal string Delete(int id)
    {
      var data = GetById(id);
      _repo.Delete(id);
      return "Bye Bye Contractor";
    }

    internal IEnumerable<Job> GetJobBidsByContractorId(int contractorId)
    {
      return _brepo.GetByContractorId(contractorId);
    }
  }

}