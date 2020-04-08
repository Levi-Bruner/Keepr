using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Vault> GetAll(string userId)
    {
      string sql = "SELECT * FROM vaults WHERE UserId = @userId";
      return _db.Query<Vault>(sql, new { UserId = @userId });
    }

    internal Vault Get(int id)
    {
      string sql = "SELECT * FROM vaults WHERE id = @Id";
      return _db.QueryFirstOrDefault<Vault>(sql, new { Id = id });
    }

    internal Vault Create(Vault newVault)
    {
      string sql = @"
      INSERT INTO vaults
      (name, description, userId)
      VALUES
      (@Name, @Description, @UserId);
      SELECT LAST_INSERT_ID()";
      newVault.Id = _db.ExecuteScalar<int>(sql, newVault);
      return newVault;
    }

    internal bool Delete(int Id)
    {
      string sql = "DELETE FROM vaults WHERE id = @id LIMIT 1";
      int removed = _db.Execute(sql, new { Id });
      return removed == 1;
    }
  }
}