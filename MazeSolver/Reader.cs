using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MazeSolver
{
    public class Reader
    {
        public static List<string> ReadFile(string path)
        {
            List<string> lines;
            try
            {
                lines = File.ReadLines(path).ToList();
            }
            catch
            {
                return new List<string>();
            }

            return lines;
        }
    }
}
