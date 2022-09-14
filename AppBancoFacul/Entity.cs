using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoFacul
{
    public class Entity : DbContext
    {
        public class ContaPoupanca
        {
            public ContaPoupanca()
            {
            }

            public ContaPoupanca(int numeroDeAgencia, int numeroConta, double saldo)
            {
                NumeroDeAgencia = numeroDeAgencia;
                NumeroConta = numeroConta;
                Saldo = saldo;
            }

            public int NumeroDeAgencia { get; set; }
            public int NumeroConta { get; set; }
            public double Saldo { get; set; }
            public double Taxa { get; set; } = 3.14;
            public  List<Cliente> Conta { get; set; }
        }
        public class Cliente
        {
            public Cliente()
            {
            }

            public Cliente(Guid id, string name, string cpf, string dataNascimento, string endereco, string telefone, string senha)
            {
                Id = id;
                Name = name;
                Cpf = cpf;
                DataNascimento = dataNascimento;
                Endereco = endereco;
                Telefone = telefone;
                Senha = senha;
            }

            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Cpf { get; set; }
            public string DataNascimento { get; set; }
            public string Endereco { get; set; }
            public string Telefone { get; set; }
            public string Senha { get; set; }
        }
        public class ContaCorrente
        {

            public int NumeroDeAgencia { get; set; }
            public int NumeroConta { get; set; }
            public double Saldo { get; set; }
            public double Limite { get; set;} = 10.000;
            public List<Cliente> Conta { get; set; }
        }

     
    }
}
