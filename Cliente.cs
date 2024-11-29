using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao1 {
    internal class Cliente {
        public int id { get; private set; }
        public String nome { get; set; }
        public int idade { get; set; }
        public String cpf { get;  set; }
        private static int contadorId = 1;

        public Cliente(string nome, int idade, string cpf) {
            this.id = contadorId++;
            this.nome = nome;
            this.idade = idade;
            this.cpf = cpf;
        }



    }
}
