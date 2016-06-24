using System;
using System.Collections.Generic;
using System.Linq;
using ScannerMot.Utilities;
using SQLite.Net;
using Xamarin.Forms;

namespace ScannerMot.Models
{
    public class DataAccess : IDisposable
    {
        private SQLiteConnection connection;
        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            connection = new SQLiteConnection(config.Plataforma,
                System.IO.Path.Combine(config.DirectorioDB, "Employees.db3"));
            connection.CreateTable<Employee>();
        }

        public void InsertEmployee(Employee employee)
        {
            connection.Insert(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            connection.Update(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            connection.Delete(employee);
        }

        public Employee GetEmployee(int EmployeeId)
        {
            return connection.Table<Employee>().FirstOrDefault(c => c.EmployeeId == EmployeeId);
        }

        public List<Employee> GetEmployees()
        {
            return connection.Table<Employee>().OrderBy(c => c.Ap).ToList();
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
