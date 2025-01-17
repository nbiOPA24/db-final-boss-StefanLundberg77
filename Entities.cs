namespace ProjektDb;
class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; } //  date i tabell
    public string Address { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Email { get; set; }
    public string Username { get; set; } // unik?
    //public string Password { get; set; } // dölj när salt är fixat
    public string Salt { get; set; } //generera salt
    public bool IsAdmin { get; set; } //TODO adminläge 
    //public datetime DateOfRegistry { get; set; } ska man ha detta?
}

class Product()
{
    public int Id { get; set; }
    public string ArtistName { get; set; } 
    public string AlbumName { get; set; } 
    public string RecordLabel { get; set; } 
    public int ReleaseDate { get; set; } 
    public string Genre { get; set; } 
    public string Format { get; set; } 
    public decimal Price { get; set; } 
    public decimal PurchasePrice { get; set; } 
    public bool Used { get; set; } 
    public string Condition { get; set; } 
    public int StockBalance { get; set; } 
    public string Description { get; set; } 
}

class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalAmount { get; set; }
    public int OrderStatusId { get; set; }
}

class OrderStatus
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class OrderDetails // Singular form is acceptable
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int DiscountId { get; set; }
    public int OrderId { get; set; }
    public int Quantity { get; set; }
}
class ReturnOrder
{
    public int Id { get; set; }
    public int OrderDetailsId { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }
    public int ReturnQuantity { get; set; }
}

class Discount
{
    public int Id { get; set; }
    public decimal Value { get; set; }
    public string Type { get; set; }
}

class Campaign
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Start { get; set; } // = DateTime.Now;
    public DateTime End { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public int DiscountId { get; set; }
}