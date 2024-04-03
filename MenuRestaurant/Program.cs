using MenuRestaurant;
using System.Text.RegularExpressions;
void RestaurantGradeAdded(object sender, EventArgs args) 
{
    WritelineColor(ConsoleColor.Red, "New rating added!");
}
void EnterRestaurants(DishBase burger) 
{
    Regex regex = new Regex(@"^[a-zA-Z0-9ąćęłńóśźżĄĆĘŁŃÓŚŹŻ\-\._]+$");

    do
    {
        Console.WriteLine("Please insert restaurant's name: ");
        burger.RestaurantName = Console.ReadLine();
        if (regex.IsMatch(burger.RestaurantName))
        {


            Console.WriteLine("Name is properly!");
        }
        else
        {
            Console.WriteLine("Name is not properly");
        }
    } while (!regex.IsMatch(burger.RestaurantName));

    do
    {
        Console.WriteLine("Please insert restaurant's city: ");
        burger.CityName = Console.ReadLine();
        if (regex.IsMatch(burger.CityName))
        {
            Console.WriteLine("Name is properly!");
        }
        else
        {
            Console.WriteLine("Name is not properly");
        }
    } while (!regex.IsMatch(burger.CityName));

    do
    {
        Console.WriteLine("Please insert restaurant's street: ");
        burger.StreetName = Console.ReadLine();
        if (regex.IsMatch(burger.StreetName))
        {
            Console.WriteLine("Name is properly!");
        }
        else
        {
            Console.WriteLine("Name is not properly");
        }
    } while (!regex.IsMatch(burger.StreetName));

    do
    {
        Console.WriteLine("Please insert restaurant's dish: Enter = Burger ");
        burger.DishName = Console.ReadLine();
        if (regex.IsMatch(burger.DishName))
        {
            Console.WriteLine("Name is properly!");
        }
        else if (burger.DishName == "")
        {
            burger.DishName = "Burger";
        }
        else
        {
            Console.WriteLine("Name is not properly");
        }
    } while (!regex.IsMatch(burger.DishName));

    InputGrades(burger);
}
void InputGrades(DishBase burger) 
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
    WritelineColor(ConsoleColor.Red, $"Restaurant named {burger.RestaurantName} in {burger.CityName} on {burger.StreetName} street and Your dish is {burger.DishName} and has grade: {statisticsForBurger.AverageLetter:N2}");
    Console.WriteLine($"Average: {statisticsForBurger.Average:N2}");
    Console.WriteLine($"Min: {statisticsForBurger.Min}");
    Console.WriteLine($"Max: {statisticsForBurger.Max}");
}
void EnterResturantsToMemory() 
{
    var burger = new BurgerInMemory();
    EnterRestaurants(burger);
}
void EnterResturantsToFile() 
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

Console.WriteLine("==================================================="); 
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

