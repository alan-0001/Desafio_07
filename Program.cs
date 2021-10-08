using System;
using MySql.Data.MySqlClient;

namespace desafio7
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno aluno = new Aluno();
            aluno.AddAluno();

            try
            {
                Console.Write("Id do aluno: ");
                aluno.aluno_id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Nome: ");
                aluno.Nome = Console.ReadLine();

                Console.Write("Nota: ");
                aluno.Nota = Console.ReadLine();

                string query = "insert into tb_aluno values(" +
                      aluno.aluno_id + ", '" + aluno.Nome + "', " + aluno.Nota + ") ";
                Console.WriteLine(query);

                MySqlConnection bdConn = new MySqlConnection("server=127.0.0.1;port=3306;database=desafio7;Uid=root;pwd=alan");
                bdConn.Open();
                Console.WriteLine("Conectado!");

                MySqlCommand cmd = new MySqlCommand(query, bdConn);
                int result = cmd.ExecuteNonQuery();
                Console.WriteLine(result + " Dados inseridos na tabela.");

                Console.WriteLine("\nDados dos alunos");
                query = "select * from tb_aluno";
                MySqlCommand cmd2 = new MySqlCommand(query, bdConn);
                MySqlDataReader r = cmd2.ExecuteReader();


                while (r.Read() == true)
                {
                    int aid = r.GetInt32(0);
                    string nm = r.GetString(1);
                    string nt = r.GetString(2);

                    Console.WriteLine("{0}\t {1} \t {2}", aid, nm, nt);
                }
                bdConn.Close();
                //aluno.Salvar();
                //Console.WriteLine("Cadastro com sucesso!");
            }

            catch (MySqlException e) 
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

