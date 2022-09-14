using static AppBancoFacul.Entity;

namespace AppBancoFacul
{
    public class Logica :ILogica
    {
        private List<Cliente> _dbCliente = new List<Cliente>();
        private List<ContaCorrente> _contaCorrente = new List<ContaCorrente>();
        private List<ContaPoupanca> _contaPoupancas = new List<ContaPoupanca>();
        public void DepositoContaCorrente(double valor, ContaCorrente conta)
        {
            if (conta == null)
            {
                Console.WriteLine("Crie sua conta corrente, porfavor \n");
                string resposta;
                Console.WriteLine("Gostaria De Criar uma conta Corrente? \n");
                Console.WriteLine("escreva S para sim, ou N para Não \n");
                resposta = Console.ReadLine();
                switch (resposta)
                {
                    case "S":
                        CriarCorrente(0001, 0002, 10.000, 10.000);
                        Console.WriteLine("conta criada... \n");
                        break;
                    case "N":
                        Console.WriteLine("Fim do programa... \n");
                        break;
                    default:
                        Console.WriteLine("Fim do programa...\n");
                        break;
                }
            }
            conta.Saldo = valor;
            Console.WriteLine($"Valor de {valor} depositado com sucesso \n");
            Console.WriteLine($"atualmente seu saldo é de {conta.Saldo}\n");
        }
        public void DepositoContaPoupanca(double valor, ContaPoupanca conta)
        {
            if (conta == null)
            {
                Console.WriteLine("Crie sua conta poupanca, porfavor\n");
                string resposta;
                Console.WriteLine("Gostaria De Criar uma conta poupanca?\n");
                Console.WriteLine("escreva S para sim, ou N para Não\n");
                resposta = Console.ReadLine();
                switch (resposta)
                {
                    case "S":
                        CriarPoupanca(001, 0002, 10.000);
                        break;
                    case "N":
                        Console.WriteLine("Fim do programa...\n");
                        break;
                    default:
                        Console.WriteLine("Fim do programa...\n");
                        break;
                }

            }

            conta.Saldo = conta.Saldo + valor;
            Console.WriteLine($"Valor de {valor} depositado com sucesso \n");
            Console.WriteLine($"atualmente seu saldo é de {conta.Saldo}\n");
        }
        public double CalcularJuros(double taxa, double valor)
        {
           var juros = (taxa / 100)* valor;
            return valor - juros;
        }
        public void TrasferirDinheiroCaP(ContaCorrente contaC, ContaPoupanca contaP, double dinheiro)
        {
            contaC.Saldo = contaC.Saldo - dinheiro;
            contaP.Saldo = contaP.Saldo + CalcularJuros(contaP.Taxa, dinheiro);
            Console.WriteLine($"seu saldo na conta corrente é{contaC.Saldo} e sua conta polpança atualmente tem {contaP.Saldo}");

        }
        public void TrasferirDinheiroPaC(ContaCorrente contaC, ContaPoupanca contaP, double dinheiro)
        {
            contaP.Saldo = contaP.Saldo - dinheiro;
            contaC.Saldo = contaC.Saldo + dinheiro;
        Console.WriteLine($"seu saldo na conta corrente é{contaC.Saldo} e sua conta polpança atualmente tem {contaP.Saldo}");
        }
        public Guid CriarCliente(string name, string cpf, string dataNascimento, string endereco, string telefone, string senha)
        {
            var cliente = new Cliente();
            cliente.Id = Guid.NewGuid();
            var id = cliente.Id;
            cliente.Name = name;
            cliente.Cpf = cpf;
            cliente.Senha = senha;
            cliente.DataNascimento = dataNascimento;
            cliente.Endereco = endereco;
            cliente.Telefone = telefone;
              _dbCliente.Add(cliente);
            return id;
            Console.WriteLine("Criado com sucesso\n");
        }
        public void EditarSenha(Guid id,string senha)
        {
            if(senha == null || id == Guid.Empty)
            {
                Console.Write("senha vazia");
            }
            var cliente = _dbCliente.Find(x=>x.Id == id);
            cliente.Senha = senha;
            Console.WriteLine("Editado com sucesso");
        }
        public async Task<ContaCorrente> GetContaCorrente(int agencia)
        {
            if(agencia == null)
            {
                Console.ResetColor();
            }
            var conta = _contaCorrente.Find(x => x.NumeroDeAgencia == agencia);
            return conta;
        }
        public async Task<ContaPoupanca> GetContaPoupanca(int agencia)
        {
            var conta = _contaPoupancas.Find(x=>x.NumeroDeAgencia ==agencia);
            return conta;
        }
        public void CriarPoupanca(int numeroDeAgencia, int numeroConta, double saldo) 
        {
            var poupanca = new ContaPoupanca();
            poupanca.NumeroDeAgencia = numeroDeAgencia;
            poupanca.NumeroConta = numeroConta;
            poupanca.Saldo = saldo;
             _contaPoupancas.Add(poupanca);
        }
        public void CriarCorrente(int agencia, int conta,double saldo,double limite)
        {
            var corrente = new ContaCorrente();
            corrente.NumeroDeAgencia = agencia;
            corrente.NumeroConta = conta;
            corrente.Saldo = saldo;
            corrente.Limite = limite;
            _contaCorrente.Add(corrente);
        }
        public async Task<Cliente> GetCliente(Guid id)
        {
            if(id == Guid.Empty)
            {
                Console.ResetColor();
                return null;
            }
            var cliente = _dbCliente.Find(x=>x.Id == id);
            return cliente;
        }
 
    }
}
