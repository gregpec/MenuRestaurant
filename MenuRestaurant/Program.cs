using MenuRestaurant;
using System;
using System.Text.RegularExpressions;

void RestaurantGradeAdded(object sender, EventArgs args) //delegat wprowadzenie oceny
{
    WritelineColor(ConsoleColor.Red, "New rating added!");
}
void EnterRestaurants(DishBase burger) //wprowadzenie danych 
{
    Regex regex = new Regex(@"^[a-zA-Z0-9ąćęłńóśźżĄĆĘŁŃÓŚŹŻ\-\._]+$"); //sprawdzenie poprawności nazw

    do
    {
        Console.WriteLine("Please insert restaurant's name: ");
        burger.Restaurantname = Console.ReadLine();
        if (regex.IsMatch(burger.Restaurantname))
        {


            Console.WriteLine("Name is properly!");
        }
        else
        {
            Console.WriteLine("Name is not properly");
        }
    } while (!regex.IsMatch(burger.Restaurantname));

    do
    {
        Console.WriteLine("Please insert restaurant's city: ");
        burger.Cityname = Console.ReadLine();
        if (regex.IsMatch(burger.Cityname))
        {
            Console.WriteLine("Name is properly!");
        }
        else
        {
            Console.WriteLine("Name is not properly");
        }
    } while (!regex.IsMatch(burger.Cityname));

    do
    {
        Console.WriteLine("Please insert restaurant's street: ");
        burger.Streetname = Console.ReadLine();
        if (regex.IsMatch(burger.Streetname))
        {
            Console.WriteLine("Name is properly!");
        }
        else
        {
            Console.WriteLine("Name is not properly");
        }
    } while (!regex.IsMatch(burger.Streetname));

    do
    {
        Console.WriteLine("Please insert restaurant's dish: Enter = Burger ");
        burger.Dishname = Console.ReadLine();
        if (regex.IsMatch(burger.Dishname))
        {
            Console.WriteLine("Name is properly!");
        }
        else if (burger.Dishname == "")
        {
            burger.Dishname = "Burger";
        }
        else
        {
            Console.WriteLine("Name is not properly");
        }
    } while (!regex.IsMatch(burger.Dishname));

    InputGrades(burger);
}
void InputGrades(DishBase burger) //wprowadzenie ocen i obliczenie statystyk
{
    burger.GradeAdded += RestaurantGradeAdded; 
    while (true)
    {
        Console.WriteLine("Write the next client rating (1-6 or A-F) and describe your grade of food : /de-delicious /li-lick your fingers/ /ta-tasty/ /ca-can be eaten/ /no-nothig special/ /di-distasteful/  q-quit");
        var input = Console.ReadLine();
        if (input == "q")
        {
            break;
        }
        try
        {
            burger.AddGrade(input);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Exception catched: {exception.Message}");
        }

        Console.WriteLine("Describe your grade of climate write (1-6) or :  /A-exelent/ /B-very good/ /C-good/ /D-nothig special/ /E-den/ /F-dingly/ q-quit");
        var inputClimate = Console.ReadLine();
        if (inputClimate == "q")
        {
            break;
        }
        try
        {
            burger.AddGrade(inputClimate);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Exception catched: {exception.Message}");
        }

        Console.WriteLine("Describe your grade of service write (1-6) or : /A - very good/ /B - good/ /C-the bartender was smoking/ /D-there was no service/ /E-there was no bathroom/ /F-it was dirty/ q-quit");
        var inputService = Console.ReadLine();
        if (inputService == "q")
        {
            break;
        }
        try
        {
            burger.AddGrade(inputService);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Exception catched: {exception.Message}");
        }
    }
    var statisticsForBurger = burger.GetStatistics();
    Console.WriteLine("======================================");
    WritelineColor(ConsoleColor.Red, $"Restaurant named {burger.Restaurantname} in {burger.Cityname} on {burger.Streetname} street and Your dish is {burger.Dishname} and has grade: {statisticsForBurger.AverageLetter:N2}");
    Console.WriteLine($"Average: {statisticsForBurger.Average:N2}");
    Console.WriteLine($"Min: {statisticsForBurger.Min}");
    Console.WriteLine($"Max: {statisticsForBurger.Max}");
}
void EnterResturantsToMemory() //wprowadzenie danych do pamieci 
{
    var burger = new BurgerInMemory();
    EnterRestaurants(burger);
}

void EnterResturantsToFile() //wprowadzenie danych do pliku
{
    var burger = new BurgerInFile();
    EnterRestaurants(burger);
}
void WritelineColor(ConsoleColor color, string text)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ResetColor();
    string GetValueFromUser(string comment)
    {
        WritelineColor(ConsoleColor.Yellow, comment);
        string userInput = Console.ReadLine();
        return userInput;
    }
}

Console.WriteLine("==================================================="); //program główny
WritelineColor(ConsoleColor.Blue, "Welcome to The Restaurants Grades Diary console app");
Console.WriteLine("===================================================");

bool CloseApp = false;
while (!CloseApp)
{
    Console.WriteLine();
    WritelineColor(ConsoleColor.Green,
        "Add restaurant's grades to the program memory and show statistics /1 \n" +
        "Add restaurant's grades to the .txt file and show statistics /2\n" +
        "To close app /X\n");

    var userInput = Console.ReadLine().ToUpper();

    switch (userInput)
    {
        case "1":
            EnterResturantsToMemory();
            break;
        case "2":
            EnterResturantsToFile();
            break;
        case "X":
            CloseApp = true;
            break;

        default:
            WritelineColor(ConsoleColor.Red, "Invalid operation.\n");
            continue;
    }
}

