using System;

namespace DotNetSide.Model
{
    public static class Extensions
    {
        public static string GetMaxText(this string text, int maxSize)
            {
            if (text.Length > maxSize)
                return text.Substring(0, maxSize) + "...";
            return text;
        }
    }
}