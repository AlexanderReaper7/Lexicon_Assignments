namespace LexiconPractice3;

class PersonHandler
{
    public void SetAge(Person person, int age)
    {
        person.Age = age;
    }

    public void SetFName(Person person, string fname)
    {
        person.FName = fname;
    }

    public void SetLName(Person person, string lname)
    {
        person.LName = lname;
    }

    public void SetHeight(Person person, double height)
    {
        person.Height = height;
    }

    public void SetWeight(Person person, double weight)
    {
        person.Weight = weight;
    }

    public Person CreatePerson(int age, string fname, string lname, double height, double weight)
    {
        var person = new Person
        {
            Age = age,
            FName = fname,
            LName = lname,
            Height = height,
            Weight = weight
        };
        return person;
    }
}