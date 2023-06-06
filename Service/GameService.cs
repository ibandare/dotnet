using Dotnet.Model;

namespace Dotnet.Service
{
    internal class GameService
    {
        private readonly UserService userService;
        private readonly User user1;
        private readonly User user2;
        private readonly string? allowedSymbols;
        private readonly List<string?> words = new List<string?>();

        public GameService(UserService userService, User user1, User user2, string? allowedSymbols)
        {
            this.userService = userService;
            this.user1 = user1;
            this.user2 = user2;
            this.allowedSymbols = allowedSymbols;
        }

        private bool MakeTurn(User user)
        {
            string? input = ReadCommand(user);
            if (Utils.IsWordValid(allowedSymbols, input))
            {
                return true;
            }

            userService.MakeLooser(user);
            User winner = user == user1 ? user2 : user1;
            userService.MakeWinner(winner);

            Console.WriteLine($"{user.Name} has lost the game!");
            return false;
        }

        private string? ReadCommand(User user)
        {
            string? input = PromptUserInput(user);

            while (input != null && input.StartsWith('/'))
            {
                switch (input)
                {
                    case "/show-words":
                        ShowWords();
                        break;
                    case "/score":
                        DisplayScore(new List<User>() { user1, user2 });
                        break;
                    case "/total-score":
                        List<User> users = userService.FindAll();
                        DisplayScore(users);
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
                input = PromptUserInput(user);
            }

            words.Add(input);

            return input;
        }

        private static string? PromptUserInput(User user)
        {
            Console.WriteLine($"\n{user.Name}'s word:");
            return Console.ReadLine();
        }

        private static void DisplayScore(List<User> users)
        {
            foreach (User user in users)
            {
                Console.WriteLine($"{user.Name} - Wins:{user.Wins}, Losses:{user.Losses}");
            }
        }

        private void ShowWords()
        {
            Console.WriteLine(string.Join(", ", words));
        }

        public bool PlayRound()
        {
            return MakeTurn(user1) && MakeTurn(user2);
        }

    }
}
