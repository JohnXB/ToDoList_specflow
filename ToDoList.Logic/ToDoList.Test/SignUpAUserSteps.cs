using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using ToDoList.Service.Service;

namespace ToDoList.Test
{
    [Binding]
    public class SignUpAUserSteps
    {
        bool result;
        UserService _userService = new UserService();
        [Given(@"我输入昵称和密码""(.*)""""(.*)""进行注册")]
        public void Given我输入昵称和密码进行注册(string nickname, string password)
        {
            result =  _userService.UserSignUp(nickname,password);
        }
        
        [Then(@"成功注册一个用户")]
        public void Then成功注册一个用户()
        {
            Assert.IsTrue(result);
        }
    }
}
