namespace ByteBank1.Entities;

public class User
{
    public string Nome;
    public string Cpf;
    public string Senha;
    public double Saldo;
    

    public void FazerSaque(double valor) {
        Saldo -= valor;
    }
    
    public void FazerDeposito(double valor) {
        Saldo += valor;
    }

    //public double FazerTransferencia(double valorTransferencia) {
        //return a + b;
    //}

    // public bool? EstaAprovado() {
    //     if (Nota == null)
    //         return null;
    //
    //     if (Nota >= 7.0)
    //         return true;
    //
    //     return false;
    // }
}