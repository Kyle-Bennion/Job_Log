using System.ComponentModel.DataAnnotations;

namespace JobLog.Models
{
  public class Contractor
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Contact { get; set; }
    public string Skill { get; set; }
  }

}