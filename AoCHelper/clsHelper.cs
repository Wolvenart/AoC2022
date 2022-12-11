namespace AoCHelper
{
    public static class clsHelper
    {
        public static IEnumerable<T> SelectManyRecursive<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> selector)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");

            return !source.Any() ? source :
                source.Concat(
                    source
                    .SelectMany(i => selector(i).EmptyIfNull())
                    .SelectManyRecursive(selector)
                );
        }

        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }
        public static int MathMod(this int a, int b)
            => (Math.Abs(a * b) + a) % b;
        public static long MathMod(this long a, long b)
            => (Math.Abs(a * b) + a) % b;
        public static long MathMod(this long a, int b)
            => (Math.Abs(a * b) + a) % b;
    }
}