using AppBancoFacul;
using System;

//herança
public class Program :Logica
{
    public static void Main()
    {
            var mc = new Program();
            int numero = 0001;
            int agencia = 0002;
            double saldo = 00.00;
            mc.CriarPoupanca(agencia,numero, saldo);
            mc.CriarCorrente(agencia, numero, saldo, 10.000);
            Console.WriteLine("Bem vindo ao Vinão seu banco de confiança\n");
            Console.WriteLine("por favor digite suas informações");
            Console.WriteLine("Qual seu nome:\n");
            var nome = Console.ReadLine();
            Console.WriteLine("qual seu Cpf \n");
            var cpf = Console.ReadLine();
            Console.WriteLine("qual seu telefone");
            var telefone = Console.ReadLine();
            Console.WriteLine("qual seu endereço \n");
            var endereco = Console.ReadLine();
            Console.WriteLine("qual sua data de nascimento \n");
            var dataDe = Console.ReadLine();
            Console.WriteLine("qual sua Senha");
            var senha = Console.ReadLine();
            //chamando a função apra criar o cliente
            var guid = mc.CriarCliente(nome, cpf, dataDe, endereco, telefone, senha);
            Console.WriteLine("Você pode trocar a senha, gostaria de trocar?\n");
            Console.WriteLine("S para sim, N para não");
            string sim = Console.ReadLine();
            if(sim == "s"||sim == "S")
            { 
                Console.WriteLine("qual a senha\n");
                var senha1 = Console.ReadLine();
                mc.EditarSenha(guid,senha1);
            }
        for (int i = 0; i < 10;)
        {
            var cliente = mc.GetCliente(guid);
            Console.WriteLine("gostaria de fazer um deposito se Sim qual o valor e para que conta?\n");
            Console.WriteLine("digite qual conta vc gostaria de depositar, poupança ou corrente");
            var a = Console.ReadLine();
            if(a =="corrente")
            {
                Console.WriteLine("qual o valor que vc gostaria de depositar");
                double deposito = Convert.ToDouble(Console.ReadLine());
                mc.DepositoContaCorrente(deposito, mc.GetContaCorrente(agencia).Result);
                Console.WriteLine("depoitado com sucesso");
            }
            if(a == "poupança")

            {
                Console.WriteLine("qual o valor que vc gostaria de depositar");
                double deposito = Convert.ToDouble(Console.ReadLine());
                mc.DepositoContaPoupanca(mc.CalcularJuros(mc.GetContaPoupanca(agencia).Result.Taxa, deposito), mc.GetContaPoupanca(agencia).Result);
                Console.WriteLine("depoitado com sucesso");
            }
            Console.WriteLine("gostaria de trasferir seu dinheiro para uma conta?  S/N");
            string s = Console.ReadLine();
            if (s == "s" || s == "S")
            {
                Console.WriteLine("qual conta vc gostaria de transferir seu dinheiro");
                Console.WriteLine("poupança para corrente| 1");
                Console.WriteLine("corrente para poupança| 2");
                string b = Console.ReadLine();
               if(b == "1")
                {
                    mc.TrasferirDinheiroCaP(mc.GetContaCorrente(agencia).Result, mc.GetContaPoupanca(agencia).Result,20.00);

                }
               if(b == "2")
                {
                    mc.TrasferirDinheiroPaC(mc.GetContaCorrente(agencia).Result, mc.GetContaPoupanca(agencia).Result, 20.00);
                }
            }


        }
    }

}

