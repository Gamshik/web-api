namespace cinemaBLL
{
    internal class ValidationHelper
    {
        public static bool ValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
