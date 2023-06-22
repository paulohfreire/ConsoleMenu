using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Model.Domain
{
    public class Cliente : Pessoa
    {
        public int Conta { get; set; }
        public float Saldo { get; set; }
    }
}
