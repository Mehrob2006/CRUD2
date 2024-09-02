namespace Shopping_Project.Services;


public class SqlCommand
{
    public static string connectionstring =
        "Server = localhost; port = 5432; username = postgres; database = shopping; password = Progrmmer.33";

    public static string CreateProductTable = @"create table Product
                                        (
                                           Id serial primary key ,
                                           ProductName varchar not null,
                                           Description varchar,
                                           Price int not null,
                                           Quantity int not null
                                         );";
    public static string InsertToProduct = "insert into Product (ProductName, Description, Price, Quantity) " +
                                           "values (@name, @description, @price, @quantity)";
    
    public static string UpdateProduct = "update Product set ProductName=@name, Description=@description, Price=@price, Quantity=@quantity where Id=@id";
    
    public static string DeleteProduct = "delete from Product where Id=@id";
    
    public static string GetProductById = "select * from Product where Id=@id";

    public static string GetAllProducts = "select * from Product";
    
    
    
    public static string CreateCustomerTable = @"create table Customers
                                        (
                                           Id serial primary key ,
                                           first_name varchar not null,
                                           last_name varchar not null,
                                           email varchar not null,
                                           phonenumber varchar not null,
                                           address varchar not null
                                         );";
    
    public static string InsertToCustomer = "insert into customers (first_name, last_name, email, phonenumber, address) " +
                                           "values (@name, @lastname, @email, @phonenumber, @address);";

    public static string GetAllCustomers = "select * from customers";
    
    public static string GetCustomerById = "select * from customers where Id=@id";
    
    public static string UpdateCustomer = "update customers set first_name=@name, last_name=@lastname, email=@email, phonenumber=@phonenumber, address=@address where Id=@id";

    public static string DeleteCustomer = "delete from customers where Id=@id";
    
    public static string CreateOrderTable = @"create table Orders
                                        (
                                           Id serial primary key ,
                                           Customer_Id int references customers(Id),
                                           Product_id int references Product(Id),
                                           OrderDate date,
                                           TotalAmount int not null,
                                           Status varchar
                                         );";
    
    public static string InsertToOrders = "insert into orders (OrderDate, TotalAmount, Status, Product_Id, Customer_Id) " +
                                            "values (@orderdate, @totalamount, @status, @productid, @customerid);";
    
    public static string GetAllOrders = "select * from orders";
    
    public static string GetOrderById = "select * from orders where Id=@id";
    
    public static string UpdateOrder = "update orders set Product_Idme=@productid, Customer_Id=@customerid, OrderDate=@orderdate, TotalAmount=@totalamount, Status=@status where Id=@id";

    public static string DeleteOrder = "delete from orders where Id=@id";
    
    public static string CreateDiscountTable = @"create table discounts
                                        (
                                           Id serial primary key ,
                                           name varchar not null,
                                           start_date date not null,
                                           end_date date not null,
                                           percentage int not null
                                         );";
    
    public static string InsertToDiscounts = "insert into discounts (name, start_date, end_date, percentage) " +
                                          "values (@name, @start, @end, @percentage);";
    
    public static string GetAllDiscounts = "select * from discounts";
    
    public static string GetDiscountById = "select * from discounts where Id=@id";
    
    public static string UpdateDiscount = "update discounts set name=@name, start_date=@start_date, end_date=@end_date, percentage=@percentage where Id=@id";

    public static string DeleteDiscount = "delete from discounts where Id=@id";
}