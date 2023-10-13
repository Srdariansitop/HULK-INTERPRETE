using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HULK_Compiler
{
    class Parser
    {
        private Lexer lexer;
        private Token token_actual;
        public Parser(Lexer Lexer , Token token_actual)
        {
            this.lexer = Lexer;
            this.token_actual = token_actual;
        }
        public void avanzar(string tipo, float resultado)
        {
            if (this.token_actual.get_tipo() == tipo)
                this.token_actual = this.lexer.Get_Token();
            else
                Console.WriteLine("error");    
        }
        public float Factor(float resultado)
        {
            if (this.token_actual.get_tipo() == "numero")
            {
                resultado = float.Parse(this.token_actual.get_valor());
                avanzar("numero", resultado);
            }
            else if (this.token_actual.get_tipo() == "Parentesis izquierdo")
            {
                avanzar("Parentesis izquierdo", resultado);
                resultado = expression(resultado);
                avanzar("Parentesis derecho", resultado);
            }
            else
                Console.WriteLine("error");
            return resultado;
        }
        public float termino(float resultado)
        {
            resultado = Factor(resultado);
            while (this.token_actual.get_tipo() == "Multplicacion" | this.token_actual.get_tipo() == "Division")
            {
                if(this.token_actual.get_tipo() == "Multplicacion")
                {
                    avanzar("Multplicacion", resultado);
                    resultado *= Factor(resultado); 
                }
                else if(this.token_actual.get_tipo() == "Division")
                {
                    avanzar("Division" , resultado);
                    resultado /= Factor(resultado);
                }
               
            }
            return resultado;

        }

        public float expression(float resultado)
        {
            resultado = termino(resultado);
            while(this.token_actual.get_tipo() == "Suma" | this.token_actual.get_tipo() == "Resta")
            {
                if(this.token_actual.get_tipo() == "Suma")
                {
                    avanzar("Suma", resultado);
                    resultado += this.termino(resultado);
                }
                else if (this.token_actual.get_tipo() == "Resta")
                {
                    avanzar("Resta", resultado);
                    resultado -= Factor(resultado);
                }
            }
            return resultado;
        }

        public float parsear()
        {
            float resultado = 0;
            return expression(resultado);
        }


    }
}
