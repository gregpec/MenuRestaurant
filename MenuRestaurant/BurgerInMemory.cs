﻿namespace MenuRestaurant
{
    public class BurgerInMemory:DishBase,IDish
    {
        public override event GradeAddedDelegate GradeAdded;
        private List<float> grades = new List<float>();
        public static char[] specialLetters = { 'A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'E', 'e', 'F', 'f' };
        public static string[] specialGrades = { "+1", "1+", "-2", "2-", "+2", "2+", "-3", "3-", "+3", "3+", "-4", "4-", "+4", "4+", "-5", "5-", "+5", "5+", "-6", "6-" };
        public BurgerInMemory(string restaurantname, string city, string streetname, string dishname) : base(restaurantname, city, streetname, dishname)
        {
        }
        public BurgerInMemory() 
        {
        }
        public override string Restaurantname { get; set; }
        public override string Cityname { get; set; }
        public override string Streetname { get; set; }
        public override string Dishname { get; set; }    
        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 6)
            {
                Console.Write("the value of grade is correct and is converted to float\n");            
                this.grades.Add(grade);
                if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }             
            }
            else
            {
                throw new Exception("the value is out of range");
            }
        }
        public override void AddGrade(double grade)
        {
            Console.Write("the value of number is double and ");
            float doubleToFloat = (float)grade;
            this.AddGrade(doubleToFloat);
        }
        public override void AddGrade(int grade)
        {
            Console.Write("the value of number is int and ");
            float intToFloat = (float)grade;
            this.AddGrade(intToFloat);
        }
        public override void AddGrade(long grade)
        {
            Console.Write("the value of number is long and ");
            float longToFloat = (float)grade;
            this.AddGrade(longToFloat);
        }
        public override void AddGrade(string grade)
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
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            foreach (var grade in this.grades)
            {
                statistics.AddGrade(grade);
            }
            return statistics;
        }
    }
}
