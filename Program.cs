using Dotnet.Service;
using Dotnet;
using Dotnet.Model;

const int Min = 8;
const int Max = 30;


ICommandService commandService = new CommandService();
UserService userService = new UserService();

string? name1 = commandService.PromptUserInput("Player #1 name:");
User user1 = userService.Register(name1);

string? name2 = commandService.PromptUserInput("Player #2 name:");
User user2 = userService.Register(name2);

string? allowedSymbols = commandService.PromptUserInput($"Enter the word of {Min}-{Max} letters:");

while (!(Utils.IsInitialWordValid(allowedSymbols, Min, Max)))
{
    allowedSymbols = commandService.PromptUserInput($"Invalid input. Please enter a word of {Min}-{Max} symbols length containing only letters.");
}

GameService game = new(userService, commandService, user1, user2, allowedSymbols);

bool shouldContinue;
do
{
    shouldContinue = game.PlayRound();
}
while (shouldContinue);

Console.ReadKey();
