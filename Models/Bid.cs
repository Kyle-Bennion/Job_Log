namespace JobLog.Models
{
  public class Bid
  {
    public int Id { get; set; }
    public int JobId { get; set; }
    public int ContractorId { get; set; }
    public double Estimate { get; set; }

  }
}