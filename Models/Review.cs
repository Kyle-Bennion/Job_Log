using System.ComponentModel.DataAnnotations;

namespace JobLog.Models
{
  public class Review
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    [Range(1, 5)]
    public int Rating { get; set; }
    public string Date { get; set; }
    public int ContractorId { get; set; }
  }
}