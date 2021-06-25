namespace CS04_Advanced.MyExtensions
{
    public static class MyExtensions
    {
        public static bool isKitten(this Cat cat)
        {
            if (cat.Age > 1) return false;
            return true;
        }
    }
}
