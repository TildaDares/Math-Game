// See https://aka.ms/new-console-template for more information
var random = new Random();
var history = new List<string>();

void Menu()
{
    do
    {
        Console.WriteLine("Welcome to Math Game!");
        Console.WriteLine("Pick an option from the menu below. Select either 1, 2, 3 or 4: ");
        Console.WriteLine("1. What's the answer to the math question? ");
        Console.WriteLine("2. View your game history");
        Console.WriteLine("3. Press any key to exit...");
        
        var option = Console.ReadLine();
        switch (option)
        {
            case "1":
                MathOperationMenu();
                break;
            case "2":
                PrintHistory();
                break;
            default:
                return;
        }
    } while (true);
}

void MathOperationMenu()
{
    var signs = new[] {"*", "+", "-", "/"};
    var sign = "";
    do
    {
        Console.WriteLine("Enter a math operation (+, -, *, or /): ");
        sign = Console.ReadLine().Trim();
    } while (!signs.Contains(sign));

    MathOperation(sign);
}

void MathOperation(string sign)
{
    var firstNumber = 0;
    var secondNumber = 0;
    switch (sign)
    {
        case "+":
            do
            {
                firstNumber = random.Next();
                secondNumber = random.Next();
            } while ((long) firstNumber + (long) secondNumber >= int.MaxValue);
            
            Console.WriteLine($"What is the result of this operation: {firstNumber} + {secondNumber}");
            EvalGameResult(result: firstNumber + secondNumber);
            break; 
        case "-":
            firstNumber = random.Next();
            secondNumber = random.Next(0, firstNumber); // minus operations will only result in positive integers
            
            Console.WriteLine($"What is the result of this operation: {firstNumber} - {secondNumber}");
            EvalGameResult(result: firstNumber - secondNumber);
            break;
        case "*":
            do
            {
                firstNumber = random.Next();
                secondNumber = random.Next();
            } while ((long) firstNumber * (long) secondNumber >= int.MaxValue);
            
            Console.WriteLine($"What is the result of this operation: {firstNumber} * {secondNumber}");
            EvalGameResult(result: firstNumber * secondNumber);
            break;
        case "/":
            do
            {
                firstNumber = random.Next(1, 100);
                secondNumber = random.Next(1, firstNumber);
            } while (firstNumber % secondNumber != 0);
            
            Console.WriteLine($"What is the result of this operation: {firstNumber} / {secondNumber}");
            EvalGameResult(result: firstNumber / secondNumber);
            break;
    }

}

void PrintHistory()
{
    Console.WriteLine("\nGame History:");
    if (!history.Any())
    {
        Console.WriteLine("No history available.\n");
        return;
    }
    
    for (var i = 0; i < history.Count; i++)
    {
        Console.WriteLine($"Round {i + 1}: {history[i]}\n");
    }
}

void EvalGameResult(int result)
{
    var userAns = Console.ReadLine();
    var isValidInt = int.TryParse(userAns, out var userResult);
    if (!isValidInt || userResult != result)
    {
        Console.WriteLine($"Incorrect! The correct answer is {result}\n");
        history.Add("Lost");
    }
    else
    {
        Console.WriteLine($"CORRECT! You won this round!\n");
        history.Add("Won");
    }
}

Menu();