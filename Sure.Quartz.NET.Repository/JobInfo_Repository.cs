using Dapper;
using Sure.Quartz.NET.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sure.Quartz.NET.Repository
{
    public class JobInfo_Repository
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["jobSqlConnectionString"].ConnectionString;

        /// <summary>
        /// 加载Job数据信息
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="state">任务状态</param>
        /// <returns>数据</returns>
        public IEnumerable<SURE_QRTZ_JOBINFO> LoadJobInfos(int? id = null, int? state = null)
        {
            var whereSql = string.Empty;
            if (id != null)
                whereSql = $" WHERE Id = {id}";
            if (state != null)
                whereSql = $" WHERE State = {state}";

            string sql = $"SELECT * FROM [dbo].[SURE_QRTZ_JOBINFO] {whereSql}";
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                return dbConnection.Query<SURE_QRTZ_JOBINFO>(sql);
            }
        }


    }
}
