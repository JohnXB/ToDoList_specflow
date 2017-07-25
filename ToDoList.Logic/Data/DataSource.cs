using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Logic.Model;
namespace ToDoList.Logic.Data
{
    public class DataSource
    {
        public List<User> Users { get; set; }
        public List<DetailedList> DetailedLists { get; set; }
        public List<Matter> Matters { get; set; }
        public DataSource()
        {
            //初始化一个用户
            var tempUser = new User()
            {
                UserId = 1,
                Nickname = "show",
                Passwrod = "123456",
            };
            //初始化一个清单
            var tempDetailedList = new DetailedList
            {
                CreateTime = DateTime.Now,
                ListNmae = "我的一天"             
            };
            //初始化一些事项
            List<Matter> someMatters = new List<Matter>()
          {
                new Matter
                {
                    CreateTime = DateTime.Now,
                    IsOverdue =false,
                    MatterContent="今晚去理发",
                    Remarks = "不去门口那家店",
                    State = false,
                    DetailedList = tempDetailedList,
                    User = tempUser
                },
                 new Matter
                {
                    CreateTime = DateTime.Now,
                    IsOverdue =false,
                    MatterContent="今晚去吃老麻",
                    Remarks = "记得抢红包",
                    State = false,
                    DetailedList = tempDetailedList,
                    User = tempUser
                }
          };
            //将事项添加进清单
            tempDetailedList.Matters = new List<Matter>();
            tempDetailedList.Matters.AddRange(someMatters);
            //添加一个清单给用户
            tempUser.DetailedLists = new List<DetailedList>();
            tempUser.DetailedLists.Add(tempDetailedList);
            tempDetailedList.User = tempUser;
            //将事项添加给用户
            tempUser.Matters.AddRange(someMatters);
            //在所有初始化完成后加入到总的数据源中
            Users = new List<User>();
            DetailedLists = new List<DetailedList>();
            Matters = new List<Matter>();
            Users.Add(tempUser);
            DetailedLists.Add(tempDetailedList);
            Matters.AddRange(Matters);
        }
    }
}
