using System.Collections.Generic;

Stack<char> chars = new Stack<char>();

foreach (char c in "VAMOS REVERTER")
{
    chars.Push(c);
}

while (chars.Count > 0) 
{
    Console.Write(chars.Pop());
}

Console.WriteLine("");

String reversedText = string.Empty;
foreach (char c in text)
    chars.Push(c);

while (chars.Count > 0)
    reversedText += chars.Pop();

Console.WriteLine(reversedText);

string isPalindromo = text == reversedText
?"é Palíndromo"
: "não é Palíndromo";
