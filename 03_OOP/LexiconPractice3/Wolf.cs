namespace LexiconPractice3;

class Wolf : Animal
{
    public bool IsPackLeader { get; set; }

    public Wolf(string name, double weight, int age)
    {
        Name = name;
        Weight = weight;
        Age = age;
        IsPackLeader = false;
    }

    public override void DoSound()
    {
        Console.WriteLine($"{Name} howls!");
    }

    public override string Stats()
    {
        return base.Stats() + $", Is Pack Leader: {IsPackLeader}";
    }
}