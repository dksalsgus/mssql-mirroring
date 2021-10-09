using HACS.Repository.SQLBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DBState.Model
{
    public class DatabaseRepo : RepoBase
    {
        public Task<Database> Select(int DbId)
        {
            var sql = @"SELECT * FROM sysdatabases WHERE dbid=@dbid;";
            var cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@dbid", SqlDbType.Int).Value = DbId;
            return QuerySingleAsync<Database>(cmd, CreateDBEntity);
        }

        public Task<int> FailOver(string database_name)
        {
            var sql = @"ALTER DATABASE " + database_name + " SET PARTNER FAILOVER;";
            var cmd = new SqlCommand(sql);
            //cmd.Parameters.Add("@database_name", SqlDbType.VarChar).Value = database_name;
            return ExecuteNonQueryAsync(cmd);
        }

        public Task<Database> GetList()
        {
            var sql = @"SELECT * FROM sysdatabases;";
            var cmd = new SqlCommand(sql);
            return QuerySingleAsync<Database>(cmd, CreateDBEntity);
        }

        private Database CreateDBEntity(DbDataReader row)
        {
            var d = new Database();
            d.name = (row["name"] is DBNull) ? string.Empty : Convert.ToString(row["name"]);
            d.dbid = Convert.ToInt32(row["dbid"]);
            return d;
        }
    }
}