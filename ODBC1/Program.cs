using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODBC1
{
	class Program
	{
		static void Main(string[] args)
		{
			string stringDeConexao = @"driver={SQL Server};
				server=.\SQLEXPRESS; Trusted_Connection=Yes";

			using (OdbcConnection conexao = new OdbcConnection(stringDeConexao))
			{
				conexao.Open();
				string sql = @"IF EXISTS
				(SELECT name FROM master.dbo.sysdatabases WHERE name = 'Livraria')
				DROP DATABASE Livraria";
				OdbcCommand command = new OdbcCommand(sql, conexao);
				command.ExecuteNonQuery();

				sql = @"CREATE DATABASE Livraria";
				command = new OdbcCommand(sql, conexao);
				command.ExecuteNonQuery();
			}
		}
	}
}
