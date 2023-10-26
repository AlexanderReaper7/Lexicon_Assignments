namespace LexiconPractice3;

class Dog : Animal
{
    public string Breed { get; set; }

    public Dog(string name, double weight, int age)
    {
        Name = name;
        Weight = weight;
        Age = age;
        Breed = "Unknown";
    }

    public override void DoSound()
    {
        Console.WriteLine($"{Name} barks!");
    }

    public override string Stats()
    {
        return base.Stats() + $", Breed: {Breed}";
    }

    public string CustomMethod()
    {
        return "This is a custom method for Dog.";
    }
}