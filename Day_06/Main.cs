namespace Day_06
{
    public class Main
    {
        private string Input { get; set; }
        public Main(bool test)
            => this.Input = test ? Properties.Resources.TestInput : Properties.Resources.Input;

        public int Part1()
        {
            int output = 0;
            for (int i = 4; i < this.Input.Length; i++)
            {
                var testInput = this.Input.Take(i).Reverse().Take(4).ToList();
                var distinct = testInput.Distinct().ToList();
                if(testInput.Count == distinct.Count)
                { output = i; break; }
            }
            return output;
        }
        public int Part2()
        {
            int output = 0;
            for (int i = 14; i < this.Input.Length; i++)
            {
                var testInput = this.Input.Take(i).Reverse().Take(14).ToList();
                var distinct = testInput.Distinct().ToList();
                if (testInput.Count == distinct.Count)
                { output = i; break; }
            }
            return output;
        }
    }
}