namespace TCA_VMS.Models
{
    public class VisitorType
    {
        public int VisitorType_Id { get; set; }
        public string VisitorType_Name { get; set; }
        public string VisitorType_Bagde_Color { get; set; }
        public string VisitorType_Bagde_Number { get; set; }
        public string Base_Name { get; set; }
        public int VisitorType_Badge_Available { get; set; }
        public int VisitorType_Badge_InUse { get; set; }
        public DateTime VisitorType_Badge_Creation_Date { get; set; }
        public int Base_Id { get; set; }
    }
}
