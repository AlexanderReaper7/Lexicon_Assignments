namespace LexiconPractice3;

class Bird : Animal
{
    public double WingSpan { get; set; }

    public Bird(string name, double weight, int age)
    {
        Name = name;
        Weight = weight;
        Age = age;
        WingSpan = 0.5;
    }

    public override void DoSound()
    {
        Console.WriteLine($"{Name} chirps!");
    }

    public override string Stats()
    {
        return base.Stats() + $", Wing Span: {WingSpan}";
    }
    // 13. F: Om vi under utvecklingen kommer fram till att samtliga fåglar behöver ett nytt attribut, i vilken klass bör vi lägga det?
    // I Bird-klassen. (Denna)
}