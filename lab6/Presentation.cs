using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5_kr
{
    class Presentation
    {
        public void PresentationFunc()
        {
            int choice;
            Presentation presentation = new Presentation();
            Console.WriteLine("Table of employees ----- 1");
            Console.WriteLine("Table of tasks ----- 2");
            Console.WriteLine("Employee ----- 3");
            Console.WriteLine("Task ----- 4");
            Console.WriteLine("Free employee ----- 5");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    presentation.PrintEmployees(choice);
                    break;
                case 2:
                    presentation.PrintTasks();
                    break;
                case 3:
                    Console.WriteLine("New employee ----- 1");
                    Console.WriteLine("Delete employee ----- 2");
                    Console.WriteLine("Update employee ----- 3");
                    choice = Convert.ToInt32(Console.ReadLine());
                    int id = Convert.ToInt32(Console.ReadLine());
                    string fullName = Console.ReadLine();
                    string _taskId = Console.ReadLine();
                    int? taskId;
                    if (_taskId == "null")
                    {
                        taskId = null;
                    }
                    else
                    {
                        taskId = Convert.ToInt32(_taskId);
                    }
                    presentation.NDEmployee(choice, id, fullName, taskId);
                    break;
                case 4:
                    Console.WriteLine("New task ----- 1");
                    Console.WriteLine("Delete task ----- 2");
                    Console.WriteLine("Update task ----- 3");
                    choice = Convert.ToInt32(Console.ReadLine());
                    int idTask = Convert.ToInt32(Console.ReadLine());
                    string description = Console.ReadLine();
                    DateTime date = DateTime.Now;
                    string priority = Console.ReadLine();
                    string status = Console.ReadLine();
                    presentation.NDTask(choice, idTask, description, date, priority, status);
                    break;
                case 5:
                    presentation.PrintEmployees(choice);
                    break;
            }
        }
        public void PrintEmployees(int choice)
        {
            EmploeesOfCompany emploees = new EmploeesOfCompany();
            List<Employee> employeesList = new List<Employee>();
            switch (choice)
            {
                case 5: employeesList = emploees.FreeEmployees();
                    if(employeesList.Count == 0)
                    {
                        Console.WriteLine("List is empty");
                    }
                    break;
                case 1: employeesList = emploees.PrintEmpl();
                    break;
            }
             
            foreach(Employee employee in employeesList)
            {
                Console.WriteLine($"{employee.Id + employee.FullName + employee.TaskId}");
            }
        }
        public void PrintTasks()
        {
            TaskOfCompany tasks = new TaskOfCompany();
            List<Task> taskList = tasks.PrintTask();
            foreach (Task task in taskList)
            {
                Console.WriteLine($"{task.Id + task.Description + task.Time.ToString() + task.Priority + task.Status}");
            }
        }
        public void NDEmployee(int choice, int id, string fullName, int? task)
        {
            EmploeesOfCompany emploees = new EmploeesOfCompany();
            switch (choice)
            {
                case 1: Console.WriteLine(emploees.NewEmployee(id, fullName, task));
                    break;
                case 2:
                    Console.WriteLine(emploees.DeleteEmployee(id));
                    break;
                case 3:
                    Console.WriteLine(emploees.UpdateEmployee(id, task));
                    break;
            }
        }
        public void NDTask(int choice, int id, string description, DateTime time, string priority, string status)
        {
            TaskOfCompany tasks = new TaskOfCompany();
            switch (choice)
            {
                case 1:
                    Console.WriteLine(tasks.NewTask(id, description, time, priority, status));
                    break;
                case 2:
                    Console.WriteLine(tasks.DeleteTask(id));
                    break;
                case 3:
                    Console.WriteLine(tasks.UpdateTask(id, status));
                    break;
            }
        }
    }
}
