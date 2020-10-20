using System;
using System.Collections.Generic;
using System.Data;
using JobLog.Models;
using Dapper;

namespace JobLog.Repositories
{
  public class JobsRespository
  {

    private readonly IDbConnection _db;
    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Job> GetAll()
    {
      string sql = "SELECT * FROM jobs";
      return _db.Query<Job>(sql);
    }
    internal Job GetById(int id)
    {
      string sql = "SELECT * FROM jobs WHERE id = @id";
      return _db.QueryFirstOrDefault<Job>(sql, new { id });
    }
    internal Job Create(Job newJob)
    {
      string sql = @" INSERT INTO jobs (location, description, contact) VALUES (@location, @description,@contact);SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newJob);
      newJob.Id = id;
      return newJob;
    }
    internal Job Edit(Job updated)
    {
      string sql = @"UPDATE jobs SET location = @Location, description = @Description, contact = @Contact WHERE id = @Id;"; _db.Execute(sql, updated);
      return updated;
    }
  }
}