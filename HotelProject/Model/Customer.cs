namespace HotelProject.Model;

public class Customer
{
    public string id { get; set; }
    public string name { get; set; }
    public string gender { get; set; }
    public int age { get; set; }

    public int allowedRoom { get; set; }

    public string identityProof { get; set; }
    public string phone { get; set; }

    public PaymentDetails paymentDetails { get; set; }

    public Boolean isActive { get; set; }

}

public class PaymentDetails
{
    public string paymentMethod { get; set; }
    public string amount { get; set; }
}



