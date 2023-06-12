using Dotnet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.Service
{
    internal interface ICommandService
    {
        void DisplayScore(List<User> users);
        string? PromptUserInput(string message);
        void ShowWords(List<string?> words);
    }
}
