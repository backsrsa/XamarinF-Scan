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
            connection.CreateTable<DeviceUser>();
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

        public bool ExistsSuperUsuario()
        {
            bool resp = false;
            var su = connection.Table<DeviceUser>().FirstOrDefault(c => c.DeviceUserId == 1);
            try
            {
                if (su == null)
                    InsertDeviceUser(new DeviceUser()
                    {
                        Password = Security.Encriptar("cmdok"),
                        Username = "Admin"
                    });
                resp = true;
            }
            catch (Exception)
            {
                resp = false;
            }
            return resp;
        }

        public void InsertDeviceUser(DeviceUser deviceUser)
        {
            connection.Insert(deviceUser);
        }

        public DeviceUser GetDeviceUserByUsername(string username)
        {
            var user = connection.Table<DeviceUser>().FirstOrDefault(c => c.Username == username);
            return user;
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
