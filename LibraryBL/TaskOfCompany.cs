using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5_kr
{
    public class TaskOfCompany
    {
        CompanyContext company = new CompanyContext();
        public string NewTask(int id, string description, DateTime time, string priority, string status)
        {
            Task task = new Task { Id = id, Description = description, Time = time, Priority = priority, Status = status };
            company.Tasks.Add(task);
            company.SaveChanges();
            return "Task is added";
        }
        public string DeleteTask(int id)
        {
            Task task = company.Tasks
                .Where(e => e.Id == id)
                .FirstOrDefault();
            company.Tasks.Remove(task);
            company.SaveChanges();
            return "Task is removed";
        }
        public string UpdateTask(int id, string status)
        {
            Task task = company.Tasks
                .Where(e => e.Id == id)
                .FirstOrDefault();
            task.Status = status;
            company.SaveChanges();
            return "Status is changed";
        }
        public List<Task> PrintTask()
        {
            List<Task> tasks = company.Tasks.ToList();
            return tasks;
        }
    }
}
