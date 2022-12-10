namespace Day_10
{
    public class Main
    {
        public class Instruction
        {
            int _runtime;
            public int Runtime
            {
                get => _runtime;
                set
                {
                    _runtime = value;
                    if (value == 0)
                        Register += this.RegisterModifier;
                }
            }
            public int RegisterModifier { get; set; }
            public Boolean HasRun { get => this.Runtime == 0; }
        }
        public class RegisterState
        {
            public int Cycle { get; set; }
            public int RegisterValue { get; set; }
            public int SignalStrength { get => this.Cycle * this.RegisterValue; }
        }
        private static int Register { get; set; } = 1;
        private int CycleCount = 1;
        private Instruction CurrentInstruction { get; set; }

        public String Input { get; set; }
        private List<Instruction> Instructions = new List<Main.Instruction>();
        private List<RegisterState> RegState = new List<RegisterState>();
        public Main(bool test)
         => this.Input = test ? Properties.Resources.TestInput : Properties.Resources.Input;

        private void ParseInput()
        {
            this.Instructions.Clear();
            foreach (var line in this.Input.Split("\r\n"))
            {
                if (String.IsNullOrWhiteSpace(line)) continue;

                var lineSplit = line.Split(" ");
                this.Instructions.Add(new Instruction()
                {
                    Runtime = lineSplit[0] == "addx" ? 2 : 1,
                    RegisterModifier = lineSplit[0] == "addx" ? Convert.ToInt32(lineSplit[1]) : 0
                });
            }
        }

        public int Part1()
        {
            ParseInput();
            Register = 1;
            this.CurrentInstruction = null;

            while (CycleCount <= 220)
            {
                if (new List<int>() { 20, 60, 100, 140, 180, 220 }.Contains(CycleCount))
                    this.RegState.Add(new RegisterState()
                    {
                        Cycle = CycleCount,
                        RegisterValue = Register
                    });

                if (this.CurrentInstruction == null)
                    this.CurrentInstruction = this.Instructions.First();
                
                this.CurrentInstruction.Runtime -= 1;
                if (this.CurrentInstruction.HasRun)
                {
                    this.Instructions.RemoveAt(0);
                    this.CurrentInstruction = null;
                }

                CycleCount++;
            }
            return this.RegState.Sum(x => x.SignalStrength);
        }
        public void Part2()
        {
            ParseInput();
            Register = 1;
            this.CurrentInstruction = null;

            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 40; x++)
                {
                    var spritePosition = new List<int>() { Register, Register + 1, Register + 2 };
                    string output = spritePosition.Contains(x + 1) ? "#" : ".";
                    Console.Write(output);

                    if (this.CurrentInstruction == null)
                        this.CurrentInstruction = this.Instructions.First();

                    this.CurrentInstruction.Runtime -= 1;
                    if (this.CurrentInstruction.HasRun)
                    {
                        this.Instructions.RemoveAt(0);
                        this.CurrentInstruction = null;
                    }
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}