using System;
using TechTalk.SpecFlow;
using ToDoList.Service.Service;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToDoList.Test
{
    [Binding]
    public class AddAMatterSteps
    {
        bool singIn;
        bool result;
        int currentUserId;
        int listId;
        UserService _userSerice = new UserService();
        DetailedListService _detailedListService = new DetailedListService();
        [Given(@"我首先用账号和密码登陆""(.*)""""(.*)""")]
        public void Given我首先用账号和密码登陆(int userId, string password)
        {
            singIn = _userSerice.UserSignIn(userId, password);
            currentUserId = userId;
        }

        [Given(@"登陆之后查看到我的清单，选择一个清单进行添加")]
        public void Given登陆之后查看到我的清单选择一个清单进行添加()
        {
            if (singIn)
            {
                listId = _detailedListService.GetUserDetailedList(currentUserId).First().ListId;
            }
        }

        [When(@"输事项的内容""(.*)""")]
        public void When输事项的内容(string matterContent)
        {
            result = _detailedListService.AddMatterToDetailedList(listId, matterContent);
        }

        [Then(@"这个事项就添加到了我的清单")]
        public void Then这个事项就添加到了我的清单()
        {
            Assert.IsTrue(result);
        }
    }
}
