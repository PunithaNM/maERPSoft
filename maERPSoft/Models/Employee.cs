using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using maERPSoft.Data;

namespace maERPSoft.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
    }
}
