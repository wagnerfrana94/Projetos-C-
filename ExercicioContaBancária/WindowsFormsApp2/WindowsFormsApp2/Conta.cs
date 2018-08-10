using System;

namespace WindowsFormsApp2
{
    public class Conta
    {
        public Conta()
        {

        }

        public int numero { get; internal set; }
        public double saldo { get; private set; }
        public Cliente titular { get; set; }

        public void Deposita(double v)
        {
            this.saldo += v; 
        }

        
    }
}