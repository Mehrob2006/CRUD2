namespace ConsoleApp1.Models;

public class Discounts
{
    public int Id { get; set; }
    public string name { get; set; }
    public DateTime start_date { get; set; }
    public DateTime end_date { get; set; }
    public int percentage { get; set; }
}