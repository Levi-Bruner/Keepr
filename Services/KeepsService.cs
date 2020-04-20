using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }
    internal object GetUserKeeps(string userId)
    {
      return _repo.GetUserKeeps(userId);
    }
    internal Keep Get(int id)
    {
      Keep found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int vaultId, string userId)
    {
      return _repo.GetKeepsByVaultId(vaultId, userId);
    }
    // POST
    public Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }
    // PUT
    internal Keep Edit(Keep updatedKeep)
    {
      Keep found = Get(updatedKeep.Id);
      if (found.UserId != updatedKeep.UserId)
      {
        throw new Exception("Invalid request");
      }
      found.Name = updatedKeep.Name;
      found.Description = updatedKeep.Description != null ? updatedKeep.Description : found.Description;
      found.Img = updatedKeep.Img;
      found.IsPrivate = updatedKeep.IsPrivate;
      found.Views = updatedKeep.Views;
      found.Shares = updatedKeep.Shares;
      found.Keeps = updatedKeep.Keeps;
      return _repo.Edit(found);
    }
    //DELETE
    internal Keep Delete(int id, string userId)
    {
      Keep found = Get(id);
      if (found.UserId != userId)
      {
        throw new Exception("Invalid Request");
      }
      if (_repo.Delete(id))
      {
        return found;
      }
      throw new Exception("An unknown error occurred");
    }

  }
}