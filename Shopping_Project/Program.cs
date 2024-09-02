using ConsoleApp1.Models;
using Shopping_Project.Services;
/***
CustomerService c = new();
ProductService p = new();

Customers customer = new()
{
    first_name = "Mehrob",
    last_name = "Rahman",
    email = "mehrob@example.com",
    phonenumber = "09123456789",
    address = "Street 1, City"
};


Customers customer2 = new()
{
    first_name = "new John",
    last_name = "new Doe",
    email = "new john@example.com",
    phonenumber = "09876543210",
    address = "Street 2, City"
};



Product product1 = new()
{
    ProductName = "Iphone X",
    Description = "Good",
    Price = 10,
    Quantity = 5
};

Product product2 = new()
{
    ProductName = "Iphone 15",
    Description = "best",
    Price = 100,
    Quantity = 50
};


c.CreateCustomer(customer);
c.CreateCustomer(customer2);
p.CreatePRoduct(product1);
p.CreatePRoduct(product2);
**/

DiscountService d = new();

d.CreateDiscountTable();
