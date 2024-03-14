using System;

class Program
{
    static void Main(string[] args)
    {
        // 定义每行牙签的数量
        int[] rows = { 3, 5, 7 };
        // 初始总牙签数量
        int totalMatches = 15;
        // 当前玩家编号
        int currentPlayer = 1;

        // 游戏主循环，直到所有牙签被拿完
        while (totalMatches > 0)
        {
            // 显示当前剩余牙签数量
            PrintRows(rows);
            // 提示玩家选择行号
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

            // 验证玩家选择是否合法
            if (matchesToRemove <= 0)
            {
                Console.WriteLine($"无效的操作，输入数量错误，请重新选择。");

            }
            if (matchesToRemove > rows[row])
            {
                Console.WriteLine($"无效的操作，当前行只有{rows[row]}支牙签可以拿走，请重新选择。");
                continue;
            }


            // 更新行中牙签数量和总牙签数量
            rows[row] -= matchesToRemove;
            totalMatches -= matchesToRemove;

     

            // 若总牙签数量为0，则当前玩家输掉游戏
            if (totalMatches <= 0)
            {
                Console.WriteLine("玩家 " + currentPlayer + " 输了！");
                break;
            }

            // 切换当前玩家
            currentPlayer = (currentPlayer == 1) ? 2 : 1;
        }

        // 输出每行剩余牙签的图形表示
        static void PrintRows(int[] rows)
        {
            Console.WriteLine("当前牙签情况：");
            for (int i = 0; i < rows.Length; i++)
            {
                Console.Write("第 " + (i + 1) + " 行: ");
                for (int j = 0; j < rows[i]; j++)
                {
                    Console.Write("| "); // 以 "|" 表示每根牙签
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
