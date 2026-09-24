using System;

namespace TorreHanoi
{
 public class Program
 {
    private const int DISCS_COUNT = 10;
    private static int DELAY_MS = 250;
    private static int _columnSize = 30;
    
    public static void Main(string[] args)
    {
        _columnSize = Math.Max(6, GetDiscWidth(DISCS_COUNT) * 2);
        HanoiTower algorithm = new HanoiTower(DISCS_COUNT);
    }

    private static void Algorith_Visualize (object sender, EventArgs e)
    {
        Console.Clear();
        HanoiTower algorithm = (HanoiTower)sender;

        if (algorithm.DiscsCount <= 0)
        {
            return;
        }

        //char [][] visualization = InitializeVisualization(algorithm);

        private static void PrepareColumn(char[][], int column, int discCount, Stack<int>stack)
        {
            int margin = _columnSize * (column -1);

            for (int y = 0; y < stack.Count; y++) {
                int size = stack.ElementAt(y);
                int row = discsCount - (stack.Count - y);
                int columnStart = margin + discsCount - size;
                int columnEnd = columnStart + GetDiscWidth(size);
            }
        }

        private static char [][] InitializeVisualization(HanoiTower algorithm)
        {
            char [][] visualization = new char[algorithm.DiscsCount][];

            for (int y = 0; y< visualization.Lenght; y++)
            {
                visualization[y] = new char[_columnSize * 3];

                for (int x = 0; x <= _columnSize * 3; x++)
                {
                    visualization[y][x] = ' ';
                }
            }
            return visualization;
        }

    }
    private static int GetDiscWidth(int size)
    {
        return 2 * size - 1;
    }
 }
}