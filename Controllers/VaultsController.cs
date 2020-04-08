using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _vs;
    private readonly KeepsService _ks;
    public VaultsController(VaultsService vs, KeepsService ks)
    {
      _vs = vs;
      _ks = ks;
    }
    [HttpGet]
    [Authorize]
    public ActionResult<IEnumerable<Vault>> GetAll()
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_vs.GetAll(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }
    [HttpGet("{id}")]
    [Authorize]
    public ActionResult<Vault> Get(int id)
    {
      try
      {
        Vault vault = _vs.Get(id);
        var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user != null && user.Value == vault.UserId)
        {
          return Ok(vault);
        }
        return Unauthorized("You do not have access to this Vault");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{vaultId}/keeps")]
    [Authorize]
    public ActionResult<IEnumerable<Keep>> GetKeepsByVaultId(int vaultId)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_ks.GetKeepsByVaultId(vaultId, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Vault> Post([FromBody] Vault newVault)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newVault.UserId = userId;
        return Ok(_vs.Create(newVault));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // [HttpPut("{id}")]
    // [Authorize]
    // public ActionResult<Vault> Edit(int id, [FromBody] Vault updatedVault)
    // {

    // }
    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<Vault> Delete(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_vs.Delete(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}