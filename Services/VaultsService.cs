using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Vault> GetAll(string userId)
    {
      return _repo.GetAll(userId);
    }
    internal Vault Get(int id)
    {
      Vault found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    public Vault Create(Vault newVault)
    {
      return _repo.Create(newVault);
    }

    internal Vault Delete(int id, string userId)
    {
      Vault found = Get(id);
      if (found.UserId != userId)
      {
        throw new Exception("Invalid Request");
      }
      if (_repo.Delete(id))
      {
        return found;
      }
      throw new Exception("An unknown error has occurred");
    }
  }
}