namespace LibMCI;
public class ConsoleInput
{
    private List<int> _ints = new List<int>();

    private void ResponseNewUserInput()
    {
        int[]? array;
        do{
            Console.Write($"Enter some numbers separated by a space: ");
            array = Console.ReadLine()?.Split(' ', ',', '.','_')
                                    .Where(s => int.TryParse(s, out int _))
                                    .Select(s => Convert.ToInt32(s))
                                    .ToArray();
        }while(array == null || array.Length < 1); 

        _ints.AddRange(array);                                                               
    }

    public int GetNextInt()
    {
        if(_ints.Count == 0) ResponseNewUserInput();
        var res = _ints[0];
        _ints.RemoveAt(0);
        return res;
    }

}
