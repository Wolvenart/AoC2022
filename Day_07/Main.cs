using AoCHelper;

namespace Day_07
{
    public class Main
    {
        public class clsDir
        {
            public List<clsFile> Files { get; set; } = new List<clsFile>();
            public List<clsDir> Directories { get; set; } = new List<clsDir>();
            public long Size { get => this.Files.Sum(x => x.Size) + this.Directories.Sum(x => x.Size); }

            public string DirName { get; set; }
        }
        public class clsFile
        {
            public long Size { get; set; }
            public string FileName { get; set; }
        }

        private long TotalSpace { get => 70000000; }
        private long TotalNeededSpace { get => 30000000; }
        private long TotalUnusedSpace { get => this.TotalSpace - this.Root.Size; }

        private clsDir Root = new clsDir() { DirName = "/" };
        private string Input { get; set; }
        public Main(bool test)
        {
            this.Input = test ? Properties.Resources.TestInput : Properties.Resources.Input;

            var currentPath = new List<clsDir>();

            foreach (var line in this.Input.Split("\r\n"))
            {
                if (String.IsNullOrWhiteSpace(line)) continue;

                var lineSplit = line.Split(" ");
                
                if (line.StartsWith("$"))
                {
                    switch (lineSplit[1])
                    {
                        case "cd":
                            switch (lineSplit[2])
                            {
                                case "/":
                                    currentPath.Add(Root);
                                    break;
                                case "..":
                                    currentPath.Remove(currentPath.Last());
                                    break;
                                default:
                                    currentPath.Add(currentPath.Last().Directories.First(x => x.DirName == lineSplit[2]));
                                    break;
                            }
                            break;
                        case "ls":
                            continue;
                    }
                }
                else
                {
                    var curDir = currentPath.Last();
                    if (lineSplit[0] == "dir")
                        curDir.Directories.Add(new clsDir() { DirName = lineSplit[1] });
                    else
                        curDir.Files.Add(new clsFile() { Size = Convert.ToInt64(lineSplit[0]), FileName = lineSplit[1] });
                }
            }
        }
        public long Part1()
        {
            return this.Root.Directories
                .SelectManyRecursive(x => x.Directories)
                .Where(x => x.Size <= 100000)
                .Sum(x => x.Size);
        }
        public long Part2()
        {
            return this.Root.Directories
                .SelectManyRecursive(x => x.Directories)
                .OrderBy(x => x.Size)
                .First(x => x.Size >= this.TotalNeededSpace - this.TotalUnusedSpace)
                .Size;
        }
    }
}