/*CRIE UM PROGRAMA QUE SEJA CAPAZ DE LER 10 NÚMEROS INTEIROS E SEPARÁ-LOS EM DOIS VETORES, UM PARA OS ÍMPARES E OUTRO PARA OS PARES.
AO FINAL, IMPRIMA NA TELA OS PARES E DEPOIS OS ÍMPARES*/

int[] Array = new int[10];
int[] par = new int[10];
int[] impar = new int[10];
int pares = 0;
int impares = 0;

for (int i = 0; i < Array.Length; i++)
{
    Console.Write($"Digite o valor de [{i}]: ");
    Array[i] = Convert.ToInt32(Console.ReadLine());
    
    if (Array[i] % 2 == 0)
    {
        par[pares] = Array[i];
        pares++;
    }
    else
    {
        impar[impares] = Array[i];
        impares++;
    }
}

Console.WriteLine("\nOs números pares são:");
for (int i = 0; i < pares; i++){
    Console.Write(par[i] + " ");
}

Console.WriteLine("\nOs números ímpares são:");
for (int i = 0; i < impares; i++){
    Console.Write(impar[i] + " ");
}
