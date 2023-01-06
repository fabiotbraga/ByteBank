namespace ByteBank1.Entities;

public class User
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Senha { get; set; }
    public double Saldo { get; set; }
    public int NumConta { get; set; }
    
    public User(string nome, string cpf, string senha, double saldo, int numConta)
    {
        Nome = nome;
        Cpf = cpf;
        Senha = senha;
        Saldo = saldo;
        NumConta = numConta;
    }
    

    public void FazerSaque(double valor) {
        Saldo -= valor;
    }
    
    public void FazerDeposito(double valor) {
        Saldo += valor;
    }

    public void Transferencia(User contaOrigem, User contaDestino, double valor)
    {
        contaOrigem.Saldo -= valor;
        contaDestino.Saldo += valor; 
    }
}