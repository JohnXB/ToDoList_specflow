using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Logic.Model
{
    public class Matter
    {
        public int MatterId { get; set; }
        public string MatterContent { get; set; }
        public DateTime CreateTime { get; set; }
        public bool State { get; set; }
        public bool IsOverdue { get; set; }
        public string Remarks { get; set; }
        public DateTime OverdueTime { get; set; }
        public DetailedList DetailedList { get; set; }
        public User User { get; set; }
    }
}
