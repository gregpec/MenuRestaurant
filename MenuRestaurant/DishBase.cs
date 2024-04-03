namespace MenuRestaurant
{
    public abstract class DishBase:IDish
    {
        public char[] specialLetters = { 'A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'E', 'e', 'F', 'f' };
        public string[] specialGrades = { "+1", "1+", "-2", "2-", "+2", "2+", "-3", "3-", "+3", "3+", "-4", "4-", "+4", "4+", "-5", "5-", "+5", "5+", "-6", "6-" };
        public delegate void GradeAddedDelegate(object sender, EventArgs args);
        public abstract event GradeAddedDelegate GradeAdded;
        public DishBase(string restaurantname, string cityname, string streetname, string dishname)
        {
            this.RestaurantName = restaurantname;
            this.CityName = cityname;
            this.StreetName = streetname;
            this.DishName = dishname;
        }
        public DishBase()
        {
        }
        public abstract string RestaurantName { get; set; }
        public abstract string CityName { get; set; }
        public abstract string StreetName { get; set; }
        public abstract string DishName { get; set; }
        public abstract void AddGrade(float grade);
        public virtual void AddGrade(string grade)
        {
            if (grade.Length == 2 && specialGrades.Contains(grade))
            {
                switch (grade)
                {
                    case "+1":
                    case "1+":
                        this.AddGrade(1.25);
                        break;
                    case "-2":
                    case "2-":
                        this.AddGrade(1.75);
                        break;
                    case "+2":
                    case "2+":
                        this.AddGrade(2.25);
                        break;
                    case "-3":
                    case "3-":
                        this.AddGrade(2.75);
                        break;
                    case "+3":
                    case "3+":
                        this.AddGrade(3.25);
                        break;
                    case "-4":
                    case "4-":
                        this.AddGrade(3.75);
                        break;
                    case "+4":
                    case "4+":
                        this.AddGrade(4.25);
                        break;
                    case "-5":
                    case "5-":
                        this.AddGrade(4.75);
                        break;
                    case "+5":
                    case "5+":
                        this.AddGrade(5.25);
                        break;
                    case "-6":
                    case "6-":
                        this.AddGrade(5.75);
                        break;
                    default:
                        throw new Exception("Wrong grade");
                }
            }
            else
            if (grade.Length == 1 && specialLetters.Contains(grade[0]))
            {
                switch (grade[0])
                {
                    case 'A':
                    case 'a':
                        this.AddGrade(6.0);
                        break;
                    case 'B':
                    case 'b':
                        this.AddGrade(5.0);
                        break;
                    case 'C':
                    case 'c':
                        this.AddGrade(4.0);
                        break;
                    case 'D':
                    case 'd':
                        this.AddGrade(3.0);
                        break;
                    case 'E':
                    case 'e':
                        this.AddGrade(2.0);
                        break;
                    case 'F':
                    case 'f':
                        this.AddGrade(1.0);
                        break;
                    default:
                        throw new Exception("Wrong letters grade");
                }
            }
            else if (float.TryParse(grade, out float resultOfFloat))
            {
                resultOfFloat = float.Parse(grade);
                this.AddGrade(resultOfFloat);
            }
            else
            {
                switch (grade)
                {
                    case "delicious":
                    case "de":
                        this.AddGrade(6.0);
                        break;
                    case "lick your fingers":
                    case "li":
                        this.AddGrade(5.0);
                        break;
                    case "tasty":
                    case "ta":
                        this.AddGrade(4.0);
                        break;
                    case "can be eaten":
                    case "ca":
                        this.AddGrade(3.0);
                        break;
                    case "nothing special":
                    case "no":
                        this.AddGrade(2.0);
                        break;
                    case "distasteful":
                    case "di":
                        this.AddGrade(1.0);
                        break;
                    default:
                        throw new Exception("Wrong descriptive grade");
                }
            }
        }
        public virtual void AddGrade(int grade)
        {
            Console.Write("the value of number is int and ");
            float intToFloat = (float)grade;
            this.AddGrade(intToFloat);
        }
        public virtual void AddGrade(long grade)
        {
            Console.Write("the value of number is long and ");
            float longToFloat = (float)grade;
            this.AddGrade(longToFloat);
        }
        public virtual void AddGrade(double grade)
        {
            float doubleToFloat = (float)grade;
            this.AddGrade(doubleToFloat);
            Console.Write("the value of number is double and ");
        }
        public abstract Statistics GetStatistics();
    }
}


