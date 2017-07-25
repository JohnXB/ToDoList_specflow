using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Logic.Data;
using System.Linq;
using ToDoList.Logic.Model;

namespace ToDoList.Logic.Service
{
    public class DetailedListService
    {
        DataSource _data;
        public DetailedListService()
        {
            _data = new DataSource();
        }
        /// <summary>
        /// 创建清单
        /// </summary>
        /// <param name="用户编号"></param>
        /// <param name="清单名称"></param>
        /// <returns></returns>
        public bool CreateDetailedList(int userId, string listName)
        {
            var user = _data.Users.SingleOrDefault(u => u.UserId == userId);
            if(user != null)
            {
                DetailedList list = new DetailedList()
                {
                    CreateTime = DateTime.Now,
                    ListName = listName
                };
                list.ListId = _data.DetailedLists.Max(d => d.ListId) + 1;
                list.User = user;
                _data.DetailedLists.Add(list);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 添加事项到清单
        /// </summary>
        /// <param name="清单编号"></param>
        /// <param name="事项内容"></param>
        /// <param name="备注"></param>
        /// <param name="过期事件"></param>
        /// <returns></returns>
        public bool AddMatterToDetailedList(int listId,string matterContent,string remarks,DateTime overdueTime)
        {
            var list = _data.DetailedLists.SingleOrDefault(d => d.ListId == listId);
            if (list != null)
            {
                Matter matter = new Matter
                {
                    CreateTime = DateTime.Now,
                    DetailedList = list,
                    IsOverdue = false,
                    MatterContent = matterContent,
                    OverdueTime = overdueTime,
                    Remarks = remarks,
                    State = false,
                    User = list.User
                };
                matter.MatterId = _data.Matters.Max(m => m.MatterId) + 1;
                list.Matters.Add(matter);
                _data.Matters.Add(matter);
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 从清单删除事项
        /// </summary>
        /// <param name="清单编号"></param>
        /// <param name="事项编号"></param>
        /// <returns></returns>
        public bool DeleteMatterFromDetailedList(int listId,int matterId)
        {
            var list = _data.DetailedLists.SingleOrDefault(d => d.ListId == listId);
            var matter = _data.Matters.SingleOrDefault(m => m.MatterId == matterId);
            if (list != null && matter != null)
            {
                list.Matters.Remove(matter);
                list.User.Matters.Remove(matter);
                _data.Matters.Remove(matter);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 修改清单的名称
        /// </summary>
        /// <param name="清单编号"></param>
        /// <param name="清单名称"></param>
        /// <returns></returns>
        public bool ModifyListName(int listId,string listName)
        {
            var list = _data.DetailedLists.SingleOrDefault(d => d.ListId == listId);
            if (list != null)
            {
                list.ListName = listName;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
