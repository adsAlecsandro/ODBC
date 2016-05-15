using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace ODBC1
{
	static class ConnectionFactory
	{
		public static OdbcConnection CriaConexao()
		{
			string driver = @"SQL Server";
			string servidor = @".\SQLEXPRESS";
			string baseDeDados = @"Livraria";

			StringBuilder stringDeConexao = new StringBuilder();
			stringDeConexao.Append("driver=");
			stringDeConexao.Append(driver);
			stringDeConexao.Append(";server=");
			stringDeConexao.Append(servidor);
			stringDeConexao.Append(";database=");
			stringDeConexao.Append(baseDeDados);
			stringDeConexao.Append(";Trusted_Connection=Yes");

			return new OdbcConnection(stringDeConexao.ToString());

		}
	}
}
