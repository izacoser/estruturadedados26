/*ESCREVA UM PROGRAMA QUE LEIA UMA PALAVRA DIGITADA PELO USUÁRIO E IDENTIFIQUE SE A PALAVRA É OU NÃO UM PALÍNDROMO (OVO, MUSSUM, ARARA)*/

Console.WriteLine("Escreva uma palavra: ");
string palavra = Console.ReadLine();

int quantletras = palavra.Length;
int[] Array = new int[quantletras];
int[] invertida = new int[quantletras];
int palindromo = 1; 

for (int i = 0; i < quantletras; i++)
{
    Array[i] = (int)palavra[i];
}

for (int i = 0; i < quantletras; i++)
{
    invertida[i] = Array[quantletras - 1 - i];
}

for (int i = 0; i < quantletras; i++)
{
    if (Array[i] != invertida[i])
    {
        palindromo = 0;
    }
}

if (palindromo == 1)
{
    Console.WriteLine("É um palíndromo");
}
else
{
    Console.WriteLine("Não é um palíndromo");
}