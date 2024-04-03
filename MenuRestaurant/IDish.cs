using static MenuRestaurant.DishBase;

namespace MenuRestaurant
{
    public interface IDish
    {
        public abstract event GradeAddedDelegate GradeAdded;
        public string RestaurantName { get; set; }  
        public string CityName { get; set; }
        public string StreetName { get; set; }
        public string DishName { get; set; }
        public void AddGrade(float grade);
        public void AddGrade(string grade);
        public void AddGrade(int grade);
        public void AddGrade(long grade);
        public void AddGrade(double grade);
        public abstract Statistics GetStatistics();
    }
}
