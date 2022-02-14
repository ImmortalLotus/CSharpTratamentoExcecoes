// using _05_ByteBank;

using ByteBank.Exceptions;
using System;

namespace ByteBank
{
    public class ContaCorrente
    {
        public Cliente Titular { get; set; }

        public static int TotalDeContasCriadas { get; private set; }

        public static double TaxaOperacao { get; private set; }

        public int Agencia{ get; }

        public int Numero { get; }

        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }


        public ContaCorrente(int agencia, int numero)
        {
            if (agencia<=0 || numero <=0)
            {
                throw new ArgumentException("Nem agência nem número podem ser nulos, nerd.");
            }
            Agencia = agencia;
            Numero = numero;
            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;

        }


        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException(" O valor não pode ser menor que 0 ");
            }
            if (_saldo < valor)
            {
                throw new SaldoInsuficienteException("burro não pode ter menos dinheiro do que você quer sacar");
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException(" O valor não pode ser menor que 0 ");
            }
            try {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                throw new Exception("O valor de saque excede o valor de dinheiro da conta",ex);
            }
            finally
            {
                Console.WriteLine("independentemente, eu apareço");
            }
           
            _saldo -= valor;
            contaDestino.Depositar(valor);
        }
    }
}
