using Sure.Quartz.NET.Common;
using Sure.Quartz.NET.EFBase;
using Sure.Quartz.NET.IRepository;
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel.Composition;

namespace Sure.Quartz.NET.Repository
{
    [Export("JobInfo_Repository", typeof(JobInfo_IRepository))]

    /// <summary>
    /// Job CURD
    /// </summary>
    public class JobInfo_Repository : JobInfo_IRepository
    {
        private static JobEntities dbContext = null;

        /// <summary>
        /// 无参构造
        /// </summary>
        public JobInfo_Repository()
        {
            dbContext = new JobEntities();
        }

        /// <summary>
        /// 加载数据信息，多条数据
        /// </summary>
        /// <typeparam name="T">占位符，泛型</typeparam>
        /// <param name="whereLambda">条件表达式</param>
        /// <param name="orderByLambda">排序表达式</param>
        /// <param name="isAsc">是否排序</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示数</param>
        /// <returns>数据信息</returns>
        public Tuple<IQueryable<SURE_QRTZ_JOBINFO>, int> Load<T>(Expression<Func<SURE_QRTZ_JOBINFO, T>> orderByLambda, bool isAsc, Expression<Func<SURE_QRTZ_JOBINFO, bool>> whereLambda = null, int pageIndex = 1, int pageSize = 10)
        {
            try
            {
                var jobInfoModelQueryable = dbContext.SURE_QRTZ_JOBINFO.Where(whereLambda);
                int totalCount = jobInfoModelQueryable.Count();
                return new Tuple<IQueryable<SURE_QRTZ_JOBINFO>, int>(isAsc
                    ? jobInfoModelQueryable.OrderBy(orderByLambda).Skip(pageIndex - 1).Take(pageSize)
                    : jobInfoModelQueryable.OrderByDescending(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize), totalCount);
            }
            catch (Exception ex)
            {
                throw new Exception($"多个查询失败,Message:{ex.Message}");
            }
        }

        /// <summary>
        /// 加载数据信息，单条数据
        /// </summary>
        /// <param name="whereLambda">条件表达式</param>
        /// <returns>数据信息单条</returns>
        public SURE_QRTZ_JOBINFO Load(Expression<Func<SURE_QRTZ_JOBINFO, bool>> whereLambda)
        {
            try
            {
                return dbContext.SURE_QRTZ_JOBINFO.SingleOrDefault<SURE_QRTZ_JOBINFO>(whereLambda);
            }
            catch (Exception ex)
            {
                throw new Exception($"单个查询失败,Message:{ex.Message}");
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="jobInfoModel">数据信息</param>
        /// <returns>ID</returns>
        public int Update(SURE_QRTZ_JOBINFO jobInfoModel)
        {
            try
            {
                dbContext.SaveChanges();
                return jobInfoModel.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"更新失败,Message:{ex.Message}");
            }
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="jobInfoModel">数据信息</param>
        /// <returns>ID</returns>
        public int Add(SURE_QRTZ_JOBINFO jobInfoModel)
        {
            try
            {
                var jobInfo = dbContext.SURE_QRTZ_JOBINFO.Add(new SURE_QRTZ_JOBINFO()
                {
                    JobName = jobInfoModel.JobName,
                    JobGroupName = jobInfoModel.JobGroupName,
                    TriggerName = jobInfoModel.TriggerName,
                    TriggerGroupName = jobInfoModel.TriggerGroupName,
                    Cron = jobInfoModel.Cron,
                    Deleted = false,
                    Description = jobInfoModel.Description,
                    State = jobInfoModel.State,
                    PreTime = null,
                    NextTime = null,
                    DLLName = $"{jobInfoModel.DLLName}.dll",
                    FullJobName = jobInfoModel.FullJobName,
                    RequestUrl = jobInfoModel.RequestUrl,
                    StartTime = jobInfoModel.StartTime == null ? DateTimeOffset.UtcNow.LocalDateTime : jobInfoModel.StartTime,
                    EndTime = jobInfoModel.EndTime
                });
                dbContext.SaveChanges();
                return jobInfo.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"新增失败,Message:{ex.Message}");
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="Id">数据ID</param>
        /// <returns>ID</returns>
        public int Delete(int Id)
        {
            try
            {
                var jobInfo = dbContext.SURE_QRTZ_JOBINFO.FirstOrDefault(m => m.Id == Id);
                return dbContext.SURE_QRTZ_JOBINFO.Remove(jobInfo).Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"删除失败,Message:{ex.Message}");
            }
        }
    }
}
