using System;
using System.Text;

public class OldPhonePadDecoder
{
public static String OldPhonePad(string input) {
    var keyMap = new string[]
    {
        "", //for pad 0
        "", //for pad 1
        "ABC", //for pad 2
        "DEF", //for pad 3
        "GHI", //for pad 4
        "JKL", //for pad 5
        "MNO", //for pad 6
        "PQRS", //for pad 7
        "TUV", //for pad 8
        "WXYZ", //for pad 9
    };
    
    StringBuilder output = new StringBuilder();
    int count = 0;
    char lastChar= ' ';


    foreach (char currentChar in  input)
    {
        if (currentChar == '#')
        {
            if (char.IsDigit(lastChar))
            {
                int digit = lastChar - '0';
                output.Append(keyMap[digit][(count-1) % keyMap[digit].Length]);
            }
            
            break;
        }
        if (currentChar == '*')
        {
            if(output.Length > output.Length + 1) {
            output.Length--;
            }
            lastChar = ' ';
            count = 0;
            continue;
        }

        if(currentChar == ' ')
        { 
            if(char.IsDigit(lastChar))
            {
                int digit = lastChar - '0';
                output.Append(keyMap[digit][(count - 1) % keyMap[digit].Length]);
            }
            lastChar = ' ';
            count = 0;
            continue;
        }

        if (char.IsDigit(currentChar))
        {
            if(currentChar == lastChar)
            {
                count++;
            }
            else
            {
                if(char.IsDigit(lastChar))
                {
                    int digit = lastChar - '0';
                    output.Append(keyMap[digit][(count-1) % keyMap[digit].Length]);
                }
                lastChar = currentChar;
                count = 1;
            }
        }
    }
    return output.ToString();
}
}
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(OldPhonePadDecoder.OldPhonePad("33#"));
        Console.WriteLine(OldPhonePadDecoder.OldPhonePad("227*#"));
        Console.WriteLine(OldPhonePadDecoder.OldPhonePad("4433555 555666#"));
        Console.WriteLine(OldPhonePadDecoder.OldPhonePad("8 88777444666*664#"));
    }
}