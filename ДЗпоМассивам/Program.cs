// See https://aka.ms/new-console-template for more information
string tmp;
bool flag;
int x, y;
Console.WriteLine("Введите размер массива Array[x,y]");
do
{
    Console.Write("x = ");
    tmp = Console.ReadLine();
    flag = int.TryParse(tmp, out x);
    if (!flag || x <= 0)
    {
        Console.WriteLine("Ошибка ввода измерения массива");
        flag = false;
    }
} while (!flag);

do
{
    Console.Write("y = ");
    tmp = Console.ReadLine();
    flag = int.TryParse(tmp, out y);
    if (!flag || y <= 0)
    {
        Console.WriteLine("Ошибка ввода измерения массива");
        flag = false;
    }
} while (!flag);

int[,] num = new int[x, y];

Console.WriteLine($"Введите {num.Length} элементов\nмассива используя Enter:");

for (int i = 0; i < num.GetLength(0); i++)
{
    for (int j = 0; j < num.GetLength(1); j++)
    {
        Console.Write($"{i * num.GetLength(1) + j + 1}-[{i},{j}] = ");
        tmp = Console.ReadLine();
        flag = int.TryParse(tmp, out num[i, j]);
        if (!flag)
        {
            Console.WriteLine("Ошибка ввода, введите число!!!");
            j--;
        }


    }
}

Console.WriteLine($"Ваш массив Array[{x},{y}]:");
Show(num);

Console.Write("Нажмите если надо:\n" +
    "Найти количество положительных/отрицательных чисел - 1\n" +
    "Сортировка элементов матрицы построчно (в двух направлениях) - 2\n" +
    "Инверсия элементов матрицы построчно - 3\n");
int n;

do
{
    tmp = Console.ReadLine();
    flag = int.TryParse(tmp, out n);
    if (!flag) Console.WriteLine($"\"{tmp}\"--Введите цифры от 1 до 3");

} while (!flag);


int[,] Nnum = new int[x, y];
Array.Copy(num, Nnum, num.Length);//создаем копию массива

int a = 0, b = 0;
switch (n)
{
    case 1:

        for (int i = 0; i < num.GetLength(0); i++)
        {
            for (int j = 0; j < num.GetLength(1); j++)
            {
                if (num[i, j] < 0) a++;
                else if (num[i, j] > 0) b++;
            }

        }
        Console.WriteLine($"В массиве:\nПоложительных чисел - {b}\n" +
                          $"Отрицательных чисел - {a}");
        break;
    case 2:
        Console.WriteLine("Сортировка построчно:");
        Console.WriteLine("По возрастанию:");

        for (int i = 0; i < num.GetLength(0); i++)
        {
            for (int j = 0; j < num.GetLength(1); j++)
            {
                for (int k = 0; k < num.GetUpperBound(1); k++)
                {
                    if (num[i, k] > num[i, k + 1])
                    {
                        a = num[i, k];
                        num[i, k] = num[i, k + 1];
                        num[i, k + 1] = a;
                    }

                    if (Nnum[i, k] < Nnum[i, k + 1])
                    {
                        a = Nnum[i, k];
                        Nnum[i, k] = Nnum[i, k + 1];
                        Nnum[i, k + 1] = a;
                    }
                }
            }
        }
        Show(num);
        Console.WriteLine("или по убыванию:");
        Show(Nnum);
        break;

    case 3:
        Console.WriteLine("Инверсия массива:");
        for (int i = 0; i < num.GetLength(0); i++)
        {
            for (int j = 0; j < num.GetLength(1); j++)
            {
                b = i * num.GetLength(1) + j + 1;

                if (b > num.Length / 2) break;
                a = num[i, j];
                num[i, j] = num[num.GetUpperBound(0) - i, num.GetUpperBound(1) - j];
                num[num.GetUpperBound(0) - i, num.GetUpperBound(1) - j] = a;

            }
        }

        Show(num);

        Console.WriteLine("или инверсия массива построчно:");
        for (int i = 0; i < Nnum.GetLength(0); i++)
        {
            for (int j = 0; j < Nnum.GetLength(1) / 2; j++)
            {
                b = Nnum[i, j];
                Nnum[i, j] = Nnum[i, Nnum.GetUpperBound(1) - j];
                Nnum[i, Nnum.GetUpperBound(1) - j] = b;
            }

        }
        Show(Nnum);

        break;
    default:
        Console.WriteLine($"Вы выбрали {n}, а надо 1,2 или 3 !!!");
        break;
}
Console.ReadKey();
// метод для вывода массива на консоль в виде матрицы
static void Show(int[,] num)
{
    for (int i = 0; i < num.GetLength(0); i++)
    {
        for (int j = 0; j < num.GetLength(1); j++)
        {
            Console.Write("{0,-3} ", num[i, j]);
        }
        Console.WriteLine();
    }
}