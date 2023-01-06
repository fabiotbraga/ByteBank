using ByteBank1.Entities;

namespace ByteBank1;

public class Program
{
    static void Init()
    {
        Console.WriteLine();
        Console.WriteLine("--------------- BYTEBANK ---------------");
        Console.WriteLine("Bem vindo ao ByteBank! Por favor, digite a opção desejada:");
        Console.WriteLine("1 - Já sou usuário e desejo entrar em minha conta");
        Console.WriteLine("2 - Sou novo e desejo criar uma conta");
        Console.WriteLine("0 - Para sair");
        Console.Write("-> ");
    }
    
    static void CreateUser(List<User> contas)
    {
        Console.WriteLine("--------------- Seja bem-vindo ao ByteBank! ---------------");
        Console.WriteLine($"Para começar, digite os dados da nova conta:");
        Console.Write("Digite seu nome: ");
        string nome = Console.ReadLine();
        Console.Write("Digite o CPF: ");
        string cpf = Console.ReadLine();
        Console.Write("Crie uma senha: ");
        string senha = Console.ReadLine();
        Console.Write("Digite o depósito inicial: R$");
        double saldo = double.Parse(Console.ReadLine());
        Random numAleatorioParaConta = new Random();
        int numConta = numAleatorioParaConta.Next(1000, 9000);
        contas.Add(new User(nome, cpf, senha, saldo, numConta));
        Console.WriteLine();
        Console.WriteLine($"Olá {nome}!! Bem-vindo ao ByteBank!");
        Console.WriteLine($"Seu número de conta será: {numConta}");
    }

    static User Login(List<User> contas)
    {
        Console.Clear();
        Console.WriteLine("--------------- LISTA DE CLIENTES ---------------");
        foreach (User obj in contas)
        {
            Console.WriteLine($"Número da conta: {obj.NumConta}");
            Console.WriteLine($"Nome: {obj.Nome}");
            Console.WriteLine();
        }
        User cc;
        Console.WriteLine("--------------- LOGIN ---------------");
        Console.WriteLine();
        do
        {
            Console.Write("Digite o número da sua conta: ");
            int numContaLogin = int.Parse(Console.ReadLine());
            Console.Write("Digite a sua senha: ");
            string senhaLogin = Console.ReadLine();
            Console.WriteLine();
            cc = contas.Find(x => x.NumConta == numContaLogin && x.Senha == senhaLogin);
            if (cc == null)
            {
                Console.WriteLine("Número da conta ou senha inválidos. Tente novamente.");
                Console.WriteLine();
            }
        } while (cc == null);
        return cc; 
    }

