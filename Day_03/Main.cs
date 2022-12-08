using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_03
{
    public class Main
    {
        public class clsPriority
        {
            public string Char { get; set; }
            public int Score { get; set; }
        }
        public class clsBags
        {
            public string Contents { get; set; }
            public List<string> Comp1 
            { 
                get => this.Contents.Substring(0, (int)(this.Contents.Length) / 2)
                    .Select(x => Convert.ToString(x)).ToList(); 
            }
            public List<string> Comp2 
            { 
                get => this.Contents.Substring((int)(this.Contents.Length) / 2)
                    .Select(x => Convert.ToString(x)).ToList(); 
            }
            public List<string> Common { get => this.Comp1.Intersect(this.Comp2).ToList(); }
            public int Part1Priority { get; set; }
        }
        private String Input { get; set; }
        private List<clsPriority> Priorities = new List<clsPriority>();
        private List<clsBags> Bags = new List<clsBags>();
        public Main(bool test)
        {
            this.Input = test ? Properties.Resources.TestInput : Properties.Resources.Input;

            this.Priorities.AddRange(Enumerable.Range(0, 26).Select(i => new clsPriority() { Char = Convert.ToString((char)('a' + i)), Score = i + 1 }));
            this.Priorities.AddRange(Enumerable.Range(0, 26).Select(i => new clsPriority() { Char = Convert.ToString((char)('A' + i)), Score = 27 + i }));

            foreach (var item in this.Input.Split("\r\n"))
            {
                if (String.IsNullOrWhiteSpace(item)) continue;

                this.Bags.Add(new clsBags() { Contents = item });
            }
        }

        public int Part1()
        {
            foreach (var item in this.Bags)
                item.Part1Priority = item.Common.Sum(x => Priorities.Where(p => p.Char == x).Sum(s => s.Score));
            
            return this.Bags.Sum(x => x.Part1Priority);
        }
        public int Part2()
        {
            int sum = 0;
            int grpCnt = 0;
            for (int i = 0; i < this.Bags.Count - 2; i += 3)
            {
                var group = this.Bags.Skip(i).Take(3)
                    .Select(x => x.Contents.Select(c => Convert.ToString(c)).ToList())
                    .ToList();

                var common = group[0].Intersect(group[1]).Intersect(group[2]).ToList();
                sum += common.Select(x => this.Priorities.First(p => p.Char == x).Score).Sum();
                grpCnt++;
            }
            return sum;
        }
    }
}
