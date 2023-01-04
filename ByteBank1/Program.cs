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

    static void CreateUser(List<string> titular, List<string> cpf, List<decimal> saldo)
    {
        throw new NotImplementedException();
    }
    
    public static void Main(string[] args)
    {
        int optionInit;
        do
        {
           Init(); 
           optionInit = int.Parse(Console.ReadLine());
           switch (optionInit) {
               case 0:
                   Console.WriteLine("Estou encerrando o programa...");
                   break;
               case 1:
                   Console.WriteLine("Entrar na conta");
                   break;
               case 2:
                   Console.WriteLine("Criar nova conta");
           }
   
        } while (optionInit != 0);
    }
}

