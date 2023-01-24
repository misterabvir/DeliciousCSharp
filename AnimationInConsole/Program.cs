void Animation01(string data)
{
    for (int i = 0; i < data.Length; i++)
    {
        Thread.Sleep(30);
        Console.Write($"\r{data.Substring(0, i + 1)}");
    }
    Console.WriteLine();
}

void Animation02(string data)
{
    for (int i = 0; i < data.Length; i++)
    {
        Thread.Sleep(30);
        Console.Write($"\r{data.Substring(data.Length - 1 - i, i + 1)}");
    }
    Console.WriteLine();
}

void Animation03(string data)
{
    for (int i = 0; i < data.Length; i++)
    {
        Thread.Sleep(30);
        Console.Write($"\r{new string(' ', data.Length - 1 - i)}{data.Substring(data.Length - 1 - i, i + 1)}");
    }
    Console.WriteLine();
}

void Animation04(string data)
{
    for (int i = 0; i < data.Length; i++)
    {
        Thread.Sleep(30);
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
            Thread.Sleep(1);
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
        for (int j = 0; j < data.Length - subs.Length && data[data.Length - i - 1] != ' '; j++)
        {
            Thread.Sleep(1);
            Console.Write($"\r{new string(' ', j)}");
            Console.Write($"{data[data.Length - 1 - i]}");
            Console.Write($"{new string(' ', data.Length - subs.Length - j - 1)}");
            Console.Write($"{subs}");
        }
        subs = data.Substring(data.Length - i - 1, i + 1);
    }
    Console.WriteLine();
}

void Animation07(string data)
{
    string subs1 = "";
    string subs2 = "";
    for (int i = 0; i < data.Length; i++)
    {
        Thread.Sleep(30);
        subs1 = data.Substring(0, i);
        subs2 = data.Substring(i + 1, data.Length - i - 1);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"\r{subs1.ToUpper()}");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("█");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"{subs2}");
        Console.ForegroundColor = ConsoleColor.White;
    }

    for (int i = 0; i < data.Length; i++)
    {
        Thread.Sleep(30);
        subs1 = data.Substring(0, data.Length - i - 1);
        subs2 = data.Substring(data.Length - i, i);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"\r{subs1.ToUpper()}");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("█");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"{subs2}");
        Console.ForegroundColor = ConsoleColor.White;
    }
    Console.WriteLine($"\r{data}");
}

void Animation08(string data)
{
    string subs1 = "";
    string subs2 = "";
    string spaces = "";
    for (int i = 0; i < data.Length / 2 + 1; i++)
    {
        Thread.Sleep(30);
        subs1 = data.Substring(0, i);
        subs2 = data.Substring(data.Length - i - 1, i + 1 );
        spaces = new string(' ', data.Length - 1 - 2 * i);
        Console.Write($"\r{subs1}{spaces}{subs2}");
    }
    Console.WriteLine();
}

void Animation09(string data)
{
    string subs = "";
    string spaces1 = "";
    string spaces2 = "";
    for (int i = 0; i < data.Length / 2 + 1; i++)
    {
        Thread.Sleep(30);
        spaces1 = new string(' ', data.Length / 2 - i);
        spaces2 = new string(' ', data.Length / 2 - i);
        
        subs = data.Substring(data.Length / 2 - i, i * 2 + 1);
        Console.Write($"\r{spaces1}{subs}{spaces2}");
    }
    Console.WriteLine();
}

void Animation10(string data)
{
    string subs1 = "";
    string subs2 = "";
    string spaces = "";
    for (int i = 0; i < data.Length / 2 + 1; i++)
    {
        Thread.Sleep(30);
        subs1 = data.Substring(data.Length / 2 - i, i);
        spaces = new string(' ', data.Length - 2 * i - (data.Length %2 == 0 ? 0 : 1));
        subs2 = data.Substring(data.Length / 2, i + (data.Length %2 == 0 ? 0 : 1));
        Console.Write($"\r{subs1}{spaces}{subs2}    ");
    }
    Console.WriteLine();
}

void Animation11(string data)
{
    string subs1 = "";
    string subs2 = "";
    string spaces1 = "";
    string spaces2 = "";
    for (int i = 0; i < data.Length / 2; i++)
    {
        Thread.Sleep(30);
        spaces1 = new String(' ', data.Length / 2 - i - 1);
        subs1 = data.Substring(0, i + 1);
        subs2 = data.Substring(data.Length - i - (data.Length %2 == 0 ? 1 : 2), i + (data.Length %2 == 0 ? 1 : 2));

        spaces2 = new String(' ', data.Length / 2 - i);

        Console.Write($"\r{spaces1}{subs1}{subs2}{spaces2}");
    }
    //Console.Write($"\r{data}");
    Console.WriteLine();
}

void Animation12(string data)
{
    string[] splits = data.Split(' ');
    
    for (int i = 0; i < splits.Select(s=>s.Length).Max(); i++)
    {
        Thread.Sleep(200);
        for (int j = 0; j < splits.Length; j++)
        {
            
            if( i < splits[j].Length)
            {     
                int left = string.Join(' ', splits.Take(j).ToArray()).Length + (j == 0 ? 0 : 1);            
                Console.SetCursorPosition(left: left + i, top: Console.GetCursorPosition().Top);
                Console.Write(splits[j][i]);
            }
        }
    }
    Console.WriteLine();
}

Console.CursorVisible = false;


string source = "It's not that I'm so smart, it's just that I stay with problems longer.";

Animation01(source);
Animation02(source);
Animation03(source);
Animation04(source);
Animation05(source.Substring(0, 26));
Animation06(source.Substring(0, 26));
Animation07(source);
Animation08(source);
Animation09(source);
Animation10(source);
Animation11(source);
Animation12(source);



Console.CursorVisible = true;