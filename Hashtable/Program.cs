﻿using System.Collections;

Hashtable phoneBook = new Hashtable()
{
    {"Edson Arantes do Nascimento", "0000"},
    {"Ronaldo Nazáreo dos Santos", "1111"},
    {"Luiz Inácio Lula da Silva", "2222"}
};

//Adicionando em tempo de execução
phoneBook["Acelino Popó de Freitas"] = "33333";

//Tratando possível erro de duplicidade de chave

try
{
    phoneBook.Add("Edson Arantes do Nascimento", "00000");
} 
catch (System.ArgumentException ae)
{
    Console.WriteLine("Chave já existente " + ae.Message);
}

catch (System.Exception ex) 
{
    Console.WriteLine("Erro imprevisto " + ex.Message);
    throw;
};

//Percorrendo valores TabelaHash
Console.WriteLine("Caderninho de telefone: ");

if (phoneBook.Count == 0)
{
    Console.WriteLine("Agenda vazia");
}
else
{
    int i =1;
    foreach (DictionaryEntry entry in phoneBook)
    {
        Console.WriteLine($"{i}. {entry.Key} - {entry.Value}");
        i++;
    }
}

//Busca em chave
Console.WriteLine("");
Console.WriteLine("Busca por nome:");
string name = Console.ReadLine();

if (phoneBook.Contains (name))
{
    string number = (string)phoneBook[name];
    Console.WriteLine(name + " - " + number);
}
else
{
    Console.WriteLine($"{name} não encontrado");
}

/*
Dicionários
*/

Dictionary<string, string> dic = new Dictionary<string, string> ()
{
    {"Dom Predro II", "123456"},
    {"Joaquim José da Silva Xavier", "112233"}
};

//Obtendo valor do dicionário
string number = dic["Dom Pedro II"];

dic["Dom Pedro II"] = "666";

foreach (KeyValuePair<string, string> pair in dic)
{
    Console.WriteLine("" + pair.Key + " " + pair.Value);
}