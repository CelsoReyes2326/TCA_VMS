using System;

namespace TCA_VMS.Models
{
    public class Base
    {
        public int Base_Id { get; set; }
        public string Base_Name { get; set; }
        public string Base_Location { get; set; }
        public bool Base_Status { get; set; }
        public DateTime Base_Creation_Date { get; set; }
    }
}
