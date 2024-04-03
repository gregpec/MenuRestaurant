namespace MenuRestaurant
{
      public class BurgerInFile:DishBase 
    {
        public override event GradeAddedDelegate GradeAdded;
       
        private const string fileName = "_restaurant_grade.txt";
        private const string fileN = "restaurants.txt";
        public string RestaurantN;
        public string CityN;
        public string fullfilename;
        public BurgerInFile(string restaurantname, string city, string streetname, string dishname) : base(restaurantname, city, streetname, dishname)
        {
        }
        public BurgerInFile()
        {   
        }
        public override string RestaurantName { get; set; }
        public override string CityName { get; set; }
        public override string StreetName { get; set; }
        public override string DishName { get; set; }
        public override void AddGrade(float grade)
        {
            Console.Write("the value is converted to float and ");
            if (grade >= 0 && grade <= 6)
            {
                RestaurantN = $"{char.ToUpper(RestaurantName[0])}{RestaurantName.Substring(1, RestaurantName.Length - 1).ToLower()}";
                CityN = $"{char.ToUpper(CityName[0])}{CityName.Substring(1, CityName.Length - 1).ToLower()}";
                fullfilename = $"{RestaurantN}_{CityN}{fileName}";
                Console.Write("the value of grade is correct\n");
                using (var writer = File.AppendText($"{fullfilename}"))
                using (var writer2 = File.AppendText(fileN))
                {
                    writer.WriteLine(grade);
                    writer2.WriteLine($"{RestaurantN} {CityN} - {grade}   {DateTime.UtcNow} ");
                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
            }
            else
            {
                throw new Exception("the value is out of range");
            }
        }
        public override Statistics GetStatistics()
        {
            var gradesFromFile = this.ReadGradesFromFile();
            var result = this.CountStatistics(gradesFromFile);
            return result;
        }
        private List<float> ReadGradesFromFile()
        {
            var grades = new List<float>();
            if (File.Exists($"{fullfilename}"))
            {
                using (var reader = File.OpenText($"{fullfilename}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        grades.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return grades;
        }
        private Statistics CountStatistics(List<float> grades)
        {
            var statistics = new Statistics();
            foreach (var grade in grades)
            {
                statistics.AddGrade(grade);
            }
            return statistics;
        }
    }
}
