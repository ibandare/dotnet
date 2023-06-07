using Dotnet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.Service
{
    internal class CommandService : ICommandService
    {
        public void DisplayScore(List<User> users)
        {
            foreach (User user in users)
            {
                Console.WriteLine($"{user.Name} - Wins:{user.Wins}, Losses:{user.Losses}");
            }
        }

        public void ShowWords(List<string?> words)
        {
            Console.WriteLine(string.Join(", ", words));
        }

        public string? PromptUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
