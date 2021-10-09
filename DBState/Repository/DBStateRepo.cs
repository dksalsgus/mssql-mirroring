using HACS.Repository.SQLBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DBState.Model
{
    public class DBStateRepo : RepoBase
    {
        public Task<List<DBState>> GetList(string PrcsCD)
        {
            var sql = @"SELECT AmrId, PrcsCD, TypeId, LayoutId, AmrNM, NetId, Host, Port, RealIP, RealPort, X, Y, LiftCnt, MDir, Area, Active, TravelDist, OprTime, StopTime, TMVersion, GMVersion, FWVersion FROM [TD_AMR] WHERE PrcsCD=@PrcsCD;";
            var cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@PrcsCD", SqlDbType.VarChar).Value = PrcsCD;
            return QueryAsync<DBState>(cmd, CreateDBStateEntity);
        }

        public Task<List<DBState>> GetList()
        {
            var sql = @"SELECT * FROM sys.database_mirroring";
            var cmd = new SqlCommand(sql);
            return QueryAsync<DBState>(cmd, CreateDBStateEntity);
        }

        public Task<DBState> Select(int DbId)
        {
            var sql = @"Select * from sysdatabases where dbid=@dbid;";
            var cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@dbid", SqlDbType.Int).Value = DbId;
            return QuerySingleAsync<DBState>(cmd, CreateDBStateEntity);
        }

        private DBState CreateDBStateEntity(DbDataReader row)
        {
            var d = new DBState();
            d.mirroring_state_desc = (row["mirroring_state_desc"] is DBNull) ? string.Empty : Convert.ToString(row["mirroring_state_desc"]);
            d.mirroring_role_desc = (row["mirroring_role_desc"] is DBNull) ? string.Empty : Convert.ToString(row["mirroring_role_desc"]);
            d.database_id = Convert.ToInt32(row["database_id"]);
            //d.AmrId = Convert.ToInt32(row["AmrId"]);
            //d.PrcsCD = Convert.ToString(row["PrcsCD"]);
            //d.TypeId = Convert.ToInt16(row["TypeId"]);
            //d.LayoutId = (row["LayoutId"] is DBNull) ? 0 : Convert.ToInt32(row["LayoutId"]);
            //d.AmrNM = (row["AmrNM"] is DBNull) ? string.Empty : Convert.ToString(row["AmrNM"]);
            //d.NetId = (row["NetId"] is DBNull) ? string.Empty : Convert.ToString(row["NetId"]);
            //d.Host = (row["Host"] is DBNull) ? string.Empty : Convert.ToString(row["Host"]);
            //d.Port = (row["Port"] is DBNull) ? 0 : Convert.ToInt32(row["Port"]);
            //d.RealIP = (row["RealIP"] is DBNull) ? string.Empty : Convert.ToString(row["RealIP"]);
            //d.RealPort = (row["RealPort"] is DBNull) ? 0 : Convert.ToInt32(row["RealPort"]);
            //d.X = (row["X"] is DBNull) ? 0 : Convert.ToInt32(row["X"]);
            //d.Y = (row["Y"] is DBNull) ? 0 : Convert.ToInt32(row["Y"]);
            //d.LiftCnt = (row["LiftCnt"] is DBNull) ? 0 : Convert.ToInt32(row["LiftCnt"]);
            //d.MDir = (row["MDir"] is DBNull) ? 0 : Convert.ToInt32(row["MDir"]);
            //d.Area = (row["Area"] is DBNull) ? string.Empty : Convert.ToString(row["Area"]);
            //d.Active = (row["Active"] is DBNull) ? false : Convert.ToBoolean(row["Active"]);
            //d.TravelDist = (row["TravelDist"] is DBNull) ? 0 : Convert.ToDouble(row["TravelDist"]);
            //d.OprTime = (row["OprTime"] is DBNull) ? 0 : Convert.ToDouble(row["OprTime"]);
            //d.StopTime = (row["StopTime"] is DBNull) ? 0 : Convert.ToDouble(row["StopTime"]);
            //d.TMVersion = (row["TMVersion"] is DBNull) ? string.Empty : Convert.ToString(row["TMVersion"]);
            //d.GMVersion = (row["GMVersion"] is DBNull) ? string.Empty : Convert.ToString(row["GMVersion"]);
            //d.FWVersion = (row["FWVersion"] is DBNull) ? string.Empty : Convert.ToString(row["FWVersion"]);
            return d;
        }

        public Task<DBState> Selects(int NetId)
        {
            var sql = @"SELECT AmrId, PrcsCD, TypeId, LayoutId, AmrNM, NetId, Host, Port, RealIP, RealPort, X, Y, LiftCnt, MDir, Area, Active, TravelDist, OprTime, StopTime, TMVersion, GMVersion, FWVersion FROM [TD_AMR] WHERE NetId=@NetId;";
            var cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@NetId", SqlDbType.Int).Value = NetId;
            return QuerySingleAsync<DBState>(cmd, CreateDBStateEntity);
        }

        public Task<List<DBState>> SelectByLayoutId(int layoutId)
        {
            var sql = @"SELECT AmrId, PrcsCD, TypeId, LayoutId, AmrNM, NetId, Host, Port, RealIP, RealPort, X, Y, LiftCnt, MDir, Area, Active, TravelDist, OprTime, StopTime, TMVersion, GMVersion, FWVersion FROM [TD_AMR] WHERE LayoutId=@layoutId;";
            var cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@LayoutId", SqlDbType.Int).Value = layoutId;
            return QueryAsync<DBState>(cmd, CreateDBStateEntity);
        }

        public Task<List<DBState>> SelectByPrcsCD(string PrcsCD)
        {
            var sql = @"SELECT AmrId, PrcsCD, TypeId, LayoutId, AmrNM, NetId, Host, Port, RealIP, RealPort, X, Y, LiftCnt, MDir, Area, Active, TravelDist, OprTime, StopTime, TMVersion, GMVersion, FWVersion FROM [TD_AMR] WHERE PrcsCD=@PrcsCD;";
            var cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@PrcsCD", SqlDbType.VarChar).Value = PrcsCD;
            return QueryAsync<DBState>(cmd, CreateDBStateEntity);
        }

        public Task<List<DBState>> SelectByPrcsCD(SqlConnection connection, string PrcsCD)
        {
            var sql = @"SELECT AmrId, PrcsCD, TypeId, LayoutId, AmrNM, NetId, Host, Port, RealIP, RealPort, X, Y, LiftCnt, MDir, Area, Active, TravelDist, OprTime, StopTime, TMVersion, GMVersion, FWVersion FROM [TD_AMR]
						 WHERE PrcsCD=@PrcsCD ORDER BY AmrNM; ";
            var cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@PrcsCD", SqlDbType.VarChar).Value = PrcsCD;
            return QueryAsync<DBState>(connection, cmd, CreateDBStateEntity);
        }

        public async Task<int> Insert(DBState d)
        {
            var sql = @"INSERT INTO [TD_AMR] (PrcsCD, TypeId, LayoutId, AmrNM, NetId, Host, Port, RealIP, RealPort, X, Y, LiftCnt, MDir, Area, Active, TravelDist, OprTime, StopTime, TMVersion, GMVersion, FWVersion) VALUES (@PrcsCD, @TypeId, @LayoutId, @AmrNM, @NetId, @Host, @Port, @X, @Y, @LiftCnt, @Area, @Active, @TravelDist, @OprTime, @StopTime, @TMVersion, @GMVersion, @FWVersion);
SELECT @@Identity; ";
            var cmd = new SqlCommand(sql);
            //cmd.Parameters.Add("@AmrId", SqlDbType.Int).Value = d.AmrId;
            //cmd.Parameters.Add("@PrcsCD", SqlDbType.VarChar).Value = d.PrcsCD;
            //cmd.Parameters.Add("@TypeId", SqlDbType.SmallInt).Value = d.TypeId;
            //cmd.Parameters.Add("@LayoutId", SqlDbType.Int).Value = GetParameterValue(d.LayoutId);
            //cmd.Parameters.Add("@AmrNM", SqlDbType.NVarChar).Value = GetParameterValue(d.AmrNM);
            //cmd.Parameters.Add("@NetId", SqlDbType.VarChar).Value = GetParameterValue(d.NetId);
            //cmd.Parameters.Add("@Host", SqlDbType.VarChar).Value = GetParameterValue(d.Host);
            //cmd.Parameters.Add("@Port", SqlDbType.Int).Value = GetParameterValue(d.Port);
            //cmd.Parameters.Add("@RealIP", SqlDbType.VarChar).Value = GetParameterValue(d.RealIP);
            //cmd.Parameters.Add("@RealPort", SqlDbType.Int).Value = GetParameterValue(d.RealPort);
            //cmd.Parameters.Add("@X", SqlDbType.Int).Value = GetParameterValue(d.X);
            //cmd.Parameters.Add("@Y", SqlDbType.Int).Value = GetParameterValue(d.Y);
            //cmd.Parameters.Add("@LiftCnt", SqlDbType.Int).Value = GetParameterValue(d.LiftCnt);
            //cmd.Parameters.Add("@MDir", SqlDbType.Int).Value = GetParameterValue(d.MDir);
            //cmd.Parameters.Add("@Area", SqlDbType.VarChar).Value = GetParameterValue(d.Area);
            //cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = d.Active;
            //cmd.Parameters.Add("@TravelDist", SqlDbType.Float).Value = GetParameterValue(d.TravelDist);
            //cmd.Parameters.Add("@OprTime", SqlDbType.Float).Value = GetParameterValue(d.OprTime);
            //cmd.Parameters.Add("@StopTime", SqlDbType.Float).Value = GetParameterValue(d.StopTime);
            //cmd.Parameters.Add("@TMVersion", SqlDbType.VarChar).Value = GetParameterValue(d.TMVersion);
            //cmd.Parameters.Add("@GMVersion", SqlDbType.VarChar).Value = GetParameterValue(d.GMVersion);
            //cmd.Parameters.Add("@FWVersion", SqlDbType.VarChar).Value = GetParameterValue(d.FWVersion);
            var ret = await ExecuteScalarAsync(cmd);
            return (ret is DBNull) ? 0 : Convert.ToInt32(ret);
            //return ExecuteNonQueryAsync(cmd);
        }

        public async Task<int> Insert(SqlTransaction tran, DBState d)
        {
            var sql = @"INSERT INTO [TD_AMR] (PrcsCD, TypeId, LayoutId, AmrNM, NetId, Host, Port, RealIP, RealPort, X, Y, LiftCnt, MDir, Area, Active, TravelDist, OprTime, StopTime, TMVersion, GMVersion, FWVersion) VALUES (@PrcsCD, @TypeId, @LayoutId, @AmrNM, @NetId, @Host, @Port,@RealIP, @RealPort, @X, @Y, @LiftCnt,@MDir, @Area, @Active, @TravelDist, @OprTime, @StopTime, @TMVersion, @GMVersion, @FWVersion);
SELECT @@Identity; ";
            var cmd = new SqlCommand(sql);
            //cmd.Parameters.Add("@AmrId", SqlDbType.Int).Value = d.AmrId;
            //cmd.Parameters.Add("@PrcsCD", SqlDbType.VarChar).Value = d.PrcsCD;
            //cmd.Parameters.Add("@TypeId", SqlDbType.SmallInt).Value = d.TypeId;
            //cmd.Parameters.Add("@LayoutId", SqlDbType.Int).Value = GetParameterValue(d.LayoutId);
            //cmd.Parameters.Add("@AmrNM", SqlDbType.NVarChar).Value = GetParameterValue(d.AmrNM);
            //cmd.Parameters.Add("@NetId", SqlDbType.VarChar).Value = GetParameterValue(d.NetId);
            //cmd.Parameters.Add("@Host", SqlDbType.VarChar).Value = GetParameterValue(d.Host);
            //cmd.Parameters.Add("@Port", SqlDbType.Int).Value = GetParameterValue(d.Port);
            //cmd.Parameters.Add("@RealIP", SqlDbType.VarChar).Value = GetParameterValue(d.RealIP);
            //cmd.Parameters.Add("@RealPort", SqlDbType.Int).Value = GetParameterValue(d.RealPort);
            //cmd.Parameters.Add("@X", SqlDbType.Int).Value = GetParameterValue(d.X);
            //cmd.Parameters.Add("@Y", SqlDbType.Int).Value = GetParameterValue(d.Y);
            //cmd.Parameters.Add("@LiftCnt", SqlDbType.Int).Value = GetParameterValue(d.LiftCnt);
            //cmd.Parameters.Add("@MDir", SqlDbType.Int).Value = GetParameterValue(d.MDir);
            //cmd.Parameters.Add("@Area", SqlDbType.VarChar).Value = GetParameterValue(d.Area);
            //cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = d.Active;
            //cmd.Parameters.Add("@TravelDist", SqlDbType.Float).Value = GetParameterValue(d.TravelDist);
            //cmd.Parameters.Add("@OprTime", SqlDbType.Float).Value = GetParameterValue(d.OprTime);
            //cmd.Parameters.Add("@StopTime", SqlDbType.Float).Value = GetParameterValue(d.StopTime);
            //cmd.Parameters.Add("@TMVersion", SqlDbType.VarChar).Value = GetParameterValue(d.TMVersion);
            //cmd.Parameters.Add("@GMVersion", SqlDbType.VarChar).Value = GetParameterValue(d.GMVersion);
            //cmd.Parameters.Add("@FWVersion", SqlDbType.VarChar).Value = GetParameterValue(d.FWVersion);
            var ret = await ExecuteScalarAsync(tran, cmd);
            return (ret is DBNull) ? 0 : Convert.ToInt32(ret);
            //return ExecuteNonQueryAsync(cmd);
        }

        public Task<int> Update(DBState d)
        {
            var sql = @"UPDATE [TD_AMR] SET PrcsCD=@PrcsCD, TypeId=@TypeId, LayoutId=@LayoutId, AmrNM=@AmrNM, NetId=@NetId, Host=@Host, Port=@Port, RealIP=@RealIP, RealPort=@RealPort, X=@X, Y=@Y, LiftCnt=@LiftCnt, MDir=@MDir, Area=@Area, Active=@Active, TravelDist=@TravelDist, OprTime=@OprTime, StopTime=@StopTime, TMVersion=@TMVersion, GMVersion=@GMVersion, FWVersion=@FWVersion
WHERE AmrId=@AmrId;";
            var cmd = new SqlCommand(sql);
            //cmd.Parameters.Add("@AmrId", SqlDbType.Int).Value = d.AmrId;
            //cmd.Parameters.Add("@PrcsCD", SqlDbType.VarChar).Value = d.PrcsCD;
            //cmd.Parameters.Add("@TypeId", SqlDbType.SmallInt).Value = d.TypeId;
            //cmd.Parameters.Add("@LayoutId", SqlDbType.Int).Value = GetParameterValue(d.LayoutId);
            //cmd.Parameters.Add("@AmrNM", SqlDbType.NVarChar).Value = GetParameterValue(d.AmrNM);
            //cmd.Parameters.Add("@NetId", SqlDbType.VarChar).Value = GetParameterValue(d.NetId);
            //cmd.Parameters.Add("@Host", SqlDbType.VarChar).Value = GetParameterValue(d.Host);
            //cmd.Parameters.Add("@Port", SqlDbType.Int).Value = GetParameterValue(d.Port);
            //cmd.Parameters.Add("@RealIP", SqlDbType.VarChar).Value = GetParameterValue(d.RealIP);
            //cmd.Parameters.Add("@RealPort", SqlDbType.Int).Value = GetParameterValue(d.RealPort);
            //cmd.Parameters.Add("@X", SqlDbType.Int).Value = GetParameterValue(d.X);
            //cmd.Parameters.Add("@Y", SqlDbType.Int).Value = GetParameterValue(d.Y);
            //cmd.Parameters.Add("@LiftCnt", SqlDbType.Int).Value = GetParameterValue(d.LiftCnt);
            //cmd.Parameters.Add("@MDir", SqlDbType.Int).Value = GetParameterValue(d.MDir);
            //cmd.Parameters.Add("@Area", SqlDbType.VarChar).Value = GetParameterValue(d.Area);
            //cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = d.Active;
            //cmd.Parameters.Add("@TravelDist", SqlDbType.Float).Value = GetParameterValue(d.TravelDist);
            //cmd.Parameters.Add("@OprTime", SqlDbType.Float).Value = GetParameterValue(d.OprTime);
            //cmd.Parameters.Add("@StopTime", SqlDbType.Float).Value = GetParameterValue(d.StopTime);
            //cmd.Parameters.Add("@TMVersion", SqlDbType.VarChar).Value = GetParameterValue(d.TMVersion);
            //cmd.Parameters.Add("@GMVersion", SqlDbType.VarChar).Value = GetParameterValue(d.GMVersion);
            //cmd.Parameters.Add("@FWVersion", SqlDbType.VarChar).Value = GetParameterValue(d.FWVersion);
            return ExecuteNonQueryAsync(cmd);
        }

        public Task<int> Update(SqlTransaction tran, DBState d)
        {
            //			var sql = @"UPDATE [TD_AMR] SET PrcsCD=@PrcsCD, TypeId=@TypeId, LayoutId=@LayoutId, AmrNM=@AmrNM, NetId=@NetId, Host=@Host, Port=@Port, X=@X, Y=@Y, LiftCnt=@LiftCnt, Area=@Area, Active=@Active, TravelDist=@TravelDist, OprTime=@OprTime, StopTime=@StopTime, TMVersion=@TMVersion, GMVersion=@GMVersion, FWVersion=@FWVersion
            //WHERE AmrId=@AmrId;";
            var sql = @"UPDATE [TD_AMR] SET PrcsCD=@PrcsCD, TypeId=@TypeId, LayoutId=@LayoutId, AmrNM=@AmrNM, NetId=@NetId, Host=@Host, Port=@Port, RealIP=@RealIP, RealPort=@RealPort, X=@X, Y=@Y, LiftCnt=@LiftCnt, MDir=@MDir, Area=@Area, Active=@Active, TMVersion=@TMVersion, GMVersion=@GMVersion, FWVersion=@FWVersion
WHERE AmrId=@AmrId;";
            var cmd = new SqlCommand(sql);
            //cmd.Parameters.Add("@AmrId", SqlDbType.Int).Value = d.AmrId;
            //cmd.Parameters.Add("@PrcsCD", SqlDbType.VarChar).Value = d.PrcsCD;
            //cmd.Parameters.Add("@TypeId", SqlDbType.SmallInt).Value = d.TypeId;
            //cmd.Parameters.Add("@LayoutId", SqlDbType.Int).Value = GetParameterValue(d.LayoutId);
            //cmd.Parameters.Add("@AmrNM", SqlDbType.NVarChar).Value = GetParameterValue(d.AmrNM);
            //cmd.Parameters.Add("@NetId", SqlDbType.VarChar).Value = GetParameterValue(d.NetId);
            //cmd.Parameters.Add("@Host", SqlDbType.VarChar).Value = GetParameterValue(d.Host);
            //cmd.Parameters.Add("@Port", SqlDbType.Int).Value = GetParameterValue(d.Port);
            //cmd.Parameters.Add("@RealIP", SqlDbType.VarChar).Value = GetParameterValue(d.RealIP);
            //cmd.Parameters.Add("@RealPort", SqlDbType.Int).Value = GetParameterValue(d.RealPort);
            //cmd.Parameters.Add("@X", SqlDbType.Int).Value = GetParameterValue(d.X);
            //cmd.Parameters.Add("@Y", SqlDbType.Int).Value = GetParameterValue(d.Y);
            //cmd.Parameters.Add("@LiftCnt", SqlDbType.Int).Value = GetParameterValue(d.LiftCnt);
            //cmd.Parameters.Add("@MDir", SqlDbType.Int).Value = GetParameterValue(d.MDir);
            //cmd.Parameters.Add("@Area", SqlDbType.VarChar).Value = GetParameterValue(d.Area);
            //cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = d.Active;
            ////cmd.Parameters.Add("@TravelDist", SqlDbType.Float).Value = GetParameterValue(d.TravelDist);
            ////cmd.Parameters.Add("@OprTime", SqlDbType.Float).Value = GetParameterValue(d.OprTime);
            ////cmd.Parameters.Add("@StopTime", SqlDbType.Float).Value = GetParameterValue(d.StopTime);
            //cmd.Parameters.Add("@TMVersion", SqlDbType.VarChar).Value = GetParameterValue(d.TMVersion);
            //cmd.Parameters.Add("@GMVersion", SqlDbType.VarChar).Value = GetParameterValue(d.GMVersion);
            //cmd.Parameters.Add("@FWVersion", SqlDbType.VarChar).Value = GetParameterValue(d.FWVersion);
            return ExecuteNonQueryAsync(tran, cmd);
        }

        public async Task<int> Updates(List<DBState> list)
        {
            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();

                var sql = @"UPDATE [TD_AMR] SET MDir=@MDir, TravelDist=@TravelDist, OprTime=@OprTime, StopTime=@StopTime WHERE AmrId=@AmrId;";
                var cmd = new SqlCommand(sql);
                cmd.Parameters.Add("@AmrId", SqlDbType.Int);
                cmd.Parameters.Add("@MDir", SqlDbType.Int);
                cmd.Parameters.Add("@TravelDist", SqlDbType.Float);
                cmd.Parameters.Add("@OprTime", SqlDbType.Float);
                cmd.Parameters.Add("@StopTime", SqlDbType.Float);

                int ret = 0;
                foreach (var d in list)
                {
                    //cmd.Parameters["@AmrId"].Value = d.AmrId;
                    //cmd.Parameters["@MDir"].Value = GetParameterValue(d.MDir);
                    //cmd.Parameters["@TravelDist"].Value = GetParameterValue(d.TravelDist);
                    //cmd.Parameters["@OprTime"].Value = GetParameterValue(d.OprTime);
                    //cmd.Parameters["@StopTime"].Value = GetParameterValue(d.StopTime);

                    ret += await ExecuteNonQueryAsync(connection, cmd);
                }
                return ret;
            }
        }

        public Task<int> Delete(DBState d)
        {
            var sql = @"DELETE FROM [TD_AMR] WHERE AmrId=@AmrId;";
            var cmd = new SqlCommand(sql);
            //cmd.Parameters.Add("@AmrId", SqlDbType.Int).Value = d.AmrId;
            return ExecuteNonQueryAsync(cmd);
        }

        public Task<int> Delete(SqlTransaction tran, DBState d)
        {
            var sql = @"DELETE FROM [TD_AMR] WHERE AmrId=@AmrId;";
            var cmd = new SqlCommand(sql);
            //cmd.Parameters.Add("@AmrId", SqlDbType.Int).Value = d.AmrId;
            return ExecuteNonQueryAsync(tran, cmd);
        }
    }
}