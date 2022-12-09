namespace Day_09
{
    public class Main
    {
        public class Instruction
        {
            public string Direction { get; set; }
            public int Count { get; set; }
        }
        public class Position
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public class Rope
        {
            public Rope(int level) : this()
            {
                this.Level = level;
                this.CurrentNode = new Position() { X = 0, Y = 0 };

                if (level + 1 < 10)
                    this.NextNode = new Rope(level + 1);
            }
            public Rope()
            {
                this.NextNode = null;
            }
            public int Level { get; set; }
            Position _curNode;
            public Position CurrentNode
            {
                get => _curNode;
                set
                {
                    var oldVal = _curNode;

                    _curNode = value;
                    if (value != null && this.NextNode != null)
                    {
                        var nextDistX = Math.Abs(value.X - this.NextNode.CurrentNode.X);
                        var nextDistY = Math.Abs(value.Y - this.NextNode.CurrentNode.Y);
                        if (nextDistX > 1 && nextDistY == 0)
                            this.NextNode.CurrentNode = new Position()
                            {
                                X = this.NextNode.CurrentNode.X + (value.X - oldVal.X),
                                Y = this.NextNode.CurrentNode.Y
                            };
                        else if (nextDistY > 1 && nextDistX == 0)
                            this.NextNode.CurrentNode = new Position()
                            {
                                X = this.NextNode.CurrentNode.X,
                                Y = this.NextNode.CurrentNode.Y + (value.Y - oldVal.Y)
                            };

                        else if (nextDistY > 1 && nextDistX == 1)
                            this.NextNode.CurrentNode = new Position()
                            {
                                X = value.X,
                                Y = this.NextNode.CurrentNode.Y + (value.Y - oldVal.Y)
                            };
                        else if (nextDistX > 1 && nextDistY == 1)
                            this.NextNode.CurrentNode = new Position()
                            {
                                X = this.NextNode.CurrentNode.X + (value.X - oldVal.X),
                                Y = value.Y
                            };
                        else if (nextDistX > 1 && nextDistY > 1)
                            this.NextNode.CurrentNode = new Position()
                            {
                                X = this.NextNode.CurrentNode.X + (value.X - oldVal.X),
                                Y = this.NextNode.CurrentNode.Y + (value.Y - oldVal.Y)
                            };
                    }

                    if (this.Level == 9 && value != null)
                        TailHistory.Add(new Position() { X = value.X, Y = value.Y });
                }
            }
            public Rope NextNode { get; set; }
        }

        #region Part 1
        Position _head;
        public Position HeadPos
        {
            get => _head;
            set
            {
                var oldVal = _head;

                _head = value;
                if (value != null && this.TailPos != null)
                {
                    var tailDistX = Math.Abs(value.X - TailPos.X);
                    var tailDistY = Math.Abs(value.Y - TailPos.Y);
                    if (tailDistX > 1 && tailDistY == 0)
                        TailPos = new Position() { X = TailPos.X + (value.X - oldVal.X), Y = TailPos.Y };
                    else if (tailDistY > 1 && tailDistX == 0)
                        TailPos = new Position() { X = TailPos.X, Y = TailPos.Y + (value.Y - oldVal.Y) };

                    else if (tailDistY > 1 && tailDistX == 1)
                        TailPos = new Position() { X = value.X, Y = TailPos.Y + (value.Y - oldVal.Y) };
                    else if (tailDistX > 1 && tailDistY == 1)
                        TailPos = new Position() { X = TailPos.X + (value.X - oldVal.X), Y = value.Y };
                }
            }
        }
        Position _tail;
        public Position TailPos
        {
            get => _tail;
            set
            {
                _tail = value;
                if (value != null)
                    TailHistory.Add(new Position() { X = value.X, Y = value.Y });
            }
        }
        private static List<Position> TailHistory = new List<Position>();
        #endregion

        private List<Instruction> Instructions = new List<Instruction>();
        private string Input { get; set; }

        public Main(bool test)
        {
            this.Input = test ? Properties.Resources.TestInput : Properties.Resources.Input;

            foreach (var line in this.Input.Split("\r\n"))
            {
                if (String.IsNullOrWhiteSpace(line)) continue;

                var lineSplit = line.Split(" ");
                this.Instructions.Add(new Instruction() { Direction = lineSplit[0], Count = Convert.ToInt32(lineSplit[1]) });
            }
        }
        public int Part1()
        {
            this.HeadPos = new Position() { X = 0, Y = 0 };
            this.TailPos = new Position() { X = 0, Y = 0 };

            foreach (var instruction in this.Instructions)
            {
                for (int i = 0; i < instruction.Count; i++)
                {
                    switch (instruction.Direction)
                    {
                        case "L":
                            this.HeadPos = new Position() { X = HeadPos.X - 1, Y = HeadPos.Y };
                            break;
                        case "U":
                            this.HeadPos = new Position() { X = HeadPos.X, Y = HeadPos.Y + 1 };
                            break;
                        case "R":
                            this.HeadPos = new Position() { X = HeadPos.X + 1, Y = HeadPos.Y };
                            break;
                        case "D":
                            this.HeadPos = new Position() { X = HeadPos.X, Y = HeadPos.Y - 1 };
                            break;
                    }
                }
            }

            return TailHistory.Select(x => $"{x.X}.{x.Y}")
                .Distinct()
                .Count();
        }
        public int Part2()
        {
            TailHistory.Clear();
            var rope = new Rope(0);

            foreach (var instruction in this.Instructions)
            {
                for (int i = 0; i < instruction.Count; i++)
                {
                    switch (instruction.Direction)
                    {
                        case "L":
                            rope.CurrentNode = new Position() { X = rope.CurrentNode.X - 1, Y = rope.CurrentNode.Y };
                            break;
                        case "U":
                            rope.CurrentNode = new Position() { X = rope.CurrentNode.X, Y = rope.CurrentNode.Y + 1 };
                            break;
                        case "R":
                            rope.CurrentNode = new Position() { X = rope.CurrentNode.X + 1, Y = rope.CurrentNode.Y };
                            break;
                        case "D":
                            rope.CurrentNode = new Position() { X = rope.CurrentNode.X, Y = rope.CurrentNode.Y - 1 };
                            break;
                    }
                }
            }
            return TailHistory.Select(x => $"{x.X}.{x.Y}")
                .Distinct()
                .Count();
        }
    }
}