var str1 = "qwerty";
var str2 = "qwerty";

var length = str1.Length;

// Code inside unsafe just reverts string
unsafe
{
    fixed (char* c = str1)
    {
        for (int i = 0; i < length / 2; i++)
        {
            (c[i], c[length - i - 1]) = (c[length - i - 1], c[i]);
        }
    }
}


Console.WriteLine($"== - {str1 == str2}");
Console.WriteLine($"object.Equals - {Equals(str1, str2)}");
Console.WriteLine($"object.ReferenceEquals - {ReferenceEquals(str1, str2)}");

Console.WriteLine("qwerty");

Console.WriteLine(str1);
Console.WriteLine(str2);