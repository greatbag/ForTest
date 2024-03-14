using System;

class Program
{
    static void Main(string[] args)
    {
        int[] rows = { 3, 5, 7 };
        int totalMatches = 15;
        int currentPlayer = 1;

        while (totalMatches > 0)
        {
            Console.WriteLine("当前剩余牙签数量： " + totalMatches);
            Console.WriteLine("轮到玩家 " + currentPlayer + " 选择。");
            Console.WriteLine("选择行号 (1, 2, 3): ");
            int row = int.Parse(Console.ReadLine()) - 1;
            if (row > 2)
            {
                Console.WriteLine("无效的操作，超过最大行数。请重新选择");
                continue;
            }

            Console.WriteLine("选择拿走的牙签数量: ");
            int matchesToRemove = int.Parse(Console.ReadLine());
            if (  matchesToRemove <= 0)
            {
                Console.WriteLine($"无效的操作，输入数量错误，请重新选择。");

            }
            if (matchesToRemove > rows[row])
            {
                
                Console.WriteLine($"无效的操作，当前行只有{rows[row]}支牙签可以拿走，请重新选择。");
                continue;
            }

            rows[row] -= matchesToRemove;
            totalMatches -= matchesToRemove;
            PrintRows(rows);
            if (totalMatches <= 0)
            {
                Console.WriteLine("玩家 " + currentPlayer + " 输了！");
                break;
            }

            currentPlayer = (currentPlayer == 1) ? 2 : 1;
        }

        static void PrintRows(int[] rows)
        {
            Console.WriteLine("当前牙签情况：");
            for (int i = 0; i < rows.Length; i++)
            {
                Console.Write("第 " + (i + 1) + " 行: ");
                for (int j = 0; j < rows[i]; j++)
                {
                    Console.Write("| ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
