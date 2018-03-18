using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sure.Quartz.NET.Repository
{
    public class JobInfo_Repository
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["jobSqlConnectionString"].ConnectionString;


    }
}
