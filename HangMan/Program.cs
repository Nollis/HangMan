// See https://aka.ms/new-console-template for more information
using System.Text;
using static HangMan.CustomExceptions;

string[] ordlista = new string[10];
ordlista[0] = "blåbär";
ordlista[1] = "orangutang";
ordlista[2] = "pandemi";
ordlista[3] = "amerika";
ordlista[4] = "abborre";
ordlista[5] = "trollslända";
ordlista[6] = "zebra";
ordlista[7] = "kylskåp";
ordlista[8] = "köttbullar";
ordlista[9] = "kex";

var keepAlive = true;
Boolean alreadyUsed = true;
char letterToAdd = ' ';
int nrGiss = 10;
Random randGen = new Random();
var rnd = randGen.Next(0, 9);
string hemligtOrd = ordlista[rnd];
StringBuilder guessedLetters = new StringBuilder();

char[] gissning = new char[hemligtOrd.Length];
for (int p = 0; p < hemligtOrd.Length; p++)
{
    gissning[p] = '_';
}


while (keepAlive && nrGiss > 0)
{
    alreadyUsed = true;

    Console.Clear();
    Console.WriteLine($"Antal gissningar kvar: {nrGiss}");
    Console.WriteLine($"Felaktiga bokstäver: {guessedLetters}");
    Console.WriteLine(gissning);
    Console.WriteLine("1: Gissa en bokstav \n" +
        "2: Gissa hela ordet \n");
    ConsoleKey input = Console.ReadKey().Key;
    switch (input)
    {
        case ConsoleKey.D1:
        case ConsoleKey.NumPad1:
            Console.Clear();
            
            AddLetter();
            break;
        case ConsoleKey.D2:
        case ConsoleKey.NumPad2:
            Console.Clear();
            testWord();
            break;
        default:
            Console.Clear();
            Console.WriteLine("Inte ett giltigt val.");
            break;
    }

    checkGuess();

}

if (nrGiss == 0)
{
    Console.Clear();
    Console.WriteLine("Tyvärr tog dina gissningar slut!");
}

void AddLetter()
{
    while (alreadyUsed)
    {
        Console.Write("Gissa på en bokstav: ");
        try
        {
            letterToAdd = char.Parse(Console.ReadLine());
            bool isAlpha = letterToAdd.ToString().All(Char.IsLetter);
            if (isAlpha)
                ;
            else
                throw new NonCharacterException();
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.ReadKey();
            Console.Clear();
        }
        catch (NonCharacterException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.ReadKey();
            Console.Clear();
        }
        checkUsedLetter();
    }
}

void testWord()
{
    Console.Write("Gissa hela ordet: ");
    string wordGuess = Console.ReadLine();
    if (wordGuess == hemligtOrd)
    {
        Console.Clear();
        Console.WriteLine("Grattis, Du gissade rätt!");
        Console.ReadKey();
        keepAlive = false;
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Tyvärr, Du gissade fel!");
        Console.ReadKey();
        nrGiss--;
    }
}

void checkGuess()
{
    if (hemligtOrd.ToString().Contains(letterToAdd))
    {
        for (int i = 0; i < hemligtOrd.Length; i++)
        {
            if (hemligtOrd[i] == letterToAdd)
            {
                gissning[i] = letterToAdd;
            }
        }
    }
    else
    {
        if (!alreadyUsed)
        {
          guessedLetters.Append(letterToAdd);
        }
        nrGiss--;
    }
}

void checkUsedLetter()
{
    if (guessedLetters.ToString().Contains(letterToAdd))
    {
        alreadyUsed = true;
        Console.Clear();
        Console.WriteLine("Redan använd bokstav!");
    }
    else
    {
        alreadyUsed = false;
    }
}