namespace AiRTIST.Model;

public class User
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public User(string userName, string email, string password)
    {
        UserName = userName;
        Email = email;
        Password = password;
    }
}