namespace MenuRestaurant.Tests
{
    public class Tests
    {
        [Test]
        public void AddingOneRestaurantWithGrade_ShouldReturnCorrectAverage()
        {
            //arrange
            var burger = new BurgerInMemory("Meksykañska", "Bratys³awa","Baker","Burger");
            burger.AddGrade(1);

            //act
            var statistics = burger.GetStatistics();

            //assert
            Assert.That(statistics.Average, Is.EqualTo(1));
        }

        [Test]
        public void AddingRestaurantsWithFewGrades_ShouldReturnCorrectAverage()
        {
            //arrange
            var burger = new BurgerInMemory("Meksykañska", "Bratys³awa", "Baker", "Burger");
            burger.AddGrade(4);
            burger.AddGrade(3);
            burger.AddGrade("4");
            burger.AddGrade(5);

            //act
            Statistics statistics = burger.GetStatistics();

            //assert
          Assert.AreEqual(4,statistics.Average);     
        }

        [Test]
        public void AddingRestaurantsWithFewGrades_ShouldReturnCorrectAverageLetter()
        {
            //arrange
            var burger = new BurgerInMemory("Meksykañska", "Bratys³awa", "Baker", "Burger");
            burger.AddGrade(5);
            burger.AddGrade(5);
            burger.AddGrade(5);
            burger.AddGrade(6);

            //act
            var statistics = burger.GetStatistics();

            //assert
            Assert.That(statistics.AverageLetter, Is.EqualTo("Delisious!"));
        }

        [Test]
        public void AddingRestaurantWithoutAnyGrades_ShouldReturnCorrectAverage()
        {
            //arrange
            var burger = new BurgerInMemory("Meksykañska", "Bratys³awa", "Baker", "Burger");

            //act
            var statistics = burger.GetStatistics();

            //assert
            Assert.That(statistics.Average, Is.EqualTo(float.NaN));
        }
    }
}




