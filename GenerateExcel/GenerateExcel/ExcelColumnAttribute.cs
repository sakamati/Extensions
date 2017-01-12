using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateExcel
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class ExcelColumnAttribute : Attribute
    {
        public ExcelColumnAttribute()
        {

        }

        public ExcelColumnAttribute(string displayName, string type)
        {
            this.DisplayName = displayName;
            this.Type = type;
        }

        public string DisplayName { get; set; }
        public string Type { get; set; }
    }
}
