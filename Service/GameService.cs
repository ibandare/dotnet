using Dotnet.Model;

namespace Dotnet.Service
{
    internal class GameService
    {
        private readonly UserService _userService;
        private readonly ICommandService _commandService;
        private readonly User _user1;
        private readonly User _user2;
        private readonly string? _allowedSymbols;
        private readonly List<string?> words = new List<string?>();

        public GameService(UserService userService, ICommandService commandService, User user1, User user2, string? allowedSymbols)
        {
            this._userService = userService;
            this._commandService = commandService;
            this._user1 = user1;
            this._user2 = user2;
            this._allowedSymbols = allowedSymbols;
        }

        private bool MakeTurn(User user)
        {
            string? input = ReadCommand(user);
            if (Utils.IsWordValid(_allowedSymbols, input))
            {
                return true;
            }

            _userService.MakeLooser(user);
            User winner = user == _user1 ? _user2 : _user1;
            _userService.MakeWinner(winner);

            Console.WriteLine($"{user.Name} has lost the game!");
            return false;
        }

        private string? ReadCommand(User user)
        {
            string? input = _commandService.PromptUserInput($"\n{user.Name}'s word:");

            while (input != null && input.StartsWith('/'))
            {
                switch (input)
                {
                    case "/show-words":
                        _commandService.ShowWords(words);
                        break;
                    case "/score":
                        _commandService.DisplayScore(new List<User>() { _user1, _user2 });
                        break;
                    case "/total-score":
                        List<User> users = _userService.FindAll();
                        _commandService.DisplayScore(users);
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
                input = _commandService.PromptUserInput($"\n{user.Name}'s word:");
            }

            words.Add(input);

            return input;
        }

        public bool PlayRound()
        {
            return MakeTurn(_user1) && MakeTurn(_user2);
        }

    }
}
