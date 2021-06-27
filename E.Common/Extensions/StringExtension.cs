namespace E.Common.Extensions
{
    public static class StringExtension
    {
        public static string SubAddString(this string target, int length)
        {
            if (target.Length < length) return target;

            var newTarget = target.Substring(0, length) + " ...";
            return newTarget;
        }
    }
}
