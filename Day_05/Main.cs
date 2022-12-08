using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_05
{
    public class Main
    {
        public class clsInstructions
        {
            public int Count { get; set; }
            public int Start { get; set; }
            public int End { get; set; }
        }
        private List<clsInstructions> Instructions = new List<clsInstructions>();
        private List<List<string>> Stack = new List<List<string>>();
        private string Input { get; set; }
        public Main(bool test)
            => this.Input = test ? Properties.Resources.TestInput : Properties.Resources.Input;
        private void ParseInput()
        {
            this.Instructions = new List<clsInstructions>();
            this.Stack = new List<List<string>>();
            var temp = this.Input.Split("\r\n").First().ToList();
            this.Stack = Enumerable.Range(0, (temp.Count + 1) / 4).Select(x => new List<string>()).ToList();

            var inputSplit = this.Input.Split("\r\n");
            var instructionBreak = 0;
            for (int i = 0; i < inputSplit.Length; i++)
            {
                var line = inputSplit[i];
                if (line.Any(x => int.TryParse(Convert.ToString(x), out int _)))
                { instructionBreak = i + 1; break; }
                var stackBlock = 0;
                for (int c = 0; c < line.Length; c += 3)
                {
                    var block = new String(line.Skip(c).Take(3).ToArray());
                    if (!String.IsNullOrWhiteSpace(block))
                        this.Stack[stackBlock].Add(block);
                    c++; stackBlock++;
                }
            }
            for (int i = instructionBreak; i < inputSplit.Length; i++)
            {
                var line = inputSplit[i];
                if (String.IsNullOrWhiteSpace(line))
                    continue;

                var lineSplit = line.Split(" ");
                this.Instructions.Add(new clsInstructions()
                {
                    Count = Convert.ToInt32(lineSplit[lineSplit.ToList().IndexOf("move") + 1]),
                    Start = Convert.ToInt32(lineSplit[lineSplit.ToList().IndexOf("from") + 1]),
                    End = Convert.ToInt32(lineSplit[lineSplit.ToList().IndexOf("to") + 1]),
                });
            }
        }
        public string Part1()
        {
            ParseInput();
            foreach (var instruction in this.Instructions)
            {
                for (int i = 0; i < instruction.Count; i++)
                {
                    var move = this.Stack[instruction.Start - 1].First();
                    this.Stack[instruction.Start - 1].RemoveAt(0);
                    this.Stack[instruction.End - 1].Insert(0, move);
                }
            }

            return String.Join("", this.Stack.Select(x => x[0]));
        }
        public string Part2()
        {
            ParseInput();
            foreach (var instruction in Instructions)
            {
                var move = this.Stack[instruction.Start - 1].Take(instruction.Count).Select(x => new String(x)).ToList();

                this.Stack[instruction.Start - 1].RemoveRange(0, instruction.Count);
                this.Stack[instruction.End - 1].InsertRange(0, move);
            }

            return String.Join("", this.Stack.Select(x => x[0]));
        }
    }
}
