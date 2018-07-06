using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using jcconsultingti.utils;
using MySql.Data.MySqlClient;

namespace jcconsultingti.winerie.data
{
	public class _Contexto : IDisposable
	{
		private MySqlConnection conexao;

		public _Contexto()
		{
			var conexaoString = ConfigurationManager.ConnectionStrings[model.Enum.ConectorDataBaseEnum.Producao.ToDescriptionString()].ConnectionString;
			conexao = new MySqlConnection(conexaoString);
		}

		public long ExecutaComando(string comandoSQL, Dictionary<string, object> parametros)
		{
			var resultado = 0;
			if (string.IsNullOrEmpty(comandoSQL))
			{
				throw new ArgumentException("O comandoSQL não pode ser nulo ou vazio");
			}
			try
			{
				AbrirConexao();
				var cmdComando = CriarComando(comandoSQL, parametros);
				resultado = cmdComando.ExecuteNonQuery();

                if (comandoSQL.ToUpper().StartsWith("INSERT"))
                    return cmdComando.LastInsertedId;
			}
			finally
			{
				FecharConexao();
			}

			return resultado;
		}

		public List<Dictionary<string, string>> ExecutaComandoComRetorno(string comandoSQL, Dictionary<string, object> parametros = null)
		{
			List<Dictionary<string, string>> linhas = null;

			if (string.IsNullOrEmpty(comandoSQL))
			{
				throw new ArgumentException("O comandoSQL não pode ser nulo ou vazio");
			}
			try
			{
				AbrirConexao();
				var cmdComando = CriarComando(comandoSQL, parametros);

				using (var reader = cmdComando.ExecuteReader())
				{
					linhas = new List<Dictionary<string, string>>();
					while (reader.Read())
					{
						var linha = new Dictionary<string, string>();

						for (var i = 0; i < reader.FieldCount; i++)
						{
							var nomeDaColuna = reader.GetName(i);
							var valorDaColuna = reader.IsDBNull(i) ? null : reader.GetString(i);
							linha.Add(nomeDaColuna, valorDaColuna);
						}
						linhas.Add(linha);
					}
				}
			}
			finally
			{
				FecharConexao();
			}

			return linhas;
		}

        public long ExecutaComandoProcedure(string nomeProcedure, Dictionary<string, object> parametros)
        {
            var resultado = 0;
            if (string.IsNullOrEmpty(nomeProcedure))
            {
                throw new ArgumentException("Nome da procedure não pode ser nulo ou vazio");
            }
            try
            {
                AbrirConexao();
                var cmdComando = CriarComandoProcedure(nomeProcedure, parametros);
                resultado = cmdComando.ExecuteNonQuery();
            }
            finally
            {
                FecharConexao();
            }

            return resultado;
        }

        private MySqlCommand CriarComando(string comandoSQL, Dictionary<string, object> parametros)
		{
			var cmdComando = conexao.CreateCommand();
			cmdComando.CommandText = comandoSQL;
			AdicionarParamatros(cmdComando, parametros);

			return cmdComando;
		}

        private MySqlCommand CriarComandoProcedure(string nomeProcedure, Dictionary<string, object> parametros)
        {
            var cmdComando = conexao.CreateCommand();
            cmdComando.CommandType = CommandType.StoredProcedure;
            cmdComando.CommandText = nomeProcedure;

            AdicionarParamatros(cmdComando, parametros);

            return cmdComando;
        }

        private static void AdicionarParamatros(MySqlCommand cmdComando, Dictionary<string, object> parametros)
		{
			if (parametros == null)
				return;

			foreach (var item in parametros)
			{
				var parametro = cmdComando.CreateParameter();
				parametro.ParameterName = item.Key;
				parametro.Value = item.Value ?? DBNull.Value;
				cmdComando.Parameters.Add(parametro);
			}
		}

		private void AbrirConexao()
		{
			if (conexao.State == ConnectionState.Open)
                return;

			conexao.Open();
		}

		private void FecharConexao()
		{
			if (conexao.State == ConnectionState.Open)
				conexao.Close();
		}

		public void Dispose()
		{
			if (conexao == null)
                return;

			conexao.Dispose();
			conexao = null;
		}
	}
}
