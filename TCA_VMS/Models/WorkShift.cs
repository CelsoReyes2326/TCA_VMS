namespace TCA_VMS.Models
{
    public class WorkShift
    {
        public int WorkShift_Id { get; set; }
        public string WorkShift_Name { get; set; }
        public string WorkShift_Start_Hour { get; set; }
        public string WorkShift_Out_Hour { get; set; }
        public DateTime WorkShift_Creation_Date { get; set; }
    }
}
