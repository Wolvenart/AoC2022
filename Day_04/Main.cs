using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_04
{
    public class Main
    {
        public class clsFieldAssignments
        {
            public List<int> Elf1 { get; set; } = new List<int>();
            public List<int> Elf2 { get; set; } = new List<int>();
        }
        private string Input { get; set; }
        private List<clsFieldAssignments> FieldAssignments = new List<clsFieldAssignments>();
        public Main(bool test)
        {
            this.Input = test ? Properties.Resources.TestInput : Properties.Resources.Input;

            foreach (var item in this.Input.Split("\r\n"))
            {
                if (String.IsNullOrWhiteSpace(item)) continue;

                var elfSplit = item.Split(",");
                var fieldRange1 = elfSplit[0].Split("-");
                var fieldRange2 = elfSplit[1].Split("-");

                this.FieldAssignments.Add(new clsFieldAssignments()
                {
                    Elf1 = Enumerable.Range(Convert.ToInt32(fieldRange1[0]), (Convert.ToInt32(fieldRange1[1]) - Convert.ToInt32(fieldRange1[0])) + 1).ToList(),
                    Elf2 = Enumerable.Range(Convert.ToInt32(fieldRange2[0]), (Convert.ToInt32(fieldRange2[1]) - Convert.ToInt32(fieldRange2[0])) + 1).ToList(),
                });
            }
        }

        public int Part1()
            => this.FieldAssignments
                .Where(x => x.Elf1.Except(x.Elf2).Count() == 0 || x.Elf2.Except(x.Elf1).Count() == 0)
                .Count();
        public int Part2()
            => this.FieldAssignments
            .Where(x => x.Elf1.Intersect(x.Elf2).Count() > 0)
            .Count();
    }
}
