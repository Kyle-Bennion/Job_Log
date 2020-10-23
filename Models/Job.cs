using System.ComponentModel.DataAnnotations;

namespace JobLog.Models
{
  public class Job
  {

    [Required]
    [MinLength(2)]
    public string Location { get; set; }
    public string Description { get; set; }
    [Required]
    public string Contact { get; set; }
    public int Id { get; set; }

  }
  public class JobBidsViewModel : Job
  {
    public int BidId { get; set; }
  }
}
