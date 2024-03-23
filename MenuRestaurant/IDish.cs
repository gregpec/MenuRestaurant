namespace MenuRestaurant
{
    public interface IDish
    {
        string Restaurantname { get; }  
        string Cityname { get; }
        string Streetname { get; }
        string Dishname { get; }
        void AddGrade(float grade);
        void AddGrade(string grade);
        void AddGrade(int grade);
        void AddGrade(long grade);
        void AddGrade(double grade);
        public abstract Statistics GetStatistics();
    }
}
