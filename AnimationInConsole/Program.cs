void Animation01(string data)
{
    for (int i = 0; i < data.Length; i++)
    {
        Thread.Sleep(100);
        Console.Write($"\r{data.Substring(0, i + 1)}");
    }
    Console.WriteLine();
}

void Animation02(string data)
{
    for (int i = 0; i < data.Length; i++)
    {
        Thread.Sleep(100);
        Console.Write($"\r{data.Substring(data.Length - 1 - i, i + 1)}");
    }
    Console.WriteLine();
}

void Animation03(string data)
{
    for (int i = 0; i < data.Length; i++)
    {
        Thread.Sleep(100);
        Console.Write($"\r{new string(' ', data.Length - 1 - i)}{data.Substring(data.Length - 1 - i, i + 1)}");
    }
    Console.WriteLine();
}

void Animation04(string data)
{
    for (int i = 0; i < data.Length; i++)
    {
        Thread.Sleep(100);
        Console.Write($"\r{new string(' ', data.Length - 1 - i)}{data.Substring(0, i + 1)}");
    }
    Console.WriteLine();
}

void Animation05(string data)
{
    string subs = "";
    for (int i = 0; i < data.Length; i++)
    {
        for (int j = i; j < data.Length && data[i] != ' '; j++)
        {
            Thread.Sleep(10 + 2 * i);
            Console.Write($"\r{subs}");
            Console.Write($"{new string(' ', data.Length - 1 - j)}");
            Console.Write($"{data[i]}");
            Console.Write($"{new string(' ', j - subs.Length)}");            
        }
        subs = data.Substring(0, i + 1);
    }
    Console.WriteLine();
}

void Animation06(string data)
{
    string subs = "";
    for (int i = 0; i < data.Length; i++)
    {
        for (int j = 0; j < data.Length - subs.Length   && data[data.Length - i - 1] != ' '; j++)
        {
            Thread.Sleep(10 + 2 * i);
            Console.Write($"\r{new string(' ', j)}");
            Console.Write($"{data[data.Length - 1 - i]}");
            Console.Write($"{new string(' ', data.Length - subs.Length - j - 1)}");            
            Console.Write($"{subs}");
        }
        subs = data.Substring(data.Length - i - 1, i+1);
    }
    Console.WriteLine();
}

void Animation07(string data)
{
    string subs1 = "";
    string subs2 = "";
    for (int i = 0; i < data.Length; i++)
    {
        Thread.Sleep(50);
        subs1 = data.Substring(0, i);
        subs2 = data.Substring(i + 1, data.Length - i - 1);
        Console.Write($"\r{subs1}█{subs2}");
    }

    for (int i = 0; i < data.Length; i++)
    {
        Thread.Sleep(50);
        subs1 = data.Substring(0, data.Length - i - 1);
        subs2 = data.Substring(data.Length - i, i);
        Console.Write($"\r{subs1}█{subs2}");
    }
    Console.WriteLine($"\r{data}");
} 

Console.CursorVisible = false;


Animation01("Cool console animation 01");
Animation02("Cool console animation 02");
Animation03("Cool console animation 03");
Animation04("Cool console animation 04");
Animation05("Cool console animation 05");
Animation06("Cool console animation 06");
Animation07("Cool console animation 07");
