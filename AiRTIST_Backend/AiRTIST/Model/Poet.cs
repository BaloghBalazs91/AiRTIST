namespace AiRTIST.Model;

public class Poet
{
    
    public string GeneratedPoet { get; set; }
    public User User { get; set; }
    public int Rating { get; set; }
    public int Views { get; set; }

    public Poet(string generatedPoet, User user)
    {
        Rating = 0;
        Views = 0;
        GeneratedPoet = generatedPoet;
        User = user;
    }
}