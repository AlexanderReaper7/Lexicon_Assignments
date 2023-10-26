namespace LexiconPractice3;

class Pelican : Bird
{
    public int BeakLength { get; set; }

    public Pelican(string name, double weight, int age)
        : base(name, weight, age)
    {
        BeakLength = 10;
    }

    public override string Stats()
    {
        return base.Stats() + $", Beak Length: {BeakLength}";
    }
}