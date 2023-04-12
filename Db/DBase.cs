using Dapper;
using Microsoft.Extensions.Configuration;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salve_Vidas.Db
{
    public static class DBase
    {
        public static IConfiguration Configuration { get; set; }

        public static string Connection()
        {
            string novaConectionString = null;

            novaConectionString = @"Data Source = ; Initial Catalog = ; User id = ; Pwd = ";
            //DESKTOP-GUILHER ou 7.94.104.163

            return novaConectionString;

        }

        static SqlConnection sqlConnection = new SqlConnection(Connection());
        public static SqlConnection Conectar()
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return sqlConnection;
        }
        public static void Desconectar()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        /// <summary>
        /// Insert Record
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="obj"></param>
        /// <param name="query"></param>
        public static void Insert<TEntity>(this TEntity obj, string query)
        {
            using (IDbConnection con = new SqlConnection(Connection()))
            {
                con.Open();
                var transation = con.BeginTransaction();
                try
                {
                    con.Execute(query, obj, transation, 800);
                    transation.Commit();
                }
                catch (System.Exception)
                {
                    transation.Rollback();
                }
            }
        }

        public static int ExecuteWithReturnAffected(string query)
        {
            using (IDbConnection con = new SqlConnection(Connection()))
            {
                con.Open();
                var transation = con.BeginTransaction();
                try
                {
                    var rowsAffected = con.Execute(query, null, transation, 800);
                    transation.Commit();
                    return Convert.ToInt32(rowsAffected);
                }
                catch (System.Exception)
                {
                    transation.Rollback();
                    return 0;
                }
            }
        }

        /// <summary>
        /// Execute query
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="obj"></param>
        /// <param name="query"></param>
        public static void Execute<TEntity>(this TEntity obj, string query)
        {
            using (IDbConnection con = new SqlConnection(Connection()))
            {
                con.Open();
                var transation = con.BeginTransaction();
                try
                {
                    con.Execute(query, obj, transation, 800);
                    transation.Commit();
                }
                catch (System.Exception)
                {
                    transation.Rollback();
                }
            }
        }

        /// <summary>
        /// Execute Query Async
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="obj"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public static async Task ExecuteAsync<TEntity>(this TEntity obj, string query)
        {
            using (IDbConnection con = new SqlConnection(Connection()))
            {
                con.Open();
                var transation = con.BeginTransaction();
                try
                {
                    await con.ExecuteAsync(query, obj, transation, 800);
                    transation.Commit();
                }
                catch (System.Exception)
                {
                    transation.Rollback();
                }
            }
        }

        /// <summary>
        /// Fetch records
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static IEnumerable<TEntity> LoadData<TEntity>(string query)
        {
            using (IDbConnection con = new SqlConnection(Connection()))
            {
                try
                {
                    return con.Query<TEntity>(query, commandTimeout: 30);
                }
                catch
                {
                    return null;
                }
            }
        }

        public static string TestaConexao()
        {
            try
            {
                string query = $@"select 1 as Nome";

                var retorno = DBase.LoadData<T>(query).ToString();

                return "Ok";
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Erro";
            }
        }

        /// <summary>
        /// Fetch records async
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<TEntity>> LoadDataAsync<TEntity>(string query)
        {
            using (IDbConnection con = new SqlConnection(Connection()))
            {
                return await con.QueryAsync<TEntity>(query, commandTimeout: 600);
            }
        }

        /// <summary>
        /// Get record by id
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static async Task<TEntity> GetById<TEntity>(string query, object param)
        {
            using (IDbConnection con = new SqlConnection(Connection()))
            {
                return await con.QueryFirstOrDefaultAsync<TEntity>(query, param);
            }
        }

        public static DbCommand CreateCommand(DbConnection con, string proc, object Parametros)
        {
            try
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = proc;
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (var parametro in Parametros.GetType().GetProperties())
                {
                    var commandparameter = cmd.CreateParameter();
                    commandparameter.ParameterName = parametro.Name;
                    commandparameter.Value = parametro.GetValue(Parametros);
                    cmd.Parameters.Add(commandparameter);
                }
                return cmd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int RunProcedure(string procedure, object parameters)
        {
            //bool connectionCreated = false;
            SqlConnection connection = new SqlConnection();

            connection = new SqlConnection(Connection());
            connection.Open();
            //connectionCreated = true;
            try
            {
                using (var command = CreateCommand(connection, procedure, parameters))
                {
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
