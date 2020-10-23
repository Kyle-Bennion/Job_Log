using System;
using System.Data;
using JobLog.Models;
using Dapper;
using System.Collections.Generic;

namespace JobLog.Repositories
{
  public class BidsRepository
  {
    private readonly IDbConnection _db;
    public BidsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal int Create(Bid newBid)
    {
      string sql = @"
      INSERT INTO bids
      (jobId, contractorId,estimate)
      VALUES
      (@JobId,@ContractorId,@Estimate);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newBid);
    }
    internal Bid GetById(int id)
    {
      string sql = "SELECT * FROM bids WHERE id = @id;";
      return _db.QueryFirstOrDefault<Bid>(sql, new { id });
    }
    internal void Delete(int id)
    {
      string sql = "DELETE FROM bids WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }

    internal IEnumerable<JobBidsViewModel> GetByContractorId(int contractorId)
    {
      string sql = @"
      SELECT j.*, b.id AS bidId
      FROM bids b
      JOIN jobs j ON j.id = b.jobId 
      WHERE b.contractorId = @ContractorId;";
      return _db.Query<JobBidsViewModel>(sql, new { contractorId });
    }
  }
}