using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personalregister;

internal interface IUI
{
    public int? GetMenuChoiceByIndex(string[] options);
    public T InputPrompt<T>(string prompt);
    void PrintVersion();
    public bool PromptLoadRegister();
    public T GetMenuChoiceByIndexOrKeyword<T>(KeyValuePair<string, T>[] options);
}