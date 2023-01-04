using ByteBank1.Entities;

namespace ByteBank1;

public class Program
{
    static void Init()
    {
        //Console.Clear();
        Console.WriteLine("Bem vindo ao ByteBank! Por favor, digite a opção desejada:");
        Console.WriteLine("1 - Já sou usuário e desejo entrar em minha conta");
        Console.WriteLine("2 - Sou novo e desejo criar uma conta");
        Console.WriteLine("3 - Ver conta");
        Console.WriteLine("0 - Para sair do programa");  
    }

    static void Login(List<User> contas)
    {
        Console.Clear();
        
        Console.WriteLine("Digite o seu cpf:");
        string cpfLogin = Console.ReadLine();
        int cpfFind = contas.FindIndex(cpf => cpf == contas.Find( a => a.Cpf == cpfLogin ));
        
        Console.WriteLine("Digite sua senha");
        string senhaLogin = Console.ReadLine();
        int senhaFind = contas.FindIndex(senhas => senhas == contas.Find(a => a.Senha == senhaLogin));
        
        if(cpfFind == -1) {
            Console.WriteLine("Não foi possível encontrar esta Conta");
            Console.WriteLine("MOTIVO: Conta não encontrada.");
        }
        if(senhaFind == -1) {
            Console.WriteLine("Não foi possível encontrar esta Conta");
            Console.WriteLine("MOTIVO: Senha não encontrada.");
        }
        
        Console.Clear();
        Operations();
    }

    static void Operations()
    {
        int option;
        Console.WriteLine("Por favor, digite a operação que deseja realizar:");
        Console.WriteLine("1 - Saque");
        Console.WriteLine("2 - Depósito");
        Console.WriteLine("0 - Para sair do programa");

        option = int.Parse(Console.ReadLine());
        switch (option) {
            case 0:
                Console.WriteLine("Estou encerrando o programa...");
                break;
            case 1:
                Saque();
                break;
            case 2:
                Deposito();
                break;
            case 3:
                Transferencia();
                break;
        }
    }
    
    static void CreateUser(List<User> contas)
    {
        
        Console.Clear();
        
        Console.Write("Digite seu nome: ");
        User user = new User();
        user.Nome = Console.ReadLine();
        Console.Write("Digite o cpf: ");
        user.Cpf = Console.ReadLine();
        Console.Write("Digite a senha: ");
        user.Senha = Console.ReadLine();
        
        contas.Add(user);
    }
    
    static void ApresentaConta( int index, List<User> contas) {
        Console.WriteLine($"CPF = {contas[index].Cpf} | Titular = {contas[index].Nome} | Saldo = R${contas[index].Saldo:F2}");
        Console.Clear();
    }
    static void ApresentarUsuario(List<User> contas) {
        
        Console.Clear();
        
        Console.Write("Digite o cpf: ");
        string cpfParaApresentar = Console.ReadLine();
        int indexParaApresentar = contas.FindIndex(cpf => cpf == contas.Find( a => a.Cpf == cpfParaApresentar ));

        if (indexParaApresentar == -1) {
            Console.WriteLine("Não foi possível apresentar esta Conta");
            Console.WriteLine("MOTIVO: Conta não encontrada.");
        }

        ApresentaConta(indexParaApresentar, contas);
    }

    static void Saque()
    {
        Console.Clear();
        
        Console.WriteLine("Saque");
    }
    
    static void Deposito()
    {
        Console.Clear();
        
        Console.WriteLine("Deposito");
    }
    
    static void Transferencia()
    {
        Console.Clear();
        Console.WriteLine("Transferencia");
    }

    public static void Main(string[] args)
    {
        int optionInit;
        List<User> contas = new List<User>(); 
        do
        {
           Init(); 
           optionInit = int.Parse(Console.ReadLine());
           switch (optionInit) {
               case 0:
                   Console.WriteLine("Estou encerrando o programa...");
                   break;
               case 1:
                   Login(contas);
                   break;
               case 2:
                   CreateUser(contas);
                   break;
               case 3:
                   ApresentarUsuario(contas);
                   break;
           }
   
        } while (optionInit != 0);
    }
}

