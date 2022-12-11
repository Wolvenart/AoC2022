using AoCHelper;

namespace Day_11
{
    public class Main
    {
        public class Monkey
        {
            public int No { get; set; }
            public List<long> Items { get; set; }
            
            public string Operand { get; set; }
            public string OperationValue { get; set; }

            public long TestValue { get; set; }
            public int TestTrue { get; set; }
            public int TestFalse { get; set; }

            public long InspectCount = 0;

            public long Inspect(long item, bool panic)
            {
                InspectCount++;
                var newVal = item;
                var modValue = this.OperationValue == "old" ? item : Convert.ToInt64(this.OperationValue);

                switch (this.Operand)
                {
                    case "+":
                        newVal += modValue;
                        break;
                    case "*":
                        newVal *= modValue;
                        break;
                }
                return panic ? newVal : Convert.ToInt64(Math.Floor(Convert.ToDecimal(newVal) / 3));
            }
            public int WhoToThrow(long item)
            {
                return (item % this.TestValue) == 0 ? this.TestTrue : this.TestFalse;
            }
        }

        private List<Monkey> Monkeys = new List<Monkey>();

        public string Input { get; set; }
        public Main(bool test)
            =>   this.Input = test ? Properties.Resources.TestInput : Properties.Resources.Input;
        private void ParseInput()
        {
            this.Monkeys.Clear();
            
            foreach (var monkey in this.Input.Split("\r\n\r\n"))
            {
                var monkeySplit = monkey.Split("\r\n");
                this.Monkeys.Add(new Monkey()
                {
                    No = Convert.ToInt32(new string(monkeySplit[0].Replace(":", "")
                                                       .Reverse()
                                                       .TakeWhile(x => int.TryParse(Convert.ToString(x), out int _))
                                                       .Reverse().ToArray())),
                    Items = new string(monkeySplit[1].Reverse()
                                          .TakeWhile(x => Convert.ToString(x) != ":")
                                          .Reverse()
                                          .ToArray()).Split(",")
                                                     .Select(x => Convert.ToInt64(x.Trim(' ')))
                                                     .ToList(),
                    OperationValue = new string(monkeySplit[2].Reverse()
                                                              .TakeWhile(x => !new string[] { "+", "*" }.Contains(Convert.ToString(x)))
                                                              .Reverse().ToArray()).Trim(' '),
                    Operand = new string(monkeySplit[2].SkipWhile(x => !new string[] { "+", "*" }.Contains(Convert.ToString(x)))
                                                       .Take(1).ToArray()),
                    TestValue = Convert.ToInt64(new string(monkeySplit[3].Reverse()
                                                                         .TakeWhile(x => int.TryParse(Convert.ToString(x), out int _))
                                                                         .Reverse().ToArray())),
                    TestTrue = Convert.ToInt32(new string(monkeySplit[4].Reverse()
                                                                        .TakeWhile(x => int.TryParse(Convert.ToString(x), out int _))
                                                                        .Reverse().ToArray())),
                    TestFalse = Convert.ToInt32(new string(monkeySplit[5].Reverse()
                                                                         .TakeWhile(x => int.TryParse(Convert.ToString(x), out int _))
                                                                         .Reverse().ToArray()))
                });
            }
        }

        public long Part1()
        {
            ParseInput();

            for (int round = 1; round <= 20; round++)
            {
                foreach (var monkey in this.Monkeys)
                {
                    while (monkey.Items.Count > 0)
                    {
                        var newItem = monkey.Inspect(monkey.Items.First(), false);
                        monkey.Items.RemoveAt(0);
                        this.Monkeys.First(x => x.No == monkey.WhoToThrow(newItem)).Items.Add(newItem);
                    }
                }
            }
            return this.Monkeys.OrderByDescending(x => x.InspectCount)
                                   .Take(2)
                                   .Select(x => x.InspectCount)
                                   .Aggregate((a, x) => a * x);
        }

        public long Part2()
        {
            ParseInput();

            for (int round = 1; round <= 10000; round++)
            {
                foreach (var monkey in this.Monkeys)
                {
                    while (monkey.Items.Count > 0)
                    {
                        var newItem = monkey.Inspect(monkey.Items.First(), true);
                        var modulo = this.Monkeys.Select(x => x.TestValue).Aggregate((a, x) => a * x);
                        var newItemManaged = newItem % modulo;

                        monkey.Items.RemoveAt(0);
                        this.Monkeys.First(x => x.No == monkey.WhoToThrow(newItemManaged)).Items.Add(newItemManaged);
                    }
                }
            }
            return this.Monkeys.OrderByDescending(x => x.InspectCount)
                                   .Take(2)
                                   .Select(x => x.InspectCount)
                                   .Aggregate((a, x) => a * x);
        }
    }
}