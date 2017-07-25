using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Service.Data;
using ToDoList.Service.Model;
using System.Linq;

namespace ToDoList.Service.Service
{
    public class UserService
    {
        DataSource _data;
        public UserService()
        {
            _data = new DataSource();
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="昵称"></param>
        /// <param name="密码"></param>
        /// <returns></returns>
        public bool  UserSignUp(string nickname,string password)
        {
            try
            {
                User user = new User
                {
                    Nickname = nickname,
                    Passwrod = password,
                };
                user.UserId = _data.Users.Max(u => u.UserId) + 1;
                _data.Users.Add(user);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="用户编号"></param>
        /// <param name="用户密码"></param>
        /// <returns></returns>
        public bool  UserSignIn(int userId,string password)
        {
            var user = _data.Users.SingleOrDefault(u => u.UserId == userId&& u.Passwrod == password);
            if(user!= null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 用户未完成事项统计
        /// </summary>
        /// <param name="用户编号"></param>
        /// <returns></returns>
        public List<Matter> UncompletedMatterStatistics(int userId)
        {
            var user = _data.Users.SingleOrDefault(u => u.UserId == userId);
            if(user != null)
            {
                return user.Matters.Where(m => m.State == false).ToList();
            }
            else
            {
                throw new Exception("用户编号有误");
            }
        }
        /// <summary>
        /// 查看所有事项
        /// </summary>
        /// <param name="用户编号"></param>
        /// <returns></returns>
        public List<Matter> ViewUserMatters(int userId)
        {
            var user = _data.Users.SingleOrDefault(u => u.UserId == userId);
            if(user != null)
            {
                return user.Matters.ToList();
            }
            else
            {
                throw new Exception("用户编号有误");
            }
        }
        /// <summary>
        /// 获取用户所有过期事项
        /// </summary>
        /// <param name="用户编号"></param>
        /// <returns></returns>
        public List<Matter> OverdueMattersReminders(int userId)
        {
            var user = _data.Users.SingleOrDefault(u => u.UserId == userId);
            if(user!= null)
            {
                return user.Matters.Where(m => m.IsOverdue == true).ToList();
            }
            else
            {
                throw new Exception("用户编号有误");
            }
        }
    }
}
