using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace Personalregister;

public class ConsoleManager : IUI
{
    public int? GetMenuChoiceByIndex(string[] options)
    {
        // print all people with index
        for (int i = 0; i < options.Length; i++)
        {
            Console.WriteLine($"({i}) {options[i]}");
        }
        // get input from user for index
        uint index = InputPrompt<uint>("Enter index: ");
        while (true)
        {
            if (index < options.Length)
            {
                Console.WriteLine($"Selected {options[(int)index]}...");
                return (int)index;
            }

            Console.WriteLine("Invalid input, try again or leave empty to abort.");
            uint? input = InputPrompt<uint?>("Enter index: ");
            if (input is null)
            {
                Console.WriteLine("Aborting...");
                return null;
            }
        }
    }

    public T GetMenuChoiceByIndexOrKeyword<T>(KeyValuePair<string, T>[] options)
    {
        // print all keywords with index
        for (var i = 0; i < options.Length; i++)
        {
            var option = options[i];
            Console.Write($"({i}) {option}");
        }

        while (true)
        {
            string input = InputPrompt<string>("Enter command by index or keyword: ");
            if (input == "") throw new Exception("User aborted.");
            // by index
            if (uint.TryParse(input, out uint index) && index < options.Length)
            {
                return options[(int)index].Value;
            }
            // by keyword
            else
            {
                foreach (var keyValuePair in options)
                {
                    if (keyValuePair.Key == input)
                    {
                        return keyValuePair.Value;
                    }
                }
            }
            Console.WriteLine("Invalid input, try again or leave empty to abort.");
        }
    }


    /// <summary>
    /// Creates a new T by prompting the user for input for all properties.
    /// </summary>
    public T CreateFromConsolePrompts<T>() where T : new()
    {
        // get input from user for all properties
        var output = new T();
        var properties = typeof(T).GetProperties().ToList();

        foreach (var property in properties)
        {
            var propType = Type.GetTypeCode(property.PropertyType);

            if (propType == TypeCode.String && property.CanWrite)
            {
                property.SetValue(output, InputPrompt<string>($"{property.Name}: "));
            }
        }
        return output;
    }

    /// <summary>
    /// Prompts the user for input and tries to parse it to T.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="prompt"></param>
    /// <returns>a valid T</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public T InputPrompt<T>(string prompt)
    {
        Console.WriteLine(prompt);
        var input = Console.ReadLine();
        // try to parse input to T
        try
        {
            return (T)Convert.ChangeType(input, typeof(T)) ?? throw new InvalidOperationException();
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid input, try again.");
            return InputPrompt<T>(prompt);
        }
    }

    public void PrintVersion()
    {
        Console.WriteLine($"Personalregister v{Assembly.GetExecutingAssembly().GetName().Version} by Alexander Öberg\n");
    }

    public bool PromptLoadRegister()
    {
        return InputPrompt<string>("Load previous register? (y/n) Otherwise creating a new register.").Equals("y", StringComparison.CurrentCultureIgnoreCase);
    }
}

