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
        Console.WriteLine("3 - Tranferência");
        Console.WriteLine("0 - Para sair do programa");
    }
    
    static void CreateUser(List<string> cpfs, List<string> titulares, List<string> senhas , List<double> saldos)
    {
        
        Console.Clear();
        
        Console.Write("Digite o cpf: ");
        cpfs.Add(Console.ReadLine());
        Console.Write("Digite seu nome: ");
        titulares.Add(Console.ReadLine());
        Console.Write("Digite a senha: ");
        senhas.Add(Console.ReadLine());
        saldos.Add(0);
    }

    public static void Main(string[] args)
    {
        int optionInit;
        List<string> cpfs = new List<string>();
        List<string> titulares = new List<string>();
        List<string> senhas = new List<string>();
        List<double> saldos = new List<double>();
        do
        {
           Init(); 
           optionInit = int.Parse(Console.ReadLine());
           switch (optionInit) {
               case 0:
                   Console.WriteLine("Estou encerrando o programa...");
                   break;
               case 1:
                   Login(titulares, senhas);
                   break;
               case 2:
                   CreateUser(cpfs, titulares, senhas, saldos);
                   //Operations();
                   break;
           }
   
        } while (optionInit != 0);
    }
}

