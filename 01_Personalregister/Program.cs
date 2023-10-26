using System.Reflection;

namespace Personalregister;

internal class Program
{
    public static IUI UI = new ConsoleManager();
    public static Register Register = new();
    static void Main(string[] args)
    {
        UI.PrintVersion();
        if (UI.PromptLoadRegister())
        {
            Register.Load(out Register);
        }
        var commands = new List<ConsoleCommand>
        {
            new("Add", "Add a person to the register.", Register.AddPerson),
            new("Edit", "Edit a property of a person in the register.", Register.Edit),
            new("Remove", "Remove a person from the register.", Register.RemovePerson),
            new("List", "List all people in the register.", Register.ListPeople),
            new("Save", "Save the register to file.", () => Register.Save()),
            new("Load", "Reload the register from file.", () => Register.Load(out Register)),
            new("Exit", "Saves and exits the program.", Exit)
        };
        // add the exit method to the application exit event
        AppDomain.CurrentDomain.ProcessExit += (s, e) => { Console.WriteLine(); Exit(); };
        while (true)
        {
            UI.GetMenuChoiceByIndexOrKeyword(commands.Select(x => (KeyValuePair<string, ConsoleCommand>)x).ToArray())!
                .Invoke();
        }
    }

    static void Exit()
    {
        Register.Save();
        Console.WriteLine("Exiting...");
        Environment.Exit(0);
    }
}