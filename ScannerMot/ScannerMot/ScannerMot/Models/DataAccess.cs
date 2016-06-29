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
        private readonly SQLiteConnection _connection;
        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            _connection = new SQLiteConnection(config.Plataforma,
                System.IO.Path.Combine(config.DirectorioDB, "Employees.db3"));
            _connection.CreateTable<Employee>();
            _connection.CreateTable<DeviceUser>();
        }

        public void InsertEmployee(Employee employee)
        {
            _connection.Insert(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            _connection.Update(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            _connection.Delete(employee);
        }

        public Employee GetEmployee(int employeeId)
        {
            return _connection.Table<Employee>().FirstOrDefault(c => c.EmployeeId == employeeId);
        }

        public List<Employee> GetEmployees()
        {
            return _connection.Table<Employee>().OrderBy(c => c.Ap).ToList();
        }

        public bool ExistsSuperUsuario()
        {
            bool resp;
            var su = _connection.Table<DeviceUser>().FirstOrDefault(c => c.DeviceUserId == 1);
            try
            {
                if (su == null)
                    InsertDeviceUser(new DeviceUser()
                    {
                        Password = Security.Encriptar("cmdok"),
                        Username = "admin",
                        Hotel = "Cosmo"
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
            _connection.Insert(deviceUser);
        }

        public void UpdatedDeviceUser(DeviceUser deviceUser)
        {
            _connection.Update(deviceUser);
        }

        public List<DeviceUser> GetAllUsers()
        {
            return _connection.Table<DeviceUser>().OrderBy(u => u.DeviceUserId).ToList();
        }

        public DeviceUser GetDeviceUserByUsername(string username)
        {
            var user = _connection.Table<DeviceUser>().FirstOrDefault(c => c.Username == username);
            return user;
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
