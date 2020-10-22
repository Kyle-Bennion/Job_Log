using System;
using System.Data;
using JobLog.Models;
using Dapper;

namespace JobLog.Repositories
{
  public class BidsRepository
  {
    private readonly IDbConnection _db;
    public BidsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal void Create(Bid newBid)
    {
      string sql = @"
      INSERT INTO bids
      (jobId, contractorId,bid)
      VALUES
      (@JobId,@ContractorId,@Bid);";
      _db.Execute(sql, newBid);
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
  }
}