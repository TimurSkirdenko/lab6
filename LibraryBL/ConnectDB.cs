using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace lab5_kr
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public Task()
        {
            Employees = new List<Employee>();
        }
        public override string ToString()
        {
            return Description;
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int? TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
    class CompanyContext : DbContext
    {
        public CompanyContext()
            : base("CompanyDB") { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
