namespace api.Models
{
    public class UsersModel
    {
       public int Id { get; set; } 
       public string fullName { get; set; } 
       
       
       public string email { get; set; } 
       private string phoneNumber { get; set; }
       private string cpf { get; set; }
       private string address { get; set; }
       private string password { get; set; }   
    }
}