    static void Operacoes(User contaLogada, List<User> contas)
    {
        int option;
        do
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"Bem vindo {contaLogada.Nome}!");
            Console.WriteLine();
            Console.WriteLine("Por favor, digite a operação que deseja realizar:");
            Console.WriteLine("1 - Depósito");
            Console.WriteLine("2 - Saque");
            Console.WriteLine("3 - Transferência");
            Console.WriteLine("4 - Visualizar dados da conta");
            Console.WriteLine("0 - Para sair da conta");
            Console.Write("-> ");
            option = int.Parse(Console.ReadLine());
            while (option > 4 || option < 0)
            {
                Console.Write("Opção inválida, digite novamente: ");
                option = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            switch (option)
            {
                case 1:
                    Deposito(contaLogada);
                    TelaIntermediaria();
                    break;
                case 2:
                    Saque(contaLogada);
                    TelaIntermediaria();
                    break;
                case 3:
                    Transferencia(contas, contaLogada);
                    TelaIntermediaria();
                    break;
                case 4:
                    DadosdaConta(contaLogada);
                    TelaIntermediaria();
                    break;
            }

        } while (option != 0);
    }
    static void DadosdaConta(User contaLogada) {
        
        Console.Clear();
        Console.WriteLine($"CPF = {contaLogada.Cpf} | Titular = {contaLogada.Nome} | Saldo = R${contaLogada.Saldo:F2}");
    }

    static void Deposito(User contaLogada)
    {
        Console.Clear();
        Console.WriteLine("---------- DEPÓSITO ----------");
        Console.WriteLine();
        Console.WriteLine("Qual o valor que deseja depositar?");
        Console.Write($"-> R$ ");
        double valor = double.Parse(Console.ReadLine());
        contaLogada.FazerDeposito(valor);
        Console.WriteLine($"Depósito de R${valor:F2} efetuado com sucesso! ");
        Console.WriteLine();
        Console.WriteLine($"Você agora possui um saldo de R${contaLogada.Saldo:F2} ");
    }

    static void Saque(User contaLogada)
    {
        Console.Clear();
        Console.WriteLine("---------- SAQUE ----------");
        Console.WriteLine();
        Console.WriteLine("Qual o valor que deseja sacar?");
        Console.Write($"-> R$ ");
        double valor = double.Parse(Console.ReadLine());
        contaLogada.FazerSaque(valor);
        Console.WriteLine($"Saque de R${valor:F2} efetuado com sucesso!");
        Console.WriteLine($"Você agora possui um saldo de R${contaLogada.Saldo:F2} ");
        Console.WriteLine();
    }

    static void Transferencia(List<User> contas, User contaLogada)
    {
        Console.Clear();
        Console.WriteLine("--------------- TRANSFERÊNCIA ---------------");
        Console.WriteLine();
        User pagador = contaLogada;
        Console.WriteLine("--------------- LISTA DE CLIENTES ---------------");
        Console.WriteLine();
        foreach (User obj in contas)
        {
            Console.WriteLine($"Número da conta: {obj.NumConta}");
            Console.WriteLine($"Nome: {obj.Nome}");
            Console.WriteLine();
        }
        Console.Write("Informe o número da conta para quem deseja tranferir: ");
        int findConta = int.Parse(Console.ReadLine());
        User recebedor = contas.Find(x => x.NumConta == findConta);
        Console.WriteLine();
        while (recebedor == null)
        {
            Console.Write("Conta inválida, digite novamente o número da conta: ");
            findConta = int.Parse(Console.ReadLine());
            recebedor = contas.Find(x => x.NumConta == findConta);
            Console.WriteLine();
        }
        while (recebedor == pagador)
        {
            Console.WriteLine("A Conta de destino não pode ser a mesma da origem.");
            Console.Write($"Digite novamente o número número da conta para quem deseja tranferir: ");
            findConta = int.Parse(Console.ReadLine());
            recebedor = contas.Find(x => x.NumConta == findConta);
            Console.WriteLine();
            if (recebedor == null)
            {
                Console.Write("Conta inválida, dda conta para quem deseja tranferir: ");
                findConta = int.Parse(Console.ReadLine());
                recebedor = contas.Find(x => x.NumConta == findConta);
                Console.WriteLine();
            }
        }
        Console.Write("Digite o valor: R$ ");
        double valorTransferencia = double.Parse(Console.ReadLine());
        recebedor.Transferencia(pagador, recebedor, valorTransferencia);
        Console.WriteLine();
        Console.WriteLine("----- COMPROVANTE DE TRANSFERÊNCIA -----");
        Console.WriteLine();
        Console.WriteLine($"VALOR ->R${valorTransferencia:F2}");
        Console.WriteLine();
        Console.WriteLine("----- DADOS DO PAGADOR -----");
        Console.WriteLine();
        Console.WriteLine($"Número da conta: {pagador.NumConta}");
        Console.WriteLine($"Nome: {pagador.Nome}");
        Console.WriteLine();
        Console.WriteLine("----- DADOS DO RECEBEDOR -----");
        Console.WriteLine();
        Console.WriteLine($"Número da conta: {recebedor.NumConta}");
        Console.WriteLine($"Nome: {recebedor.Nome}");
        Console.WriteLine();
    }

    static void TelaIntermediaria()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Digite qualquer tecla para voltar ao menu anterior... ");
        Console.ReadKey(); 
    }

    public static void Main(string[] args)
    {
        int optionInit;
        List<User> contas = new List<User>(); 
        
        do
        {
            Console.Clear();
            Init(); 
            optionInit = int.Parse(Console.ReadLine());
           
            switch (optionInit) {
                case 0:
                    Console.Clear();
                    Console.WriteLine("Encerrando... Muito Obrigado, Volte Sempre!");
                    break;
                case 1:
                    User contaLogada = Login(contas);
                    Operacoes(contaLogada, contas);
                    break;
                case 2:
                    Console.Clear();
                    CreateUser(contas);
                    TelaIntermediaria();
                    break;
            }
   
        } while (optionInit != 0);
    }
}