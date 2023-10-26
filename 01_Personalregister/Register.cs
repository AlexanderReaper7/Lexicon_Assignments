using System.Text.Json;

namespace Personalregister;
[Serializable]  
public class Register : List<Person>
{
    const string DEFAULT_PATH = "register.json";
    private IUI UI;
    public void AddPerson()
    {
        Console.WriteLine("Adding a new person...");
        base.Add(ConsoleManager.CreateFromConsolePrompts());
    }

    public void RemovePerson()
    {
        Console.WriteLine("Select a person to remove...");
        var res = GetPersonByIndex();
        if (res is null)
        {
            return;
        }
        base.RemoveAt((int)res);
    }

    public void ListPeople()
    {
        Console.WriteLine("Listing all people...");
        for (int i = 0; i < Count; i++)
        {
            Console.WriteLine(base[i]);
        }
    }

    public void Edit()
    {
        throw new NotImplementedException();
    }
    public void Save(string path = DEFAULT_PATH)
    {
        Console.WriteLine($"Saving register to {path}...");
        string jsonString = JsonSerializer.Serialize(this);
        File.WriteAllText(path, jsonString);
    }
    public static void Load(out Register r, string path = DEFAULT_PATH)
    {
        try
        {
            Console.WriteLine($"Loading register from {path}...");
            var text = File.ReadAllText(path);
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
            r = JsonSerializer.Deserialize<Register>(text) ?? throw new ArgumentNullException();
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Failed to load register, proceeding with a new empty register.");
            r = new Register();
        }
    }
}