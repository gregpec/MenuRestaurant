namespace MenuRestaurant
{
    public class Statistics
    {
        public float Min { get; private set; }
        public float Max { get; private set; }
        public float Sum { get; private set; }
        public int Count { get; private set; }
        public float Average
        {
            get
            {
                return this.Sum / this.Count;
            }
        }
        public string AverageLetter
        {
            get
            {
                switch (this.Average)
                {
                    case var average when average >= 5:
                        return "Delisious!";

                    case var average when average >= 4:
                        return "Lick your fingers!";
                    case var average when average >= 3:
                        return "Tasty!";
                    case var average when average >= 2:
                        return "Can be eaten";
                    default:
                        return "Distasteful :-( ";
                }
            }
        }
        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.Max = float.MinValue;
            this.Min = float.MaxValue;
        }
        public void AddGrade(float grade)
        {
            this.Count++;
            this.Sum += grade;
            this.Min = Math.Min(grade, this.Min);
            this.Max = Math.Max(grade, this.Max);
        }
    }
}
