using OliveShop.Data;
using System.Linq;
public interface IUserRepositori
{
    void AddUser(User user);
    bool ISExistEmail(string Email);
    //User loinforuser(string Email,string password);
    User loginforuser(string Email, string password);
} 



public class UserRepositori:IUserRepositori
{
    private OliveshopContext _context;
    public UserRepositori(OliveshopContext context)
    {
        _context=context;
    }

    public void AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public bool ISExistEmail(string Email)
    {
        return _context.Users.Any(e=>e.Email==Email);
    }

    public User loginforuser(string Email, string password)
    {
       return _context.Users.SingleOrDefault(u => u.Email == Email && u.Password == password);
    }

    //public User loinforuser(string Email, string password)
    //{
    //    return _context.Users.SingleOrDefault(e=>e.Email==Email && e.Password==password);
    //}
}