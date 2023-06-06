using Dotnet.Service;
using Dotnet;
using Dotnet.Model;

const int Min = 8;
const int Max = 30;



UserService userService = new UserService();

Console.WriteLine("Player #1 name:");
User user1 = userService.Register(Console.ReadLine());

Console.WriteLine("Player #2 name:");
User user2 = userService.Register(Console.ReadLine());

Console.WriteLine($"Enter the word of {Min}-{Max} letters:");

string? allowedSymbols = Console.ReadLine();

while (!(Utils.IsInitialWordValid(allowedSymbols, Min, Max)))
{
    Console.WriteLine($"Invalid input. Please enter a word of {Min}-{Max} symbols length containing only letters.");
    allowedSymbols = Console.ReadLine();
}

GameService game = new GameService(userService, user1, user2, allowedSymbols);

bool shouldContinue;
do
{
    shouldContinue = game.PlayRound();
}
while (shouldContinue);

Console.ReadKey();
