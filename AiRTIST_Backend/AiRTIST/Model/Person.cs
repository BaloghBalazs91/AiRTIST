using AiRTIST.Enum;
namespace AiRTIST.Model;

public class Person
{
    public string Name { get; set; }
    public string NickName { get; set; }
    public int? Age { get; set; }
    public string Profession { get; set; }
    public List<string> Hobbies { get; set; }
    public List<PositiveTraits>? PositiveTraits { get; set; }
    public List<NegativeTraits>? NegativeTraits { get; set; }

    public Person(string name, string nickName, int age, string profession, List<string> hobbies, List<PositiveTraits> positiveTraits, List<NegativeTraits> negativeTraits)
    {
        Name = name;
        NickName = nickName;
        Age = age;
        Profession = profession;
        Hobbies = hobbies;
        PositiveTraits = positiveTraits;
        NegativeTraits = negativeTraits;

    }
}
