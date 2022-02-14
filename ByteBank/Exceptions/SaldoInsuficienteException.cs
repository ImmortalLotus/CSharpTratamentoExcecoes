using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Exceptions
{
    public class SaldoInsuficienteException : Exception
    {
        public double Saldo { get;}
        public double Valor { get;}
        public SaldoInsuficienteException(string message) : base(message){}

        public SaldoInsuficienteException(double saldo, double valor) : this("O valor de "+valor+ " não cabe dentro do saldo atual de : "+saldo)
        {
            Valor = valor;
            Saldo = saldo;
        }
    }
}
