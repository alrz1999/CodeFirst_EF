namespace CodeFirst_EF.Utils
{
    public class Splitter
    {
        private static readonly char[] SEPARATOR = { ',', '\"', ' ', '(', ')', '/', '$', '-', ':', '#', '.', '\\', ';', '\'' };

        public static string[] Split(string str)
        {
            return str.Split(SEPARATOR);
        }
    }
}
