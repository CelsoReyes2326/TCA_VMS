namespace TCA_VMS.Models
{
    public class VisitorsReport
    {
        public int VisitorsReport_Id { get; set; }
        public int Company_Id { get; set; }
        public int IDType_Id { get; set; }
        public int VisitorType_Id { get; set; }
        public int User_Id { get; set; }
        public int Base_Id { get; set; }
        public string VisitorsReport_Badge_Number { get; set; }
        public string VisitorsReport_Name { get; set; }
        public string VisitorsReport_LastName { get; set; }
        public string VisitorsReport_Subject { get; set; }
        public string VisitorsReport_RecievedBy { get; set; }
        public DateTime VisitorsReport_StartHour { get; set; }    //automatico
        public DateTime VisitorsReport_OutHour { get; set; }      //automatico
        public bool VisitorsReport_Status { get; set; } //automatico
        public string VisitorsReport_Photo { get; set; }
        public bool VisitorsReport_Laptop { get; set; }
        public string VisitorsReport_Laptop_Brand { get; set; }
        public string VisitorsReport_Laptop_Serial_Number { get; set; }
        public string VisitorsReport_RegisteredBy { get; set; }  //automatico
        public string VisitorReport_Creation_Date { get; set; } //automatico

        public string Company_Name { get; set; }
        public string IDType_Name { get; set; }
        public string VisitorType_Name { get; set; }
        public string User_UserName { get; set; }
        public string Base_Name { get; set; }
        public string LaptopRegistered { get; set; }
        public bool VisitorsReport_Laptop_Status { get; set; }


    }
}
