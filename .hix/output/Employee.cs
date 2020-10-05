using System;
using System.Collections.Generic;
using System.Text;

namespace JBPOS.Models
{
    public class Employee
    {
        [Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		
    }
}

