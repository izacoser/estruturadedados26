﻿Dictionary<string, Automovel> automoveis = new Dictionary<string, Automovel>
{
    { "123456", new Automovel("123456", "Honda", "Civic", 2017, "Preto", 90000) },
    { "654321", new Automovel("654321", "Toyota", "Corolla", 2018, "Prata", 85000) },
    { "456123", new Automovel("456123", "Nissan", "March", 2019, "Branco", 50000) }
};

int opcao = 0;

do
{
    Console.WriteLine("\nSISTEMA DE CONTROLE DE AUTOMÓVEIS\n1 - Cadastrar automóvel\n2 - Buscar automóvel pela placa\n3 - Listar todos os automóveis\n4 - Buscar automóveis por marca\n5 - Sair");
    Console.Write("Digite a opção desejada: ");
    opcao = Convert.ToInt32(Console.ReadLine());

    if (opcao == 1)
    {
        Console.Write("Placa: ");
        string placa = Console.ReadLine();

        if (automoveis.ContainsKey(placa))
        {
            Console.WriteLine("Já existe um automóvel com essa placa!");
        }
        else
        {
            Console.Write("Marca: ");
            string marca = Console.ReadLine();

            Console.Write("Modelo: ");
            string modelo = Console.ReadLine();

            Console.Write("Ano: ");
            int ano = Convert.ToInt32(Console.ReadLine());

            Console.Write("Cor: ");
            string cor = Console.ReadLine();

            Console.Write("Valor: ");
            double valor = Convert.ToDouble(Console.ReadLine());

            automoveis.Add(placa, new Automovel(placa, marca, modelo, ano, cor, valor));
            Console.WriteLine("Automóvel cadastrado com sucesso!");
        }
    }
    else if (opcao == 2)
    {
        Console.Write("Digite a placa: ");
        string placa = Console.ReadLine();

        if (automoveis.ContainsKey(placa))
        {
            Automovel carro = automoveis[placa];
            carro.Exibir();
        }
        else
        {
            Console.WriteLine("Nenhum automóvel encontrado com essa placa.");
        }
    }
    else if (opcao == 3)
    {
        if (automoveis.Count == 0)
        {
            Console.WriteLine("Não há automóveis cadastrados.");
        }
        else
        {
            foreach (Automovel carro in automoveis.Values)
            {
                carro.Exibir();
            }
        }
    }
    else if (opcao == 4)
    {
        Console.Write("Digite a marca: ");
        string marcaBusca = Console.ReadLine();
        bool encontrou = false;

        foreach (Automovel carro in automoveis.Values)
        {
            if (carro.Marca.ToLower() == marcaBusca.ToLower())
            {
                carro.Exibir();
                encontrou = true;
            }
        }

        if (encontrou == false)
        {
            Console.WriteLine("Nenhum automóvel encontrado para essa marca.");
        }
    }
    else if (opcao == 5)
    {
        Console.WriteLine("Encerrando o programa...");
    }
    else
    {
        Console.WriteLine("Opção inválida! Tente novamente.");
    }
}
while (opcao != 5);


public class Automovel
{
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public string Cor { get; set; }
    public double Valor { get; set; }

    public Automovel(string placa, string marca, string modelo, int ano, string cor, double valor)
    {
        Placa = placa;
        Marca = marca;
        Modelo = modelo;
        Ano = ano;
        Cor = cor;
        Valor = valor;
    }

    public void Exibir()
    {
        Console.WriteLine("----------------------------");
        Console.WriteLine("Placa: " + Placa);
        Console.WriteLine("Marca: " + Marca);
        Console.WriteLine("Modelo: " + Modelo);
        Console.WriteLine("Ano: " + Ano);
        Console.WriteLine("Cor: " + Cor);
        Console.WriteLine("Valor: R$ " + Valor);
    }
}