using MenuRestaurant;
using System.Text.RegularExpressions;
void RestaurantGradeAdded(object sender, EventArgs args)
{
    WritelineColor(ConsoleColor.Red, "New rating added!");
}
void EnterRestaurantsToMemory()
{
    string restaurantName;
    string cityName;
    string streetName;
    string dishName;
    Regex regex = new Regex(@"^[a-zA-Z0-9ąćęłńóśźżĄĆĘŁŃÓŚŹŻ\-\._]+$");

    do
    {
        Console.WriteLine("Please insert restaurant's name: ");
        restaurantName = Console.ReadLine();
        if (regex.IsMatch(restaurantName))
        {
            

            Console.WriteLine("Name is properly!");
        }
        else
        {
            Console.WriteLine("Name is not properly");
        }
    } while (!regex.IsMatch(restaurantName));

    do
    {
        Console.WriteLine("Please insert restaurant's city: ");
        cityName = Console.ReadLine();
        if (regex.IsMatch(cityName))
        {
            Console.WriteLine("Name is properly!");
        }
        else
        {
            Console.WriteLine("Name is not properly");
        }
    } while (!regex.IsMatch(cityName));

    do
    {
        Console.WriteLine("Please insert restaurant's street: ");
        streetName = Console.ReadLine();
        if (regex.IsMatch(streetName))
        {
            Console.WriteLine("Name is properly!");
        }
        else
        {
            Console.WriteLine("Name is not properly");
        }
    } while (!regex.IsMatch(streetName));

    do
    {
        Console.WriteLine("Please insert restaurant's dish: Enter = Burger ");
        dishName = Console.ReadLine();
        if (regex.IsMatch(dishName))
        {
            Console.WriteLine("Name is properly!");
        }
        else if (dishName == "")
        {
            dishName = "Burger";
        }
        else
        {
            Console.WriteLine("Name is not properly");
        }
    } while (!regex.IsMatch(dishName));

    BurgerInMemory burger = new BurgerInMemory(restaurantName, cityName, streetName, dishName);
    InputGrades(burger);
   
    var statisticsForBurger = burger.GetStatistics();
    Console.WriteLine("======================================");
    WritelineColor(ConsoleColor.Red, $"Restaurant named {burger.Restaurantname} in {burger.Cityname} on {burger.Streetname} street and Your dish is {burger.Dishname} and has grade: {statisticsForBurger.AverageLetter:N2}");
    Console.WriteLine($"Average: {statisticsForBurger.Average:N2}");
    Console.WriteLine($"Min: {statisticsForBurger.Min}");
    Console.WriteLine($"Max: {statisticsForBurger.Max}");
}
void InputGrades(BurgerInMemory burger)
{
    burger.GradeAdded += RestaurantGradeAdded;
    while (true)
    {
        Console.WriteLine("Write the next client rating and describe your grade of food (1-6) or : /A-delicious /B-lick your fingers/ /C-tasty/ /D-can be eaten/ /E-nothig special/ /F-distasteful/  q-quit");
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
}
void EnterRestaurantsToFile()
{
    string restaurantName;
    string cityName;
    string streetName;
    string dishName;
    Regex regex = new Regex(@"^[a-zA-Z0-9ąćęłńóśźżĄĆĘŁŃÓŚŹŻ\-\._]+$");

    do
    {
        Console.WriteLine("Please insert restaurant's name: ");
        restaurantName = Console.ReadLine();
        if (regex.IsMatch(restaurantName))
        {
            Console.WriteLine("Name is properly!");
        }
        else
        {
            Console.WriteLine("Name is not properly");
        }
    } while (!regex.IsMatch(restaurantName));

    do
    {
        Console.WriteLine("Please insert restaurant's city: ");
        cityName = Console.ReadLine();
        if (regex.IsMatch(cityName))
        {
            Console.WriteLine("Name is properly!");
        }
        else
        {
            Console.WriteLine("Name is not properly");
        }
    } while (!regex.IsMatch(cityName));

    do
    {
        Console.WriteLine("Please insert restaurant's street: ");
        streetName = Console.ReadLine();
        if (regex.IsMatch(streetName))
        {
            Console.WriteLine("Name is properly!");
        }
        else
        {
            Console.WriteLine("Name is not properly");
        }
    } while (!regex.IsMatch(streetName));

    do
    {
        Console.WriteLine("Please insert restaurant's dish: Enter = Burger ");
        dishName = Console.ReadLine();
        if (regex.IsMatch(dishName))
        {
            Console.WriteLine("Name is properly!");
        }
        else if (dishName == "")
        {
            dishName = "Burger";
        }
        else
        {
            Console.WriteLine("Name is not properly");
        }

    } while (!regex.IsMatch(dishName));

    BurgerInFile burger = new BurgerInFile(restaurantName, cityName, streetName, dishName);
    InputGrades(burger); 

    var statisticsForBurger = burger.GetStatistics();
    Console.WriteLine("======================================");
    WritelineColor(ConsoleColor.Red, $"Restaurant named {burger.Restaurantname} in {burger.Cityname} on {burger.Streetname} street anf Your dish is {burger.Dishname} has grade : {statisticsForBurger.AverageLetter:N2}");
    Console.WriteLine($"Average: {statisticsForBurger.Average:N2}");
    Console.WriteLine($"Min: {statisticsForBurger.Min}");
    Console.WriteLine($"Max: {statisticsForBurger.Max}");
}
void InputGradesToFile(BurgerInFile burger)
{
    burger.GradeAdded += RestaurantGradeAdded;
    while (true)
    {
            Console.WriteLine("Write the next client rating (1-6 or A-F) and describe your grade of food: /de-delicious /li-lick your fingers/ /ta-tasty/ /ca-can be eaten/ /no-nothig special/ /di-distasteful/  q-quit");
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
        Console.WriteLine("Describe your grade of climate and write (1-6 or A-F): /A-exelent/ /B-very good/ /C-good/ /D-nothig special/ /E-den/ /F-dingly/ q-quit");

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

        Console.WriteLine("Describe your grade of service and write (1-6 or A-F): /A - very good/ /B - good/ /C-the bartender was smoking/ /D-there was no service/ /E-there was no bathroom/ /F-it was dirty/ q-quit");
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
            EnterRestaurantsToMemory();
            break;
        case "2":
            EnterRestaurantsToFile();
            break;
        case "X":
            CloseApp = true;
            break;

        default:
            WritelineColor(ConsoleColor.Red, "Invalid operation.\n");
            continue;
    }
}

