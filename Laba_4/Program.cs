using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Laba_4
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();

        static int[][] TransportMatrix(int[][] h)
        {
            int n = h.Length;
            int[][] g = new int[n][];
            for (int i = 0; i < n; i++)
                g[i] = new int[1];

                for (int i = 0, st = 0; i < n; i++)
                {
                    if (h[i][0] > 0)
                    {
                        for (int j = 1; j <= h[i][0]; j++)
                        {
                            if (h[i][j] > i)
                            {
                                if (st > 0)
                                    for (int k = 0; k < n; k++ )
                                        g[k] = AddPost(g[k]);
                                g[i][st] = 1;
                                g[h[i][j] - 1][st] = 1;
                                st++;
                            }
                        }
                    }
                }
            return g;
        }

        static int[][] TransportList(int[][] g)
        {
            int n = g.Length;
            int m = g[0].Length;
            int[][] h = new int[n][];
            for (int i = 0; i < n; i++)
                h[i] = new int[n];

            for (int i = 0; i < n; i++ )
            {
                int st = 1;
                for (int j = 0; j < m; j++)
                {
                    if (g[i][j] == 1)
                    {
                        h[i][0] += 1;
                        for (int k = 0; k < n; k++)
                        {
                            if (k != i && g[k][j] == 1)
                            {
                                h[i][st] = k + 1;
                                st++;
                                break;
                            }
                        }
                    }
                }
            }
            return h;
        }

        static int[] AddPost(int[] g)
        {
            int[] mix = g;
            g = new int[g.Length + 1];
            for (int i = 0; i < mix.Length; i++)
            {
                g[i] = mix[i];
            }
            return g;
        }

        static int[][] TransportMatrixOrentir(int[][] h)
        {
            int n = h.Length;
            int[][] g = new int[n][];
            for (int i = 0; i < n; i++)
                g[i] = new int[1];

            for (int i = 0, st = 0; i < n; i++)
            {
                if (h[i][0] > 0)
                {
                    for (int j = 1; j <= h[i][0]; j++)
                    {
                        if (st > 0)
                            for (int k = 0; k < n; k++)
                                g[k] = AddPost(g[k]);
                        g[i][st] = 1;
                        g[h[i][j] - 1][st] = -1;
                        st++;
                    }
                }
            }
            return g;
        }

        static int[][] TransportListOrentir(int[][] g)
        {
            int n = g.Length;
            int m = g[0].Length;
            int[][] h = new int[n][];
            for (int i = 0; i < n; i++)
                h[i] = new int[m];

            for (int i = 0; i < n; i++)
            {
                int st = 1;
                for (int j = 0; j < m; j++)
                {
                    if (g[i][j] == 1)
                    {
                        h[i][0] += 1;
                        for (int k = 0; k < n; k++)
                        {
                            if (k != i && g[k][j] == -1)
                            {
                                h[i][st] = k + 1;
                                st++;
                                break;
                            }
                        }
                    }
                }
            }
            return h;
        }


        [STAThread]
        static void Main()
        {


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AllocConsole();

            int[][] g = null;
            int[][] h = null;
            int width = 700;
            int height = 700;

            while (true)
            {
                Console.WriteLine("1. Ввести граф с клавиатуры");
                Console.WriteLine("2. Ввести граф из файла");
                Console.WriteLine("3. Ввести случайный граф");
                Console.WriteLine("4. Записать граф в файл");
                Console.WriteLine("5. Задать размер изображения");
                Console.WriteLine("6. Нарисовать");
                Console.WriteLine("7. Выход");
                
                int action = Input.ReadInt();

                switch (action)
                {
                    case 1:
                        {
                            Console.WriteLine("Вид графа:\n1. неориентированный\n2. ориентированный");
                            int type;
                            while (true)
                            {
                                type = Input.ReadInt();
                                if (type != 1 && type != 2)
                                    Console.Write("Введены неверные данные.\n");
                                else break;
                            }
                            Console.Write("Количество вершин: ");
                            int n = Input.ReadInt();
                            h = new int[n][];
                            for (int i = 0; i < n; i++)
                            {
                                if(type == 1)
                                    Console.Write(" Количество вершин смежных с вершиной " + (i + 1) + ": ");
                                else
                                    Console.Write(" Количество вершин, выходящих из вершины " + (i + 1) + ": ");
                                int m;
                                while (true)
                                {
                                    m = Input.ReadInt();
                                    if (m >= n)
                                        Console.Write("   Колличество смежных вершин должно быть меньше.\n");
                                    else break;
                                }
                                h[i] = new int[m+1];
                                h[i][0] = m;
                                if (m != 0)
                                {
                                    if(type == 1)
                                        Console.Write("  Cмежные вершины с вершиной " + (i + 1) + ": ");
                                    else
                                        Console.Write("  Выходящие из вершины " + (i + 1) + ": ");
                                }
                                for (int j = 1; j <= m; j++)
                                {
                                    bool flag = true;
                                    do
                                    {
                                        int temp = Input.ReadInt();
                                        if (temp != i + 1)
                                        {
                                            bool pool = false;
                                            for (int k = 1; k < m; k++)
                                            {
                                                if (h[i][k] == temp)
                                                    pool = true;
                                            }
                                            if (pool)
                                                    Console.Write("   Мосты не предусмотрены.\n -");
                                            else
                                            {
                                                h[i][j] = temp;
                                                flag = false;
                                            }
                                        }
                                        else Console.Write("   Узлы не предусмотрены.\n -");
                                    } while (flag);
                                }
                            }
                            if (type == 1)
                                g = TransportMatrix(h);
                            else if (type == 2)
                                g = TransportMatrixOrentir(h);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Вид графа:\n1. неориентированный\n2. ориентированный");
                            int type;
                            while (true)
                            {
                                type = Input.ReadInt();
                                if (type != 1 && type != 2)
                                    Console.Write("Введены неверные данные.\n");
                                else break;
                            }
                            Console.WriteLine("Введите имя файла:");
                            Console.ReadLine();
                            string filename = Console.ReadLine();
                            using (System.IO.StreamReader sr = System.IO.File.OpenText(filename))
                            {
                                int n = Input.ReadInt(sr);
                                h = new int[n][]; 
                                for (int i = 0; i < n; i++)
                                {
                                    int m = Input.ReadInt(sr);
                                    h[i] = new int[m+1];
                                    h[i][0] = m;
                                    for (int j = 1; j <= m; j++)
                                    {
                                        h[i][j] = Input.ReadInt(sr);
                                    }
                                }
                            }
                            if (type == 1)
                                g = TransportMatrix(h);
                            else if (type == 2)
                                g = TransportMatrixOrentir(h);
                            break;
                        }
                    case 3:
                        {
                            Random r = new Random();
                            Console.WriteLine("Вид графа:\n1. неориентированный\n2. ориентированный");
                            int type;
                            while (true)
                            {
                                type = Input.ReadInt();
                                if (type != 1 && type != 2)
                                    Console.Write("Введены неверные данные.\n");
                                else break;
                            }
                            Console.WriteLine("Количество вершин:");
                            int n = Input.ReadInt();
                            Console.WriteLine("Количество рёбер:");
                            int m;
                            while (true)
                            {
                                m = Input.ReadInt();
                                if (m >= n && type == 1)
                                    Console.Write("   Колличество рёбер должно быть меньше.\n");
                                else if (m > 2 * n && type == 2)
                                    Console.Write("   Колличество рёбер должно быть меньше.\n");
                                else break;
                            }

                            g = new int[n][];
                            for (int i = 0; i < n; i++)
                                g[i] = new int[m];

                            
                            if (type == 1)
                            {
                                for (int i = 0; i < m; i++)
                                {
                                    int from, to;
                                    do
                                    {
                                        from = r.Next(n);
                                        to = r.Next(n);
                                    } while (from == to);

                                    g[from][i] = g[to][i] = 1;
                                }
                            }
                            else if (type == 2)

                            {
                                for (int i = 0; i < m; i++)
                                {
                                    int from, to;
                                    do
                                    {
                                        from = r.Next(n);
                                        to = r.Next(n);
                                    } while (from == to);

                                    g[from][i] = 1;
                                    g[to][i] = -1;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Генерация отменена!");
                                break;
                            }
                            if(type == 1)
                                h = TransportList(g);
                            else h = TransportListOrentir(g);

                            Console.WriteLine("Список инцидентности:\nКолличество вершин: " + n);
                            for (int i = 0; i < n; i++)
                            {
                                if (type == 1)
                                {
                                    for (int j = 0; j <= m; j++)
                                        if (h[i][j] > 0 || h[i][0] == 0)
                                        {
                                            Console.Write("{0} ", h[i][j]);
                                            if (h[i][0] == 0) break;
                                        }
                                }
                                else
                                {
                                    for (int j = 0; j < m; j++)
                                        if (h[i][j] > 0 || h[i][0] == 0)
                                        {
                                            Console.Write("{0} ", h[i][j]);
                                            if (h[i][0] == 0) break;
                                        }
                                }
                                    Console.WriteLine();
                            }
                            break;
                        }
                    case 4:
                        {
                            if (g == null)
                            {
                                Console.WriteLine("Для начала нужно ввести граф!");
                                break;
                            }
                            Console.WriteLine("Введите имя файла:");
                            Console.ReadLine();
                            string filename = Console.ReadLine();

                            if (System.IO.File.Exists(filename))
                                System.IO.File.Delete(filename);

                            using (System.IO.FileStream fs = System.IO.File.Create(filename, 4096))
                            {
                                int n = h.Length;
                                String output = String.Format("{0}\r\n", n);
                                for (int i = 0; i < n; i++)
                                {
                                    for (int j = 0; j < h[i].Length; j++)
                                        if (h[i][j] > 0 || h[i][0] == 0)
                                        {
                                            output += String.Format("{0} ", h[i][j]);
                                            if (h[i][0] == 0) break;
                                        }
                                    output += "\r\n";
                                }

                                byte[] info = new System.Text.UTF8Encoding(true).GetBytes(output);
                                fs.Write(info, 0, info.Length); 
 
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Ширина:");
                            width = Input.ReadInt();
                            Console.WriteLine("Высота:");
                            height = Input.ReadInt();
                            break;
                        }
                    case 6:
                        {
                            if (g == null)
                                Console.WriteLine("Для начала нужно ввести граф!");
                            else
                                Application.Run(new Form1(width, height, g));
                            break;
                        }
                    case 7:
                        {
                            FreeConsole();
                            return;
                        }
                }
            }
        }
    }
}
