using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio7
{
    class Aluno : ID_Aluno
    {
        public void AddAluno() { }
        public int aluno_id { get; set; }
        public string Nome { get; set; }
        public string Nota { get; set; }

        //internal void Salvar()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
