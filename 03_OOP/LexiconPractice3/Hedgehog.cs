namespace LexiconPractice3;

class Hedgehog : Animal
{
    public int NrOfSpikes { get; set; }

    public Hedgehog(string name, double weight, int age)
    {
        Name = name;
        Weight = weight;
        Age = age;
        NrOfSpikes = 5000;
    }

    public override void DoSound()
    {
        Console.WriteLine($"{Name} makes hedgehog noises!");
    }

    public override string Stats()
    {
        return base.Stats() + $", Number of Spikes: {NrOfSpikes}";
    }
}