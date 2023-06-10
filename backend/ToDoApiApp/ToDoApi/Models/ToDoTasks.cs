using System;

namespace ToDoApi.Models
{
    public class ToDoTask
    {
        public int TaskId { get; set; }
        public string TaskTitle { get; set; }
        public DateTime TaskDate { get; set; }
        public TimeSpan TaskTime { get; set; }
        public bool TaskIsComplete { get; set; }
    }
}
