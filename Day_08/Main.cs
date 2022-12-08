using AoCHelper;

namespace Day_08
{
    public class Main
    {
        public class clsTree
        {
            public int Height { get; set; }
            public bool Visible { get; set; }
            public double WestScore { get; set; }
            public double NorthScore { get; set; }
            public double EastScore { get; set; }
            public double SouthScore { get; set; }
            public double ScenicScore { get => this.WestScore * this.NorthScore * this.EastScore * this.SouthScore; }
        }
        private List<List<clsTree>> Grid = new List<List<clsTree>>();
        private string Input { get; set; }
        public Main(bool test)
        {
            this.Input = test ? Properties.Resources.TestInput : Properties.Resources.Input;
            foreach (var item in this.Input.Split("\r\n"))
            {
                if (String.IsNullOrWhiteSpace(item)) continue;

                this.Grid.Add(item.Select(x => new clsTree() { Height = Convert.ToInt32(Convert.ToString(x)) }).ToList());
            }
        }

        public int Part1()
        {
            this.Grid[0].ForEach(x => x.Visible = true);
            this.Grid[this.Grid.Count - 1].ForEach(x => x.Visible = true);
            this.Grid.Select(x => x.First()).ToList().ForEach(x => x.Visible = true);
            this.Grid.Select(x => x.Last()).ToList().ForEach(x => x.Visible = true);

            for (int y = 0; y < this.Grid.Count; y++)
            {
                for (int x = 0; x < this.Grid[y].Count; x++)
                {
                    var curTree = this.Grid[y][x];
                    if (curTree.Visible) continue;

                    var checkWest = this.Grid[y].Take(x).ToList();
                    if (checkWest.All(t => t.Height < curTree.Height))
                    { curTree.Visible = true; continue; }

                    var checkNorth = this.Grid.Take(y).Select(c => c[x]).ToList();
                    if (checkNorth.All(t => t.Height < curTree.Height))
                    { curTree.Visible = true; continue; }

                    var checkEast = this.Grid[y].Skip(x + 1).ToList();
                    if (checkEast.All(t => t.Height < curTree.Height))
                    { curTree.Visible = true; continue; }

                    var checkSouth = this.Grid.Skip(y + 1).Select(c => c[x]).ToList();
                    if (checkSouth.All(t => t.Height < curTree.Height))
                    { curTree.Visible = true; continue; }
                }
            }
            return this.Grid
                .SelectMany(x => x)
                .Where(x => x.Visible)
                .Count();
        }
        public double Part2()
        {
            for (int y = 0; y < this.Grid.Count; y++)
            {
                for (int x = 0; x < this.Grid[y].Count; x++)
                {
                    var curTree = this.Grid[y][x];
                    if (y == 0) curTree.NorthScore = 0;
                    else
                    {
                        var checkNorth = this.Grid.Take(y).Select(c => c[x]).Reverse().ToList();
                        foreach (var tree in checkNorth)
                        {
                            curTree.NorthScore++;

                            if (tree.Height >= curTree.Height)
                                break;
                        }
                    }
                    if (y == this.Grid.Count - 1) curTree.SouthScore = 0;
                    else
                    {
                        var checkSouth = this.Grid.Skip(y + 1).Select(c => c[x]).ToList();
                        foreach (var tree in checkSouth)
                        {
                            curTree.SouthScore++;
                            if (tree.Height >= curTree.Height)
                                break;
                        }
                    }
                    if (x == 0) curTree.WestScore = 0;
                    else
                    {
                        var checkWest = this.Grid[y].Take(x).Reverse().ToList();
                        foreach (var tree in checkWest)
                        {
                            curTree.WestScore++;
                            if (tree.Height >= curTree.Height)
                                break;
                        }
                    }
                    if (x == this.Grid[y].Count - 1) curTree.EastScore = 0;
                    else
                    {
                        var checkEast = this.Grid[y].Skip(x + 1).ToList();
                        foreach (var tree in checkEast)
                        {
                            curTree.EastScore++;
                            if (tree.Height >= curTree.Height)
                                break;
                        }
                    }
                }
            }

            return this.Grid
                .SelectMany(x => x)
                .Max(x => x.ScenicScore);
        }
    }
}