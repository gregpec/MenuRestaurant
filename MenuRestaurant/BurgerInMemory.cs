namespace MenuRestaurant
{
    public class BurgerInMemory:DishBase
    {
        public override event GradeAddedDelegate GradeAdded;
        private List<float> grades = new List<float>();
        public BurgerInMemory(string restaurantname, string city, string streetname, string dishname) : base(restaurantname, city, streetname, dishname)
        {
        }
        public BurgerInMemory() 
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
                Console.Write("the value of grade is correct\n");            
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
