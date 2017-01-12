using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateExcel
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Employee> employeeList = new List<Employee>
            { 
                new Employee(){EmployeeInternalId = 1, EmployeeId = 101, Name="Sampath", Address="Singapore"},
                new Employee(){EmployeeInternalId = 2, EmployeeId = 102, Name="Vivek", Address="Hyderabad"},
                new Employee(){EmployeeInternalId = 3, EmployeeId = 103, Name="Prithvi", Address="Singapore"}
            };

            ExcelUtility.GenerateExcel(employeeList);
        }
    }
}
