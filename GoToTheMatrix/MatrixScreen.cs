using System;
using System.Threading;
namespace GoToTheMatrix;

public class MatrixScreen
{
    int cols => 10;
    int rows => 20;
    int delay = 200;
    int countOfSpaces = 10;
    List<string> columns = new List<string>();
    List<char> symbols = new List<char>();
    int[] speeds;

    public MatrixScreen()
    {
        speeds = new int[cols];
        FillSymbols();
        FillColumns();
        FillSpeeds();
    }
    
    private void FillSymbols()
    {
        symbols.AddRange(Enumerable.Range(48, 10).Select(item => (char)item));
        symbols.AddRange(Enumerable.Range(65, 26).Select(item => (char)item));
        symbols.AddRange(Enumerable.Range(97, 26).Select(item => (char)item));
        for (int i = 0; i < countOfSpaces; i++)
        {
            symbols.Add(' ');
        }
    }
    
    public void FillColumns()
    {
        for (int i = 0; i < cols; i++)
        {
            columns.Add(GetRandomString());
        }
    }

    private string GetRandomString()
    {
        Random rand = new Random();
        var index = -1;
        for (int i = 0; i < symbols.Count; i++)
        {
            index = rand.Next(0, symbols.Count);
            (symbols[i], symbols[index]) = (symbols[index], symbols[i]);
        }
        return string.Join("", symbols);
    }

    private void FillSpeeds()
    {
        Random rand = new Random();
        for (int i = 0; i < cols; i++)
        {
            speeds[i] = rand.Next(1, 5);           
        }
    }

    public void Start()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        while(true)
        {
            Thread.Sleep(delay);
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < rows; i++)
            {
                var str = string.Join(" ", columns.Select(item => item[i]));
                Console.WriteLine(str);
            }
            Modify();
        }
    }

    private void Modify()
    {
        var index = -1;
        var length = -1;
        for (int i = 0; i < cols; i++)
        {
            index = speeds[i];
            length = columns[i].Length;
            columns[i] = 
                columns[i].Substring(length - index - 1, index) +
                columns[i].Substring(0, length - index);
        }
    }
}
