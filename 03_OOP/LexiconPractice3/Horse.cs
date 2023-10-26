namespace LexiconPractice3;

class Horse : Animal
{
    public string Color { get; set; }

    public Horse(string name, double weight, int age)
    {
        Name = name;
        Weight = weight;
        Age = age;
        Color = "Brown";
    }

    public override void DoSound()
    {
        Console.WriteLine($"{Name} says neigh!");
    }

    public override string Stats()
    {
        return base.Stats() + $", Color: {Color}";
    }
}