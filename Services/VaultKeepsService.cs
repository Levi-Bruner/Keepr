using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;
namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }
    public VaultKeep Create(VaultKeep newVaultKeep)
    {
      return _repo.Create(newVaultKeep);
    }
    internal VaultKeep Delete(int Id, string userId)
    {
      VaultKeep found = _repo.GetVaultKeepsByVaultKeepId(Id);
      if (found.UserId != userId)
      {
        throw new UnauthorizedAccessException("Invalid Request");
      }
      if (_repo.Delete(Id))
      {
        return found;
      }
      throw new Exception("An unknown error has occurred");
    }
  }
}