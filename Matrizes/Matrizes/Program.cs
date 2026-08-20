//Vetor Bi-Dimensional
int[, ] numbersBi = new int[5, 2];

//Vetor Tri-Dimensional
int [, , ] numbersTri = new int[5, 4, 3];

// Podemos combinar a declaração com a inicialização
// Exemplo de um 4x3
int[,] newNumbersBi = new int [,] 
{
    {9, 5, -9 },
    {-11, 4, 0 },
    {6, 115, 3 },
    {-12, -9, 71 },
    {1, -6, -1 }
};

//Percorrendo a matriz (exemplo de repetição for encadeada)
//Nested/Chained For
for (int i =0; i < newNumbersBi.GetLength(0); i++) {
    for (int j = 0; j < newNumbersBi.GetLength(1); j++) {
        Console.Write($"[{newNumbersBi[i,j]}]");
    }
    Console.WriteLine("");
}

//Jagged Arrays
//Vetor de vetores

int[][] jaggedNumbers = new int[3][];

//Atribuindo valores
jaggedNumbers[0] = new int[] {9, 5, -9};
jaggedNumbers[1] = new int[] {0, -3, 12, 51, -3};
jaggedNumbers[3] = new int[] {51};

//Declaração com inicialização

int[][] jaggedNumbers2 = {
    new int[] {0, 1, 2},
    new int[] {3, 4, 5, 6},
    new int[] {7, 8, 9, 10}
};

//Para receber uma posição específica
int n = jaggedNumbers[1][2];
jaggedNumbers[1][2] = 22;

Console.WriteLine ("n = "+n);
Console.WriteLine ("jaggedNumbers[1][2] = " + jaggedNumbers[1][2]);

