namespace LexiconPractice3;

class Swan : Bird
{
    public int NeckLength { get; set; }

    public Swan(string name, double weight, int age)
        : base(name, weight, age)
    {
        NeckLength = 50;
    }

    public override string Stats()
    {
        return base.Stats() + $", Neck Length: {NeckLength}";
    }
}