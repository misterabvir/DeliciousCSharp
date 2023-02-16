using System.Runtime.CompilerServices;

namespace ReallyBigNumbers;

public class BigNumber
{
    private string presentation;
    private List<int> digits => presentation.Reverse().Select(item => Convert.ToInt32(item) - 48).ToList();
    private int length => digits.Count;

    public BigNumber(string presentation)
    {
        this.presentation = Normalize(presentation);
    }
       
    private string Normalize(string presentation) =>  //48...57
        string.Join("", presentation.Where(x => (int)x >= 48 && (int)x <= 57 ))
              .TrimStart('0');

    static public BigNumber operator +(BigNumber n1, BigNumber n2)
    {
        var num1 = n1.digits;
        var num2 = n2.digits;
        
        List<int> result = new List<int>();
        for (int i = 0;;i++)
        {
            if (i < num1.Count && i < num2.Count)
                result.Add(num1[i] + num2[i]);
            else if (i >= num1.Count && i < num2.Count)
                result.Add(num2[i]);
            else if (i < num1.Count && i >= num2.Count)
                result.Add(num1[i]);
            else break;
        }

        for (int i = 0; i < result.Count; i++)
        {
            if (result[i] >= 10)
            {
                result[i] %= 10;
                if (i + 1 < result.Count)
                {
                    result[i + 1]++;
                }
                else
                {
                    result.Add(1);
                }
            }
        }

        return new BigNumber(string.Join("", result.Reverse<int>()));
    }



    public override string ToString()
    {
        return presentation;
    }
}
