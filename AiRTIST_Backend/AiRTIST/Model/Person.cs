using AiRTIST.Enum;
namespace AiRTIST.Model;

public class Person
{
    public string Name { get; set; }
    public string NickName { get; set; }
    public int? Age { get; set; }
    public Occasion Occasion { get; set; }
    public string Profession { get; set; }
    public List<string> Hobbies { get; set; }
    public List<PositiveTrait>? PositiveTraits { get; set; }
    public List<NegativeTrait>? NegativeTraits { get; set; }
    public string InterestingStory { get; set; }

    public Person(string name, string nickName, int age, Occasion occasion, string profession, List<string> hobbies, List<PositiveTrait> positiveTraits, List<NegativeTrait> negativeTraits, string interestingStory)
    {
        Name = name;
        NickName = nickName;
        Age = age;
        Occasion = occasion;
        Profession = profession;
        Hobbies = hobbies;
        PositiveTraits = positiveTraits;
        NegativeTraits = negativeTraits;
        InterestingStory = interestingStory;
    }
}
