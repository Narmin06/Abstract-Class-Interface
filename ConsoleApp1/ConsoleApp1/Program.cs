// Electronics Object
Electronics electronics = new Electronics("Smartphone", 1200, 10, 24);
electronics.Show();
electronics.ApplyDiscount(10);
Console.WriteLine($"Shipping cost: {electronics.CalculateShipCost()} AZN");
electronics.Sell(1);
electronics.Ship();

Console.WriteLine();

// Clothing Object
Clothing clothing = new Clothing("T-shirt", 20, 50, "M", "Black");
clothing.Show();
clothing.ApplyDiscount(10);
Console.WriteLine($"Shipping cost: {clothing.CalculateShipCost()} AZN");
clothing.Sell(2);
clothing.Ship();

Console.WriteLine();

// Book Object
Book book = new Book("C# Dersliyi", 30, 25, "John Doe", 450);
book.Show();
Console.WriteLine($"Shipping cost: {book.CalculateShipCost()} AZN");
book.Sell(3);
book.Ship();

abstract class Product
{
    public string? ProductName { get; set; }
    public decimal ProductPrice {  get; set; }
    public int ProductCount { get; set; }

    public Product(string name,decimal price, int count)
    {
        ProductName = name;
        ProductPrice = price;
        ProductCount = count;
    }

    public abstract void Show();
    public virtual void Sell(int quantity)
    {
        if(ProductCount>= quantity) {
            ProductCount -= 1;
            Console.WriteLine($"{quantity} {ProductName} selled");
        }
        else
        {
            Console.WriteLine("There is not enough product in the warehouse.");
        }
    }
}
interface IDiscountable
{
    void ApplyDiscount(decimal discountPercentage);
}
interface IShippable
{
    decimal CalculateShipCost();
    void Ship();
}
class Electronics : Product, IDiscountable, IShippable
{
    public int WarrantyMonths {  get; set; }
    public Electronics(string name, decimal price, int count, int warrantyMonths) : base(name, price, count)
    {
        WarrantyMonths = warrantyMonths;
    }
    public override void Show()
    {
        Console.WriteLine($@"Electronics: {ProductName} 
Price: {ProductPrice} AZN
Count: {ProductCount}
WarrantyMonths: {WarrantyMonths} ay ");
    }

    public void ApplyDiscount(decimal discountPercentage)
    {
        ProductPrice -= (ProductPrice * discountPercentage)/100;
        Console.WriteLine($"New Price: {ProductPrice} AZN");
    }

    public decimal CalculateShipCost()
    {
        return 10 + (ProductPrice * 0.01m);
;    }

    public void Ship()
    {
        Console.WriteLine($"{ProductName} send");
    }
}
class Clothing : Product, IDiscountable, IShippable
{
    public string Size { get; set; }
    public string Color {  get; set; }
    public Clothing(string name, decimal price, int count,string size, string color) : base(name, price, count)
    {
        Size = size;    
        Color = color;  
    }

    public override void Show()
    {
        Console.WriteLine($@"Clothings: {ProductName}
Price: {ProductPrice} AZN
Count: {ProductCount}
Size: {Size}
Color:{Color}");
    }

    public void ApplyDiscount(decimal discountPercentage)
    {
        ProductPrice -= (ProductPrice * discountPercentage) / 100;
        Console.WriteLine($"New Price: {ProductPrice} AZN");
    }

    public decimal CalculateShipCost()
    {
        return 5;
    }

    public void Ship()
    {
        Console.WriteLine($"{ProductName} send");
    }
}
class Book : Product, IShippable
{
    public string AuthorName { get; set; }
    public int PageCount {  get; set; }

    public Book(string name, decimal price, int count,string author,int page) : base(name, price, count)
    {
        AuthorName = author;
        PageCount = page;
    }

    public override void Show()
    {
        Console.WriteLine($@"Books: {ProductName}, 
Price: {ProductPrice} AZN
Count: {ProductCount}
AuthorName: {AuthorName}
PageCount:{PageCount}");
    }

 
    public decimal CalculateShipCost()
    {
        return 3;
    }

    public void Ship()
    {
        Console.WriteLine($"{ProductName} send");
    }
}
