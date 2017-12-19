namespace RestaurantReservation.BL.Entities
{
    public class Constant
    {
        public const int TableAvailable = 10;
        public const int MealTimeChoice = 7;
        public const int MinDaysBeforeMeal = 2;

    }

    public enum DishSize
    {
        Small,
        Medium,
        Standard,
        ExtraLarge
    }

    public enum MealTime
    {
        Lunch11am,
        Lunch12pm,
        Lunch1pm,
        Dinner5pm,
        Dinner6pm,
        Dinner7pm,
        Dinner8pm


    }

    public enum Salutation
    {
        Mr,
        Mrs,
        Ms
    }
}
