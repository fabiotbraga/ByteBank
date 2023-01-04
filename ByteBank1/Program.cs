using ByteBank1.Entities;

namespace ByteBank1;

public class Program
{
    static void Init()
    {
        Console.WriteLine("Bem vindo ao ByteBank! Por favor, digite a opção desejada:");
        Console.WriteLine("1 - Já sou usuário e desejo entrar em minha conta");
        Console.WriteLine("2 - Sou novo e desejo criar uma conta");
        Console.WriteLine("0 - Para sair do programa");  
    }

    static void Login(List<string> cpfs, List<string> senhas)
    {
        Console.Clear();
        
        Console.WriteLine("Digite o seu cpf:");
        string cpfLogin = Console.ReadLine();
        int cpfFind = cpfs.FindIndex(cpf => cpf == cpfLogin);
        Console.WriteLine("Digite sua senha");
        string senhaLogin = Console.ReadLine();
        int senhaFind = senhas.FindIndex(senhas => senhas == senhaLogin);
        
        if(cpfFind == -1) {
            Console.WriteLine("Não foi possível encontrar esta Conta");
            Console.WriteLine("MOTIVO: Conta não encontrada.");
        }
        if(senhaFind == -1) {
            Console.WriteLine("Não foi possível encontrar esta Conta");
            Console.WriteLine("MOTIVO: Senha não encontrada.");
        }
    }

    static void Operations()
    {
        Console.WriteLine("Por favor, digite a operação que deseja realizar:");
        Console.WriteLine("1 - Saque");
        Console.WriteLine("2 - Depósito");
        Console.WriteLine("3 - Ver conta");
        Console.WriteLine("0 - Para sair do programa");
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
                   //Login(titulares, senhas);
                   break;
               case 2:
                   CreateUser(contas);
                   //Operations();
                   break;
               case 3:
                   ApresentarUsuario(contas);
                   break;
           }
   
        } while (optionInit != 0);
    }
}

