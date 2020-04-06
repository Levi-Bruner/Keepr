using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{
  public class Keep
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Img { get; set; }
    [Required]
    public bool IsPrivate { get; set; }
    public int Views { get; set; } = 0;
    public int Shares { get; set; } = 0;
    public int Keeps { get; set; } = 0;

  }
  public class VaultKeepViewModel : Keep
  {
    public int VaultKeepId { get; set; }
  }
}