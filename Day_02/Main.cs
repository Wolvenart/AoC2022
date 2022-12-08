namespace Day_02
{
    public class Main
    {
        public enum enStates : int
        {
            Rock = 1,
            Paper = 2,
            Scissor = 3
        }
        public enum enRoundState : int
        {
            Lose = -1,
            Draw = 0,
            Win = 1
        }
        private Dictionary<string, enStates> dict = new Dictionary<string, enStates>()
        {
            { "A", enStates.Rock },
            { "B", enStates.Paper },
            { "C", enStates.Scissor },
            { "X", enStates.Rock },
            { "Y", enStates.Paper },
            { "Z", enStates.Scissor },
        };
        private Dictionary<string, enRoundState> dictRound = new Dictionary<string, enRoundState>()
        {
            { "X", enRoundState.Lose },
            { "Y", enRoundState.Draw },
            { "Z", enRoundState.Win },
        };
        public class clsGame
        {
            public enStates Opponent { get; set; }
            public enStates Me { get; set; }
            public enRoundState Round { get; set; }
            public int Score { get => Convert.ToInt32(this.Me) + ((Convert.ToInt32(this.Round) + 1) * 3); }
        }
        static int MathMod(int a, int b)
        {
            return (Math.Abs(a * b) + a) % b;
        }
        private List<clsGame> Hands = new List<clsGame>()
        {
            { new clsGame() { Round = enRoundState.Win, Opponent = enStates.Rock, Me = enStates.Paper } },
            { new clsGame() { Round = enRoundState.Win, Opponent = enStates.Paper, Me = enStates.Scissor} },
            { new clsGame() { Round = enRoundState.Win, Opponent = enStates.Scissor, Me = enStates.Rock} },
            { new clsGame() { Round = enRoundState.Lose, Opponent = enStates.Rock, Me = enStates.Scissor} },
            { new clsGame() { Round = enRoundState.Lose, Opponent = enStates.Paper, Me = enStates.Rock} },
            { new clsGame() { Round = enRoundState.Lose, Opponent = enStates.Scissor, Me = enStates.Paper} },
            { new clsGame() { Round = enRoundState.Draw, Opponent = enStates.Rock, Me = enStates.Rock} },
            { new clsGame() { Round = enRoundState.Draw, Opponent = enStates.Paper, Me = enStates.Paper} },
            { new clsGame() { Round = enRoundState.Draw, Opponent = enStates.Scissor, Me = enStates.Scissor} },
        };
        private List<clsGame> Game = new List<clsGame>();
        private String Input { get; set; }
        public Main(bool test)
        {
            this.Input = test ? Day_02.Properties.Resources.TestInput : Day_02.Properties.Resources.Input;
        }
        public int Part1()
        {
            this.Game.Clear();
            foreach (var item in this.Input.Split("\r\n"))
            {
                if (String.IsNullOrWhiteSpace(item))
                    continue;
                var split = item.Split(' ');
                var opponent = dict[split[0]];
                var me = dict[split[1]];
                this.Game.Add(new clsGame()
                {
                    Opponent = opponent,
                    Me = me,
                    Round = new Func<enRoundState>(() =>
                    {
                        if (me - opponent == 0)
                            return enRoundState.Draw;
                        if (MathMod((me - opponent), 3) == 1)
                            return enRoundState.Win;
                        else
                            return enRoundState.Lose;
                    }).Invoke()
                });
            }
            return this.Game.Sum(x => x.Score);
        }

        public int Part2()
        {
            this.Game.Clear();
            foreach (var item in this.Input.Split("\r\n"))
            {
                if (String.IsNullOrWhiteSpace(item))
                    continue;

                var split = item.Split(' ');
                var opponent = dict[split[0]];
                var result = dictRound[split[1]];

                this.Game.Add(new clsGame()
                {
                    Me = this.Hands.FirstOrDefault(x => x.Opponent == opponent && x.Round == result).Me,
                    Opponent = opponent,
                    Round = result,
                });
            }
            var a = this.Game.Where(x => x.Round == enRoundState.Lose
            && ((x.Me <= 0) || ((Int32)x.Me > 3)
                || (x.Me == x.Opponent)
                || (x.Me == enStates.Scissor && x.Opponent != enStates.Rock)
                || (x.Me == enStates.Paper && x.Opponent != enStates.Scissor)
                || (x.Me == enStates.Rock && x.Opponent != enStates.Paper)
            )
            ).ToList();
            return this.Game.Sum(x => x.Score);
        }
    }
}