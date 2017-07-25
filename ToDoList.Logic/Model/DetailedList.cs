using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Logic.Model
{
     public  class DetailedList
    {
        public int ListId { get; set; }
        public string ListName { get; set; }
        public DateTime CreateTime { get; set; }
        public User User { get; set; }
        public List<Matter> Matters { get; set; }
    }
}
