using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TorreHanoi
{
    public class Program
    {
        private const int DISCS_COUNT = 10;
        private const int DELAY_MS = 250;

        // Campo estático (não const) para poder ser calculado em tempo de execução
        private static int _columnSize;

        public static void Main(string[] args)
        {
            // Sem "int" na frente: atribui ao campo da classe, não cria variável local
            // Mínimo de 12 para caber o título "AUXILIARY" mesmo com poucos discos
            _columnSize = Math.Max(12, GetDiscWidth(DISCS_COUNT) * 2);

            HanoiTower algorithm = new HanoiTower(DISCS_COUNT);
            algorithm.MoveCompleted += Algorithm_Vizualize; //delegate
            Algorithm_Vizualize(algorithm, EventArgs.Empty);
            algorithm.Start();
        }

        private static void Algorithm_Vizualize(object sender, EventArgs e)
        {
            Console.Clear();

            HanoiTower algorithm = (HanoiTower)sender;
            if (algorithm.DiscsCount <= 0)
            {
                return;
            }

            char[][] visualization = InitializeVisualization(algorithm);
            PrepareColumn(visualization, 1, algorithm.DiscsCount, algorithm.From);
            PrepareColumn(visualization, 2, algorithm.DiscsCount, algorithm.To);
            PrepareColumn(visualization, 3, algorithm.DiscsCount, algorithm.Auxiliary);

            Console.WriteLine(Center("FROM") + Center("TO") + Center("AUXILIARY"));
            DrawVisualization(visualization);
            Console.WriteLine();
            Console.WriteLine($"Nro de movimento: {algorithm.MovesCount}");
            Console.WriteLine($"Nro de discos: {algorithm.DiscsCount}");

            Thread.Sleep(DELAY_MS);
        }

        private static void PrepareColumn(char[][] visualization, int column, int discsCount, Stack<int> stack)
        {
            int margin = _columnSize * (column - 1);
            for (int y = 0; y < stack.Count; y++)
            {
                int size = stack.ElementAt(y);
                int row = discsCount - (stack.Count - y);
                int width = GetDiscWidth(size);

                // Centraliza o disco na coluna, alinhado com o título
                int columnStart = margin + (_columnSize - width) / 2;
                int columnEnd = columnStart + width;

                // "<" em vez de "<=": desenha exatamente "width" caracteres
                for (int x = columnStart; x < columnEnd; x++)
                {
                    visualization[row][x] = '=';
                }
            }
        }

        private static void DrawVisualization(char[][] visualization)
        {
            for (int y = 0; y < visualization.Length; y++)
            {
                Console.WriteLine(visualization[y]);
            }
        }

        private static string Center(string text)
        {
            int margin = Math.Max(0, (_columnSize - text.Length) / 2);
            return text.PadLeft(margin + text.Length).PadRight(_columnSize);
        }

        private static char[][] InitializeVisualization(HanoiTower algorithm)
        {
            char[][] visualization = new char[algorithm.DiscsCount][];

            for (int y = 0; y < visualization.Length; y++)
            {
                visualization[y] = new char[_columnSize * 3];
                for (int x = 0; x < _columnSize * 3; x++)
                {
                    visualization[y][x] = ' ';
                }
            }

            return visualization;
        }

        private static int GetDiscWidth(int size)
        {
            return 2 * size - 1;
        }
    }

    public class HanoiTower
    {
        public int DiscsCount { get; private set; }
        public int MovesCount { get; private set; }
        public Stack<int> From { get; private set; }
        public Stack<int> To { get; private set; }
        public Stack<int> Auxiliary { get; private set; }

        public event EventHandler<EventArgs> MoveCompleted;

        public HanoiTower(int discs)
        {
            DiscsCount = discs;
            From = new Stack<int>();
            To = new Stack<int>();
            Auxiliary = new Stack<int>();

            //Faz a carga da pilha from com os discos
            for (int i = 1; i <= discs; i++)
            {
                int size = discs - i + 1;
                From.Push(size);
            }
        }

        public void Start()
        {
            Move(DiscsCount, From, To, Auxiliary);
        }

        public void Move(int discs,
        Stack<int> from,
        Stack<int> to,
        Stack<int> auxiliary)
        {
            if (discs > 0)
            {
                Move(discs - 1, from, auxiliary, to);

                to.Push(from.Pop());
                MovesCount++;
                MoveCompleted?.Invoke(this, EventArgs.Empty);

                Move(discs - 1, auxiliary, to, from);
            }
        }
    }
}
