namespace LexiconPractice3;

class Wolfman : Wolf, IPerson
{
    public Wolfman(string name, double weight, int age)
        : base(name, weight, age)
    {
    }

    public string Talk()
    {
        return $"{Name} says, 'I am a Wolfman!'";
    }
}