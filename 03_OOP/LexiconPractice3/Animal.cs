namespace LexiconPractice3;

abstract class Animal
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public int Age { get; set; }

    public abstract void DoSound();

    public virtual string Stats()
    {
        return $"Name: {Name}, Weight: {Weight}, Age: {Age}";
    }
    // 14. F: Om alla djur behöver det nya attributet, vart skulle man lägga det då?
    // I Animal-klassen. (Denna)
}