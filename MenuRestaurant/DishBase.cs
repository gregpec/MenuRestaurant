namespace MenuRestaurant
{  
    public abstract class DishBase:IDish
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);
        public abstract event GradeAddedDelegate GradeAdded;
        public DishBase(string restaurantname, string cityname, string streetname, string dishname) 
        {
            this.Restaurantname = restaurantname;
            this.Cityname = cityname;
            this.Streetname = streetname;
            this.Dishname = dishname;
        }       
        public virtual string Restaurantname { get;   set; }
        public virtual string Cityname { get; set; }
        public virtual string Streetname { get;  set; }
        public virtual string Dishname { get; set; }
        public abstract void AddGrade(float grade);
        public abstract void AddGrade(string grade);
        public abstract void AddGrade(int grade);
        public abstract void AddGrade(long grade);
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
    }
}

