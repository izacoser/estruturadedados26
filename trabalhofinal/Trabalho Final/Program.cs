using System;
using System.Collections.Generic;

class Program
{
    // Lista de tarefas e pilha de identificadores concluídos.
    static List<Tarefa> tarefas = new List<Tarefa>();
    static Stack<int> concluidas = new Stack<int>();
    static int proximoId = 1;

    static void Main()
    {
        int opcao;

        do
        {
            Console.WriteLine();
            Console.WriteLine("===== GERENCIADOR DE TAREFAS =====");
            Console.WriteLine("1 - Cadastrar tarefa");
            Console.WriteLine("2 - Listar tarefas");
            Console.WriteLine("3 - Buscar tarefa (por ID ou nome)");
            Console.WriteLine("4 - Concluir tarefa");
            Console.WriteLine("5 - Desfazer a última conclusão");
            Console.WriteLine("6 - Sair");
            Console.Write("Escolha uma opção: ");

            var entrada = Console.ReadLine();
            if (entrada == null)
            {
                break;
            }

            if (int.TryParse(entrada, out opcao) == false)
            {
                opcao = 0;
            }

            switch (opcao)
            {
                case 1:
                    CadastrarTarefa();
                    break;
                case 2:
                    ListarTarefas();
                    break;
                case 3:
                    BuscarTarefa();
                    break;
                case 4:
                    ConcluirTarefa();
                    break;
                case 5:
                    DesfazerConclusao();
                    break;
                case 6:
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            // Pergunta se o usuário deseja continuar após uma operação.
            if (opcao >= 1 && opcao <= 5)
            {
                if (DesejaContinuar() == false)
                {
                    opcao = 6;
                }
            }
        }
        while (opcao != 6);

        Console.WriteLine("Encerrando a aplicação...");
    }

    static bool DesejaContinuar()
    {
        while (true)
        {
            Console.WriteLine();
            Console.Write("Deseja realizar mais uma operação? (S/N): ");
            var resposta = Console.ReadLine();

            if (resposta == "S" || resposta == "s")
            {
                return true;
            }

            if (resposta == "N" || resposta == "n" || resposta == null)
            {
                return false;
            }

            Console.WriteLine("Resposta inválida! Digite S ou N.");
        }
    }

    static void CadastrarTarefa()
    {
        Console.Write("Digite a descrição da tarefa: ");
        var descricao = Console.ReadLine();

        if (descricao == null || descricao == "")
        {
            Console.WriteLine("A descrição não pode ficar vazia.");
            return;
        }

        Tarefa nova = new Tarefa();
        nova.Id = proximoId;
        nova.Descricao = descricao;
        nova.Situacao = "Pendente";

        tarefas.Add(nova);
        proximoId++;

        Console.WriteLine("Tarefa cadastrada com sucesso! ID: " + nova.Id);
    }

    static void ListarTarefas()
    {
        if (tarefas.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa cadastrada.");
            return;
        }

        Console.WriteLine("--- LISTA DE TAREFAS ---");
        foreach (Tarefa tarefa in tarefas)
        {
            MostrarTarefa(tarefa);
        }
    }

    static void BuscarTarefa()
    {
        if (tarefas.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa cadastrada.");
            return;
        }

        Console.WriteLine("1 - Buscar por ID");
        Console.WriteLine("2 - Buscar por nome");
        Console.Write("Escolha uma opção de busca: ");
        var opcaoBusca = Console.ReadLine();

        switch (opcaoBusca)
        {
            case "1":
                BuscarPorId();
                break;
            case "2":
                BuscarPorNome();
                break;
            default:
                Console.WriteLine("Opção inválida!");
                break;
        }
    }

    static void BuscarPorId()
    {
        Console.Write("Digite o ID da tarefa: ");
        int id;

        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            Console.WriteLine("ID inválido! Digite um número inteiro.");
            return;
        }

        foreach (Tarefa tarefa in tarefas)
        {
            if (tarefa.Id == id)
            {
                MostrarTarefa(tarefa);
                return;
            }
        }

        Console.WriteLine("Tarefa não encontrada.");
    }

    static void BuscarPorNome()
    {
        Console.Write("Digite o nome ou parte da descrição da tarefa: ");
        var nome = Console.ReadLine();

        if (nome == null || nome == "")
        {
            Console.WriteLine("Digite um nome para buscar.");
            return;
        }

        bool encontrou = false;

        foreach (Tarefa tarefa in tarefas)
        {
            if (tarefa.Descricao.ToLower().Contains(nome.ToLower()))
            {
                MostrarTarefa(tarefa);
                encontrou = true;
            }
        }

        if (encontrou == false)
        {
            Console.WriteLine("Nenhuma tarefa encontrada com esse nome.");
        }
    }

    static void ConcluirTarefa()
    {
        if (tarefas.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa cadastrada.");
            return;
        }

        Console.Write("Digite o ID da tarefa que deseja concluir: ");
        int id;

        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            Console.WriteLine("ID inválido! Digite um número inteiro.");
            return;
        }

        foreach (Tarefa tarefa in tarefas)
        {
            if (tarefa.Id == id)
            {
                if (tarefa.Situacao == "Concluída")
                {
                    Console.WriteLine("Essa tarefa já está concluída.");
                    return;
                }

                tarefa.Situacao = "Concluída";
                concluidas.Push(id);
                Console.WriteLine("Tarefa concluída com sucesso!");
                return;
            }
        }

        Console.WriteLine("Tarefa não encontrada.");
    }

    static void DesfazerConclusao()
    {
        if (concluidas.Count == 0)
        {
            Console.WriteLine("Não há nenhuma conclusão para desfazer.");
            return;
        }

        // Retira o último identificador inserido na pilha.
        int id = concluidas.Pop();

        foreach (Tarefa tarefa in tarefas)
        {
            if (tarefa.Id == id)
            {
                tarefa.Situacao = "Pendente";
                Console.WriteLine("Conclusão desfeita! ID: " + id);
                return;
            }
        }
    }

    static void MostrarTarefa(Tarefa tarefa)
    {
        Console.WriteLine("ID: " + tarefa.Id +
                          " | Descrição: " + tarefa.Descricao +
                          " | Situação: " + tarefa.Situacao);
    }
}

public class Tarefa
{
    public int Id { get; set; }
    public string Descricao { get; set; } = "";
    public string Situacao { get; set; } = "Pendente";
}
