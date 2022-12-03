namespace HotelProject.Model;

public class Customer
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }   
    public int Age { get; set; }
        
    public int AllowedRoom { get; set; }        

    public string IdentityProof { get; set; }
    public string Phone { get; set; }   

    public Boolean IsActive { get; set; }

}



