namespace TCA_VMS.Models
{
    public class Company
    {
        public int Company_Id { get; set; }
        public string Company_Name { get; set; }
        public string Company_Address { get; set; }
        public string Company_Phone_Number { get; set; }
        public bool Company_Status { get; set; }
        public DateTime Company_Creation_Date { get; set; }
    }
}
