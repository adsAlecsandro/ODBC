using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace ODBC1
{
	class InsereEditora
	{
		static void Main(string [] args)
		{
			string stringDeConexao = @"driver={SQL Server};
				server=.\SQLEXPRESS;database=Livraria;Trusted_Connection=Yes";

			Editora e = new Editora();

			System.Console.Write("Digite o nome da Editora:");
			e.Nome = System.Console.ReadLine();

			System.Console.Write("Digite o email da Editora:");
			e.Email = System.Console.ReadLine();

			string sql =
				@"INSERT INTO Editoras (Nome, Email)
				OUTPUT INSERTED.id
				VALUES(?, ?)";

			using (OdbcConnection conexao = new OdbcConnection(stringDeConexao))
			{
				OdbcCommand command = new OdbcCommand(sql, conexao);

				command.Parameters.AddWithValue("@Nome", e.Nome);
				command.Parameters.AddWithValue("@Email", e.Email); 	

				conexao.Open();
				e.ID = command.ExecuteScalar() as long?;

				System.Console.WriteLine("Editora Cadastrada com ID: " + e.ID);
			}			
		}
	}
}
