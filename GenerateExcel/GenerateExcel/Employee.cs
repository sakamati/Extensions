using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateExcel
{
    public class Employee : IExcelRecord
    {
        public int EmployeeInternalId { get; set; }

        [ExcelColumnAttribute(DisplayName = "ID", Type = "Text")]
        public int EmployeeId { get; set; }

        [ExcelColumnAttribute(DisplayName = "Employee Name", Type = "Text")]
        public string Name { get; set; }

        [ExcelColumnAttribute(DisplayName = "Employee Address", Type = "Text")]
        public string Address { get; set; }
    }
}
