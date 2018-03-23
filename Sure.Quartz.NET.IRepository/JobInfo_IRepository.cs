using Sure.Quartz.NET.EFBase;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Sure.Quartz.NET.IRepository
{
    /// <summary>
    /// Job CURD
    /// </summary>
    public interface JobInfo_IRepository
    {
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
        Tuple<IQueryable<SURE_QRTZ_JOBINFO>, int> Load<T>(Expression<Func<SURE_QRTZ_JOBINFO, T>> orderByLambda, bool isAsc, Expression<Func<SURE_QRTZ_JOBINFO, bool>> whereLambda = null, int pageIndex = 1, int pageSize = 10);

        /// <summary>
        /// 加载数据信息，单条数据
        /// </summary>
        /// <param name="whereLambda">条件表达式</param>
        /// <returns>数据信息单条</returns>
        SURE_QRTZ_JOBINFO Load(Expression<Func<SURE_QRTZ_JOBINFO, bool>> whereLambda);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="jobInfoModel">数据信息</param>
        /// <returns>ID</returns>
        int Update(SURE_QRTZ_JOBINFO jobInfoModel);
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="jobInfoModel">数据信息</param>
        /// <returns>ID</returns>
        int Add(SURE_QRTZ_JOBINFO jobInfoModel);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="Id">数据ID</param>
        /// <returns>ID</returns>
        int Delete(int Id);
    }
}
