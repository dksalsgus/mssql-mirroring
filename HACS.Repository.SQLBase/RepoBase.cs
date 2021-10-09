using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace HACS.Repository.SQLBase
{
    public class RepoBase
    {
        private static readonly string _ConnectionString;

        static RepoBase()
        {
            try
            {
                //_ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
                _ConnectionString = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).ConnectionStrings.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
            catch
            {
                //Design Time에 이러나는 것 같다.
            }
        }

        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(_ConnectionString);
        }

        protected SqlConnection CreateConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

        protected SqlConnection CreateOpenConnection()
        {
            var connection = CreateConnection();
            connection.Open();
            return connection;
        }

        protected Task<SqlDataReader> ExecuteReaderAsync(SqlCommand cmd)
        {
            var connection = CreateOpenConnection();
            cmd.Connection = connection;
            return cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
        }

        protected DbDataReader ExecuteReader(SqlCommand cmd)
        {
            var connection = CreateOpenConnection();
            cmd.Connection = connection;
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        protected async Task<List<T>> QueryAsync<T>(SqlCommand cmd, Func<DbDataReader, T> resolver) where T : class
        {
            var list = new List<T>();
            using (var connection = CreateConnection())
            {
                cmd.Connection = connection;
                await connection.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                    while (await reader.ReadAsync())
                        list.Add(resolver(reader));
                return list;
            }
        }
        protected async Task<List<T>> QueryAsync<T>(SqlConnection connection, SqlCommand cmd, Func<DbDataReader, T> resolver) where T : class
        {
            var list = new List<T>();
            cmd.Connection = connection;
            using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                    list.Add(resolver(reader));
            return list;
        }

        protected List<T> Query<T>(SqlCommand cmd, Func<DbDataReader, T> resolver) where T : class
        {
            var list = new List<T>();
            using (var connection = CreateOpenConnection())
            {
                cmd.Connection = connection;
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        list.Add(resolver(reader));
                return list;
            }
        }

        protected async Task<T> QuerySingleAsync<T>(SqlCommand cmd, Func<DbDataReader, T> resolver) where T : class
        {
            using (var connection = CreateConnection())
            {
                cmd.Connection = connection;
                await connection.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                    while (await reader.ReadAsync())
                        return resolver(reader);
                return default(T);
            }
        }

        protected async Task<T> QuerySingleAsync<T>(SqlConnection connection, SqlCommand cmd, Func<DbDataReader, T> resolver) where T : class
        {
            cmd.Connection = connection;
            using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                    return resolver(reader);
            return default(T);
        }

        protected async Task<T> QuerySingleAsync<T>(SqlTransaction tran, SqlCommand cmd, Func<DbDataReader, T> resolver) where T : class
        {
            cmd.Connection = tran.Connection;
            cmd.Transaction = tran;
            using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                    return resolver(reader);
            return default(T);
        }

        protected T QuerySingle<T>(SqlCommand cmd, Func<DbDataReader, T> resolver) where T : class
        {
            using (var connection = CreateOpenConnection())
            {
                cmd.Connection = connection;
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        return resolver(reader);
                return default(T);
            }
        }

        protected Task<DataSet> ExecuteDataSetAsync(SqlCommand cmd)
        {
            return Task<DataSet>.Factory.StartNew(() =>
            {
                var ds = new DataSet();
                using (var connection = CreateConnection())
                {
                    cmd.Connection = connection;
                    var adr = new SqlDataAdapter(cmd);
                    adr.Fill(ds);
                    return ds;
                }
            });
        }

        public DataTable ExecuteDataTable(string query)
        {
            var ds = ExecuteDataSet(new SqlCommand(query));
            return ds.Tables[0];
        }

        protected DataSet ExecuteDataSet(string sql)
        {
            return ExecuteDataSet(new SqlCommand(sql));
        }

        protected DataSet ExecuteDataSet(SqlCommand cmd)
        {
            var ds = new DataSet();
            using (var connection = CreateConnection())
            {
                cmd.Connection = connection;
                var adr = new SqlDataAdapter(cmd);
                adr.Fill(ds);
                return ds;
            }
        }

        protected DataSet ExecuteDataSet(SqlConnection connection, SqlCommand cmd)
        {
            var ds = new DataSet();
            cmd.Connection = connection;
            var adr = new SqlDataAdapter(cmd);
            adr.Fill(ds);
            return ds;
        }

        protected int ExecuteNonQuery(SqlCommand cmd)
        {
            using (var connection = CreateOpenConnection())
            {
                cmd.Connection = connection;
                return cmd.ExecuteNonQuery();
            }
        }

        protected async Task<int> ExecuteNonQueryAsync(SqlConnection connection, SqlCommand cmd)
        {
            cmd.Connection = connection;
            return await cmd.ExecuteNonQueryAsync();
        }

        protected async Task<int> ExecuteNonQueryAsync(SqlCommand cmd)
        {
            using (var connection = CreateConnection())
            {
                cmd.Connection = connection;
                await connection.OpenAsync();
                return await cmd.ExecuteNonQueryAsync();
            }
        }

        protected Task<int> ExecuteNonQueryAsync(SqlTransaction tran, SqlCommand cmd)
        {
            cmd.Connection = tran.Connection;
            cmd.Transaction = tran;
            return cmd.ExecuteNonQueryAsync();
        }

        protected async Task<object> ExecuteScalarAsync(SqlCommand cmd)
        {
            using (var connection = CreateConnection())
            {
                cmd.Connection = connection;
                await connection.OpenAsync();
                return await cmd.ExecuteScalarAsync();
            }
        }

        protected Task<object> ExecuteScalarAsync(SqlConnection conn, SqlCommand cmd)
        {
            cmd.Connection = conn;
            return cmd.ExecuteScalarAsync();
        }

        protected Task<object> ExecuteScalarAsync(SqlTransaction tran, SqlCommand cmd)
        {
            cmd.Connection = tran.Connection;
            cmd.Transaction = tran;
            return cmd.ExecuteScalarAsync();
        }

        protected object ExecuteScalar(SqlCommand cmd)
        {
            using (var connection = CreateOpenConnection())
            {
                cmd.Connection = connection;
                return cmd.ExecuteScalar();
            }
        }

        public int SelectLastID(string tableName)
        {
            using (var connection = CreateOpenConnection())
            {
                var cmd = new SqlCommand(string.Format("SELECT IDENT_CURRENT('{0}')", tableName), connection);
                var ret = ExecuteScalar(cmd);
                return (ret is DBNull) ? 0 : Convert.ToInt32(ret);
            }
        }

        protected object GetParameterValue(bool? value)
        {
            if (value.HasValue)
                return value.Value;
            else
                return DBNull.Value;
        }

        protected object GetParameterValue(short value)
        {
            if (value == 0) return DBNull.Value;
            return value;
        }

        protected object GetParameterValue(int value)
        {
            if (value == 0) return DBNull.Value;
            return value;
        }

        protected object GetParameterValue(long value)
        {
            if (value == 0) return DBNull.Value;
            return value;
        }

        protected object GetParameterValue(double value)
        {
            if (value == 0) return DBNull.Value;
            return value;
        }
        protected object GetParameterValue(decimal value)
        {
            if (value == 0) return DBNull.Value;
            return value;
        }
        protected object GetParameterValue(DateTime value)
        {
            if (value == DateTime.MinValue) return DBNull.Value;
            return value;
        }

        protected object GetParameterValue(DateTime? value)
        {
            if (value.HasValue)
                return value.Value;
            else
                return DBNull.Value;
        }

        protected object GetParameterValue(string value)
        {
            if (string.IsNullOrEmpty(value)) return DBNull.Value;
            return value;
        }
        protected object GetParameterValue(byte[] value)
        {
            if (value == null) return DBNull.Value;
            return value;
        }

        protected bool TryParseExact(string value, string format, out DateTime dt)
        {
            return DateTime.TryParseExact(value, format,
                System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt);
        }

        public const string yyMMdd = "yyMMdd";
        public const string yyMMddHHmmssfff = "yyMMddHHmmssfff";
    }
}
