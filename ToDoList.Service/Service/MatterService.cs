using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Service.Data;
using System.Linq;
using ToDoList.Service.Model;

namespace ToDoList.Service.Service
{
    public class MatterService
    {
        DataSource _data;
        public MatterService()
        {
            _data = new DataSource();
        }
        /// <summary>
        /// 给事项添加备注
        /// </summary>
        /// <param name="事项编号"></param>
        /// <param name="备注"></param>
        /// <returns></returns>
        public bool AddRemarksToMatter(int matterId,string remarks)
        {
            var matter = _data.Matters.SingleOrDefault(m => m.MatterId == matterId);
            if (matter != null)
            {
                matter.Remarks = remarks;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 添加过期时间到事项
        /// </summary>
        /// <param name="事项编号"></param>
        /// <param name="过期时间"></param>
        /// <returns></returns>
        public bool AddOverdueTimeToMatter(int matterId,DateTime overdueTime)
        {
            var matter = _data.Matters.SingleOrDefault(m => m.MatterId == matterId);
            if (matter != null)
            {
                matter.OverdueTime  = overdueTime;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 完成事项
        /// </summary>
        /// <param name="事项编号"></param>
        /// <returns></returns>
        public bool CompleteMatter(int matterId)
        {
            var matter = _data.Matters.SingleOrDefault(m => m.MatterId == matterId);
            if (matter != null)
            {
                matter.State = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 取消完成事项
        /// </summary>
        /// <param name="事项编号"></param>
        /// <returns></returns>
        public bool RevertCompleteMatter(int matterId)
        {
            var matter = _data.Matters.SingleOrDefault(m => m.MatterId == matterId);
            if (matter != null)
            {
                matter.State = false;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
