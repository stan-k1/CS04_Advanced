using System;

namespace Lab3_Extensions.LabExtensions
{
    public static class LabExtensions
    {
        public static int GetAbs(this int num)
        {
            return Math.Abs(num);
        }

        public static char GetFirstChar(this string text)
        {
            return char.Parse(text.Substring(0, 1));
        }
    }
}
