using LibMCI;

namespace LibMCI.TestConsole;
class Program
{
    static void Main()
    {
        ConsoleInput ci = new ConsoleInput(); //!!!
        int num1 = ci.GetNextInt();
        int num2 = ci.GetNextInt();
        int num3 = ci.GetNextInt();
        int num4 = ci.GetNextInt();
        int num5 = ci.GetNextInt();
        int num6 = ci.GetNextInt();
        int num7 = ci.GetNextInt();
        int num8 = ci.GetNextInt();

        Console.WriteLine($"num1 = {num1}");
        Console.WriteLine($"num2 = {num2}");
        Console.WriteLine($"num3 = {num3}");
        Console.WriteLine($"num4 = {num4}");
        Console.WriteLine($"num5 = {num5}");
        Console.WriteLine($"num6 = {num6}");
        Console.WriteLine($"num7 = {num7}");
        Console.WriteLine($"num8 = {num8}");
    }
}

/*
Enter some numbers separated by a space: 1 2 3
Enter some numbers separated by a space: 4_5_6
Enter some numbers separated by a space: 7,8
num1 = 1
num2 = 2
num3 = 3
num4 = 4
num5 = 5
num6 = 6
num7 = 7
num8 = 8

Enter some numbers separated by a space: 1,. _2,. _3
Enter some numbers separated by a space: 4_5.6
Enter some numbers separated by a space: 7,8
num1 = 1
num2 = 2
num3 = 3
num4 = 4
num5 = 5
num6 = 6
num7 = 7
num8 = 8

Enter some numbers separated by a space:     I LOVE C# 1 2 3
Enter some numbers separated by a space: 4 I 5 LOVE 6 C#
Enter some numbers separated by a space:   I_7_LOVE_8_C#
num1 = 1
num2 = 2
num3 = 3
num4 = 4
num5 = 5
num6 = 6
num7 = 7
num8 = 8
*/