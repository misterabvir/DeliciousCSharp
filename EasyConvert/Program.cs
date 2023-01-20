string correctInput = "123456";                           // правильный формат
string? nullInput = null;                                 // отсутствие значения
string wrongInput = "123,456,789";                        // неверный формат
string emptyInput = "";                                   // пустое значение
string overInput = "999999999999999999";                  // переполнение

int result;
bool check;

try
{
    result = int.Parse(correctInput);                     // 123456
    //result = int.Parse(nullInput);                      // System.ArgumentNullException Message: Value cannot be null.
    //result = int.Parse(wrongInput);                     // System.FormatException       Message: The input string '123,456,789' was not in a correct format.
    //result = int.Parse(emptyInput);                     // System.FormatException       Message: The input string '' was not in a correct format.
    //result = int.Parse(overInput);                      // System.OverflowException     Message: Value was either too large or too small for an Int32.

    result = Convert.ToInt32(correctInput);               // 123456
    result = Convert.ToInt32(nullInput);                  // 0
    //result =Convert.ToInt32(wrongInput);                // System.FormatException       Message: The input string '123,456,789' was not in a correct format.
    //result =Convert.ToInt32(emptyInput);                // System.FormatException       Message: The input string '' was not in a correct format.
    //result =Convert.ToInt32(overInput);                 // System.OverflowException     Message: Value was either too large or too small for an Int32.

    check = int.TryParse(correctInput, out result);       // check = true,  result = 123456
    check = int.TryParse(nullInput, out result);          // check = false
    check = int.TryParse(wrongInput, out result);         // check = false
    check = int.TryParse(emptyInput, out result);         // check = false
    check = int.TryParse(overInput, out result);          // check = false

}
catch (ArgumentNullException exc)
{

    Console.WriteLine($"{exc.GetType()} Message: {exc.Message}");
}
catch (FormatException exc)
{

    Console.WriteLine($"{exc.GetType()} Message: {exc.Message}");
}
catch (Exception exc)
{

    Console.WriteLine($"{exc.GetType()} Message: {exc.Message}");
}