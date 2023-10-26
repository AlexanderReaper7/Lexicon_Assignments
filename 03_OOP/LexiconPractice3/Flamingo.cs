namespace LexiconPractice3;

class Flamingo : Bird
{
    public string Color { get; set; }

    public Flamingo(string name, double weight, int age)
        : base(name, weight, age)
    {
        Color = "Pink";
    }

    public override string Stats()
    {
        return base.Stats() + $", Color: {Color}";
    }
}