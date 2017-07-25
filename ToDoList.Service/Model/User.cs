using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Service.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string Nickname { get; set; }
        public string Passwrod { get; set; }
        public List<DetailedList> DetailedLists { get; set; }
        public List<Matter> Matters { get; set; }
    }
}
