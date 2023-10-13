using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HULK_Compiler
{
       class Token
    {
        private string valor;
        private string tipo;

        public Token(string tipo , string valor)
        {
            this.tipo = tipo;
            this.valor = valor;
        }
        public string get_tipo() { return tipo; }
        public string get_valor() { return valor; }

        public void Set_tipo(string tipo) { this.tipo = tipo; }
        public void Set_Valor(string valor) { this.valor = valor; }
    }
}
