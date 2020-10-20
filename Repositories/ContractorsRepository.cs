using System.Collections.Generic;
using System.Data;
using JobLog.Models;
using Dapper;

namespace JobLog.Repositories
{
  public class ContractorsRepository
  {
    private readonly IDbConnection _db;
    public ContractorsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Contractor> GetAll()
    {
      string sql = "SELECT * FROM contractors";
      return _db.Query<Contractor>(sql);
    }
    internal Contractor GetById(int id)
    {
      string sql = "SELECT * FROM contractors WHERE id = @id";
      return _db.QueryFirstOrDefault<Contractor>(sql, new { id });
    }
    internal Contractor Create(Contractor newCont)
    {
      string sql = @"INSERT INTO contractors (name, address,contact, skills) VALUES(@Name,@Address,@Contact,@Skills); SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newCont);
      newCont.Id = id;
      return newCont;
    }
    internal Contractor Edit(Contractor updated)
    {
      string sql = @"UPDATE contractors SET name = @Name, address = @Address, contact=@Contact, skills=@Skills WHERE id=@Id;";
      _db.Execute(sql, updated);
      return updated;
    }
    internal void Delete(int id)
    {
      string sql = "DELETE FROM contractors WHERE id=@Id";
      _db.Execute(sql, new { id });
    }
  }
}

