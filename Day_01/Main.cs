using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_01
{
    public class Main
    {
        private string Input { get; set; }
        private List<int> Bags { get; set; } = new List<int>() { 0 };
        public Main(bool test)
        {
            this.Input = test ? Day_01.Properties.Resources.TestInput : Properties.Resources.Input;
            FillBags();
        }
        private void FillBags()
        {
            foreach (var item in this.Input.Split("\r\n"))
            {
                if (String.IsNullOrWhiteSpace(item))
                {
                    Bags.Add(0);
                    continue;
                }

                Bags[Bags.Count - 1] += Convert.ToInt32(item);
            }
        }
        public int Part1()
        {
            return Bags.Max();
        }

        public int Part2()
        {
            Bags.Sort();
            Bags.Reverse();
            return Bags.Take(3).Sum();
        }
    }
}
