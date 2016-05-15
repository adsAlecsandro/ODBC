using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace ODBC1
{
	class ListaEditoras
	{
		static void Main(string[] args)
		{
			string stringDeConexao = @"driver={SQL Server};
				server=.\SQLEXPRESS;database=Livraria;Trusted_Connection=Yes";
			using (OdbcConnection conexao = new OdbcConnection(stringDeConexao))
			{
				string sql = "SELECT * FROM Editoras";
				OdbcCommand command = new OdbcCommand(sql, conexao);
				conexao.Open();
				OdbcDataReader resultado = command.ExecuteReader();

				List<Editora> lista = new List<Editora>();

				while (resultado.Read())
				{
					Editora e = new Editora();

					e.ID = resultado["ID"] as long?;
					e.Nome = resultado["Nome"] as string;
					e.Email = resultado["Email"] as string;

					lista.Add(e);
				}

				foreach(Editora e in lista)
				{
					System.Console.WriteLine("{0} - {1} - {2}\n", e.ID, e.Nome, e.Email);
				}
			}
		}
	}
}
