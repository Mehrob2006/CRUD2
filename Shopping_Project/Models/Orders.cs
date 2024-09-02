namespace ConsoleApp1.Models;

public class Orders
{
    public int Id { get; set; }
    public int Product_Id { get; set; }
    public int Customer_Id { get; set; }
    public DateTime OrderDate { get; set; }
    public int TotalAmount { get; set; }
    public string Status { get; set; }
}