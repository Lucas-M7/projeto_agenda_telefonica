using agenda_telefonica.contatos;
using agenda_telefonica.agenda;

Agenda agenda = new Agenda();

agenda.CarregarAgenda("Arquivo\\agenda.json");

while (true)
{
    Console.WriteLine("\nEscolha uma opção:");
    Console.WriteLine("1. Adicionar Contato");
    Console.WriteLine("2. Mostrar Contatos");
    Console.WriteLine("3. Editar Contato");
    Console.WriteLine("4. Excluir Contato");
    Console.WriteLine("5. Salvar Agenda");
    Console.WriteLine("6. Sair");

    int escolha = int.Parse(Console.ReadLine());

    switch (escolha)
    {
        case 1:
            AdicionarContato(agenda);
            break;
        case 2:
            agenda.MostrarContatos();
            break;
        case 3:
            EditarContato(agenda);
            break;
        case 4:
            ExcluirContato(agenda);
            break;
        case 5:
            agenda.SalvarAgenda("agenda.json");
            break;
        case 6:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente");
            break;
    }
}

static void AdicionarContato(Agenda agenda)
{
    Console.WriteLine("\nDigite o nome do contato:");
    string nome = Console.ReadLine();

    Console.WriteLine("\nDigite o número de telefone do contato");
    string numeroTelefone = Console.ReadLine();

    Contato novoContato = new Contato { Nome = nome, NumeroTelefone = numeroTelefone };
    agenda.AdicionarContato(novoContato);
}

static void EditarContato(Agenda agenda)
{
    agenda.MostrarContatos();

    Console.WriteLine("\nDigite o número do contato que deseja editar:");

    int indice = int.Parse(Console.ReadLine()) - 1;
    agenda.EditarContato(indice);
}

static void ExcluirContato(Agenda agenda)
{
    agenda.MostrarContatos();

    Console.WriteLine("\nDigite o número do contato que deseja exluir");

    int indice = int.Parse(Console.ReadLine()) - 1;
    agenda.ExcluirContato(indice);
}