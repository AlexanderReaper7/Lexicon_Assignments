namespace LexiconPractice3;

class Worm : Animal
{
    public bool IsPoisonous { get; set; }

    public Worm(string name, double weight, int age)
    {
        Name = name;
        Weight = weight;
        Age = age;
        IsPoisonous = false;
    }

    public override void DoSound()
    {
        Console.WriteLine($"{Name} squirms silently.");
    }

    public override string Stats()
    {
        return base.Stats() + $", Is Poisonous: {IsPoisonous}";
    }
}