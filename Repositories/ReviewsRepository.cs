using System;
using System.Collections.Generic;
using System.Data;
using JobLog.Models;
using Dapper;

namespace JobLog.Repositories
{
  public class ReviewsRepository
  {
    private readonly IDbConnection _db;
    public ReviewsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal Review GetById(int id)
    {
      string sql = "SELECT * FROM reviews WHERE id=@id LIMIT 1";
      return _db.QueryFirstOrDefault<Review>(sql, new { id });
    }
    internal Review Create(Review newReview)
    {
      string sql = @"
      INSERT INTO reveiws
      (title,body,rating,date,contractorId)
      VALUES
      (@Title,@Body,@Rating,@Date,@ContractorId);
      SELECT LAST_INSERT_ID()";
      newReview.Id = _db.ExecuteScalar<int>(sql, newReview);
      return newReview;
    }
    internal Review Edit(Review update)
    {
      string sql = @"
      UPDATE reviews
      SET
      title=@Title,
      body=@Body,
      rating=@Rating,
      date=@Date,
      WHERE id = @Id";
      _db.Execute(sql, update);
      return update;
    }
    internal void Delete(int id)
    {
      string sql = "Delete FROM reviews WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
    internal IEnumerable<Review> GetByContractorId(int id)
    {
      string sql = "SELECT * FROM reviews WHERE productId = @id";
      return _db.Query<Review>(sql, new { id });
    }
  }
}