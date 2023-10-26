using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Personalregister;

public class ConsoleCommand
{
    public string Keyword { get; }
    private readonly string _description;
    private readonly Action _action;

    public ConsoleCommand(string keyword, string description, Action action)
    {
        // throw if keyword is more than one word
        if (keyword.Split().Length != 1)
        {
            throw new ArgumentException("Keyword must be one word.");
        }
        Keyword = keyword;
        _description = description;
        _action = action;
    }


    public void Invoke()
    {
        _action.Invoke();
    }
    public override string ToString()
    {
        return $"{Keyword} - {_description}";
    }
    /// <summary>
    /// Returns a KeyValuePair with the keyword as key and the ConsoleCommand as value.
    /// </summary>
    /// <param name="c"></param>
    public static implicit operator KeyValuePair<string, ConsoleCommand>(ConsoleCommand c) => new(c.Keyword, c);
}