namespace TCA_VMS.Models
{
    public class User
    {
        public int User_Id { get; set; }
        public int Base_Id { get; set; }
        public int UserType_Id { get; set; }
        public int WorkShift_Id { get; set; }
        public string User_Name { get; set; }
        public string User_Last_Name { get; set; }
        public string  User_Email { get; set; }
        public string  User_Password { get; set; }
        public bool User_Status { get; set; }
        public DateTime User_Creation_Date { get; set; }

        public string Base_Name { get; set; }
        public string UserType_Name { get; set; }
        public string WorkShift_Name { get; set; }
    }
}
