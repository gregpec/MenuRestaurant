using static MenuRestaurant.DishBase;

namespace MenuRestaurant
{
    public interface IDish
    {
        public abstract event GradeAddedDelegate GradeAdded;
        public string Restaurantname { get; protected set; }  
        string Cityname { get; protected set; }
        string Streetname { get; protected set; }
        string Dishname { get; protected set; }
        void AddGrade(float grade);
        void AddGrade(string grade);
        void AddGrade(int grade);
        void AddGrade(long grade);
        void AddGrade(double grade);
        public abstract Statistics GetStatistics();
    }
}
