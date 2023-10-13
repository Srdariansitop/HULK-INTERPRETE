using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HULK_Compiler
{
    class Lexer
    {
        private string codigo;
        private int pos;
        private char ch_actual;

        public Lexer(string codigo)
        {
            this.codigo = codigo;
            this.pos = 0;
            this.ch_actual = codigo[pos];
        }
        public Token Get_Token()
        {
            
            Token token = new Token("vacio ", "-");
            if (this.pos < this.codigo.Length)
                {
                if (this.ch_actual == ' ')
                {
                    Avanzar();
                }
                if (char.IsDigit(this.ch_actual))
                {
                    token.Set_tipo("numero");
                    token.Set_Valor(valor_numerico());
                }
                if (this.ch_actual == '+')
                {
                    token.Set_tipo("Suma");
                    token.Set_Valor("+");
                }
                if(this.ch_actual == '-')
                {
                    token.Set_tipo("Resta");
                    token.Set_tipo("-");
                }
                if(this.ch_actual == '*')
                {
                    token.Set_tipo("Multplicacion");
                    token.Set_tipo("*");
                }
                if(this.ch_actual == '/')
                {
                    token.Set_tipo("Division");
                    token.Set_tipo("/");
                }
                if (this.ch_actual == '(')
                {
                    token.Set_tipo("Parentesis izquierdo");
                    token.Set_Valor("(");
                }
                if (this.ch_actual == ')')
                {
                    token.Set_tipo("Parentesis derecho");
                    token.Set_Valor(")");
                }

            }
            Avanzar();
            Get_Token();
            return token;
        }
       public  void Avanzar ()
      {
            this.pos++;
            if (this.pos < this.codigo.Length)
            {
                this.ch_actual = this.codigo[this.pos];
                if (this.codigo[this.pos] == ' ')
                {
                    Avanzar();
                }
                else if (char.IsDigit(this.ch_actual))
                {
                    valor_numerico();
                }
                else
                    this.ch_actual = this.codigo[this.pos];
            }
            else
            {
              ch_actual = ' ';
            }
           
      }
        public string valor_numerico()
        {
            string valor = " ";

            while (char.IsDigit(this.ch_actual))
            {
                valor += this.ch_actual;
                Avanzar();
            }
            return valor;

        }

    }
}
