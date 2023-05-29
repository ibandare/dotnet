using WordsGame;

const int Min = 8;
const int Max = 30;


Console.WriteLine($"Enter the word of {Min}-{Max} letters:");

string allowedSymbols = Console.ReadLine();

while (!(Utils.isInitialWordValid(allowedSymbols, Min, Max)))
{
    Console.WriteLine($"Invalid input. Please enter a word of {Min}-{Max} symbols length containing only letters.");
    allowedSymbols = Console.ReadLine();
}

bool shouldContinue;
do
{
    shouldContinue = Utils.PlayRound(allowedSymbols);
}
while (shouldContinue);

Console.ReadKey();
