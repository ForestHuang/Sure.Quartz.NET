using Sure.Quartz.NET.EFBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

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
        public Tuple<IQueryable<SURE_QRTZ_JOBINFO>, int> LoadJobInfoes<K>(Expression<Func<SURE_QRTZ_JOBINFO, bool>> whereLambda,
            Expression<Func<SURE_QRTZ_JOBINFO, K>> orderByLambda, bool isAsc, int pageIndex, int pageSize)
        {
            var jobInfoModelQueryable = _dbContext.customer_quartzjobinfo.Where(whereLambda);
            int totalCount = jobInfoModelQueryable.Count();
            return new Tuple<IQueryable<SURE_QRTZ_JOBINFO>, int>(isAsc ? jobInfoModelQueryable.OrderBy(orderByLambda).Skip(pageIndex - 1).Take(pageSize) : jobInfoModelQueryable.OrderByDescending(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize), totalCount);

        }

    }
}
