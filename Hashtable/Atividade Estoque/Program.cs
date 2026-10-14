using System.Collections;

// Dicionário: chave = código de barras, valor = código da área
Dictionary<string, string> produtos = new Dictionary<string, string>
{
    { "5900000000000", "A1" },
    { "5901111111111", "B5" },
    { "5902222222222", "C9" }
};

// Segunda forma de adicionar: pelo indexador
produtos["5903333333333"] = "D7";

// Terceira forma de adicionar: método Add (lança ArgumentException se a chave já existir)
try
{
    produtos.Add("5904444444444", "A3");
}
catch (ArgumentException)
{
    Console.WriteLine("A entrada já existe");
}

// Exibe todos os produtos
Console.WriteLine("Produtos:");
if (produtos.Count == 0)
{
    Console.WriteLine("Não há produtos cadastrados");
}
else
{
    foreach (KeyValuePair<string, string> pair in produtos)
    {
        Console.WriteLine($" - {pair.Key}: {pair.Value}");
    }
}

// Busca a localização pelo código de barras
Console.WriteLine();
Console.Write("Procure pelo código: ");
string codigo = Console.ReadLine() ?? "";

if (produtos.TryGetValue(codigo, out string? localizacao))
{
    Console.WriteLine($"O produto está na prateleira: {localizacao}.");
}
else
{
    Console.WriteLine("O produto não existe.");
}