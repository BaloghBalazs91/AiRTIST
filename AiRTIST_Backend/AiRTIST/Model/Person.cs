using AiRTIST.Enum;
namespace AiRTIST.Model;

public class Person
{
    public string Name { get; set; }
    public string NickName { get; set; }
    public Language Language { get; set; }
    public int? Age { get; set; }
    public Occasion Occasion { get; set; }
    public string Profession { get; set; }
    public List<string> Hobbies { get; set; }
    public List<PositiveTrait>? PositiveTraits { get; set; }
    public List<NegativeTrait>? NegativeTraits { get; set; }

    public Person(string name, string nickName,Language language, int age, Occasion occasion, string profession, List<string> hobbies, List<PositiveTrait> positiveTraits, List<NegativeTrait> negativeTraits)
    {
        Name = name;
        NickName = nickName;
        Language = language;
        Age = age;
        Occasion = occasion;
        Profession = profession;
        Hobbies = hobbies;
        PositiveTraits = positiveTraits;
        NegativeTraits = negativeTraits;
    }
}
