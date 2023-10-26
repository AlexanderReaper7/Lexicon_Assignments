namespace LexiconPractice3;

class Person
{
    private int _age;
    private string _fName;
    private string _lName;
    private double _height;
    private double _weight;

    public int Age
    {
        get { return _age; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Age must be greater than 0.");
            }
            _age = value;
        }
    }

    public required string FName
    {
        get { return _fName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 2 || value.Length > 10)
            {
                throw new ArgumentException("First name must be between 2 and 10 characters.");
            }
            _fName = value;
        }
    }

    public required string LName
    {
        get { return _lName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3 || value.Length > 15)
            {
                throw new ArgumentException("Last name must be between 3 and 15 characters.");
            }
            _lName = value;
        }
    }

    public double Height { get; set; }
    public double Weight { get; set; }
}