namespace SkolProjekt;
class Kund
{
    public int Id { get; set; }
    public string Förnamn { get; set; }
    public string Efternamn { get; set; }
    public string Adress { get; set; }
    public int Ålder { get; set; }
    public string Postnummer { get; set; }
    public string Land { get; set; }
    public string Email { get; set; }
    public string Användarnamn { get; set; }
    public string Salt { get; set; }
    //public bool Admin { get; set; } TODO adminläge 
}

class Produkt()
{
    public int Id { get; set; }
    public string Artistnamn { get; set; }
    public string Albumnamn { get; set; }
    public string Skivbolag { get; set; }
    public int Releasedatum { get; set; }
    public string Genre { get; set; }
    public string Format { get; set; }
    public decimal Pris { get; set; }
    public decimal Inköpspris { get; set; }
    public bool Begagnad { get; set; }
    public string Skick { get; set; }
    public string Beskrivning { get; set; }
    public int Lagersaldo { get; set; }
}

class Order()
{
    public int Id { get; set; }
    public int KundId { get; set; }
    public DateTime Datum { get; set; }
    public decimal Summa { get; set; }
    public int StatusId { get; set; }
}

class Status()
{
    public int Id { get; set; }
    public string Namn { get; set; }
}

class OrderDetaljer() // plural?
{
    public int Id { get; set; }
    public int ProduktId { get; set; }
    public int RabattId { get; set; }
    public int OrderId { get; set; }
    public int Antal { get; set; }
}

class Retur()
{
    public int Id { get; set; }
    public int OrderDetaljerId { get; set; }
    public string Orsak { get; set; }
    public DateTime Datum { get; set; }
    public int Antal { get; set; }
}

class Rabatt()
{
    public int Id { get; set; }
    public decimal Värde { get; set; }
    public string Typ { get; set; }
}

class Kampanj()
{
    public int Id { get; set; }
    public string Namn { set; get; }
    public DateTime Start { get; set; }
    public DateTime Slut { get; set; }
    public string Beskrivning { get; set; }
    public bool Status { get; set; }
    public int RabattId { get; set; }
}
