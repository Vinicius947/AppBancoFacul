using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AppBancoFacul.Entity;

namespace AppBancoFacul
{
    public interface ILogica
    {
        void DepositoContaCorrente(double valor, ContaCorrente conta);
        void DepositoContaPoupanca(double valor, ContaPoupanca conta);
        void TrasferirDinheiroPaC(ContaCorrente contaC, ContaPoupanca contaP, double dinheiro);
        void TrasferirDinheiroCaP(ContaCorrente contaC, ContaPoupanca contaP, double dinheiro);
        double CalcularJuros(double taxa, double valor);
        Guid CriarCliente(string name, string cpf, string dataNascimento, string endereco, string telefone, string senha);
        void CriarPoupanca(int numeroDeAgencia, int numeroConta, double saldo);
        void EditarSenha(Guid id, string senha);
        Task<Cliente> GetCliente(Guid id);
    }
}
