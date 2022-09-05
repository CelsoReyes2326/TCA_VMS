using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using static TCA_VMS.Models.VisitorType;

namespace TCA_VMS.Models.DAO
{
    public class TCA_VMS_DAO
    {
        //FUNCTIONS CREATION


        #region Base
        public static Result StoreBase(Base _base)
        {
            Result result = new Result();
            var spOption = 1;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@Base_Name", _base.Base_Name)
                      .AddParam("@Base_Location", _base.Base_Location)
                      .AddParam("@SpOption", spOption)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[BaseProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }

            return result;
        }

        public static List<Base> GetBases()
        {
            var spOption = 3;
            List<Base> lstBases = null;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SpOption", spOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[BaseProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstBases = new List<Base>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstBases.Add(new Base()
                            {
                                Base_Id = Convert.ToInt32(item["Base_Id"]),
                                Base_Name = item["Base_Name"].ToString(),
                                Base_Location = item["Base_Location"].ToString(),
                                Base_Status = Convert.ToBoolean(item["Base_Status"]),
                                Base_Creation_Date = Convert.ToDateTime(item["Base_Creation_Date"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return lstBases;
        }

        public static Base GetBase(int id)
        {
            var spOption = 2;
            Base _base = new Base();
            using (var bl = new Business())
            {
                DataTable dtHeader = bl.AddParam("@Base_Id", id).AddParam("@SpOption", spOption)
                                   .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[BaseProcedures]");

                if (dtHeader.Rows.Count > 0)
                {
                    _base.Base_Id = Convert.ToInt32(dtHeader.Rows[0]["Base_Id"]);
                    _base.Base_Name = dtHeader.Rows[0]["Base_Name"].ToString();
                    _base.Base_Location = dtHeader.Rows[0]["Base_Location"].ToString();
                    _base.Base_Creation_Date = Convert.ToDateTime(dtHeader.Rows[0]["Base_Creation_Date"]);
                    _base.Base_Status = Convert.ToBoolean(dtHeader.Rows[0]["Base_Status"]);
                }
            }
            return _base;
        }

        public static Result UpdateBase(Base _base)
        {
            Result result = new Result();
            var spOption = 4;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@Base_Id", _base.Base_Id)
                      .AddParam("@Base_Name", _base.Base_Name)
                      .AddParam("@Base_Status", _base.Base_Status)
                      .AddParam("@Base_Location", _base.Base_Location)
                      .AddParam("@SpOption", spOption)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[BaseProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        #endregion

        #region UserType

        public static Result StoreUserType(UserType _userType)
        {
            Result result = new Result();
            var spOption = 1;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@SpOption",spOption)
                      .AddParam("@UserType_Name", _userType.UserType_Name)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[UserTypesProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }

            return result;
        }

        public static List<UserType> GetUserTypes(string userTypeName)
        {
            List<UserType> lstUserTypes = null;
            var spOption = 3;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SpOption",spOption)
                        .AddParam("@userTypeName", userTypeName)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[UserTypesProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstUserTypes = new List<UserType>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstUserTypes.Add(new UserType()
                            {
                                UserType_Id = Convert.ToInt32(item["UserType_Id"]),
                                UserType_Name = item["UserType_Name"].ToString(),
                                UserType_Creation_Date = Convert.ToDateTime(item["UserType_Creation_Date"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return lstUserTypes;
        }

        public static UserType GetUserType(int id)
        {
            UserType _userType = new UserType();
            var spOption = 2;
            using (var bl = new Business())
            {
                DataTable dtHeader = bl.AddParam("@SpOption", spOption)
                                   .AddParam("@UserType_Id", id)
                                   .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[UserTypesProcedures]");

                if (dtHeader.Rows.Count > 0)
                {
                    _userType.UserType_Id = Convert.ToInt32(dtHeader.Rows[0]["UserType_Id"]);
                    _userType.UserType_Name = dtHeader.Rows[0]["UserType_Name"].ToString();
                    _userType.UserType_Creation_Date = Convert.ToDateTime(dtHeader.Rows[0]["UserType_Creation_Date"]);
                }
            }
            return _userType;
        }

        public static Result UpdateUserType(UserType _userType)
        {
            Result result = new Result();
            var spOption = 4;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@SpOption", spOption)
                      .AddParam("@UserType_Id", _userType.UserType_Id)
                      .AddParam("@UserType_Name", _userType.UserType_Name)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[UserTypesProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        #endregion

        #region Work Shift

        public static Result StoreWorkShift(WorkShift _workShift)
        {
            Result result = new Result();
            var spOption = 1;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@SpOption",spOption)
                      .AddParam("@WorkShift_Name", _workShift.WorkShift_Name)
                      .AddParam("@WorkShift_Start_Hour", _workShift.WorkShift_Start_Hour)
                      .AddParam("@WorkShift_Out_Hour", _workShift.WorkShift_Out_Hour)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[WorkShiftsProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }

            return result;
        }

        public static List<WorkShift> GetWorkShifts()
        {
            List<WorkShift> lstWorkShifts = null;
            var spOption = 3;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SpOption", spOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[WorkShiftsProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstWorkShifts = new List<WorkShift>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstWorkShifts.Add(new WorkShift()
                            {
                                WorkShift_Id = Convert.ToInt32(item["WorkShift_Id"]),
                                WorkShift_Name = item["WorkShift_Name"].ToString(),
                                WorkShift_Start_Hour = item["WorkShift_Start_Hour"].ToString(),
                                WorkShift_Out_Hour = item["WorkShift_Out_Hour"].ToString(),
                                WorkShift_Creation_Date = Convert.ToDateTime(item["WorkShift_Creation_Date"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return lstWorkShifts;
        }

        public static WorkShift GetWorkShift(int id)
        {
            WorkShift _workShift = new WorkShift();
            var spOption = 2;
            using (var bl = new Business())
            {
                DataTable dtHeader = bl.AddParam("@SpOption", spOption)
                    .AddParam("@WorkShift_Id", id)
                                   .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[WorkShiftsProcedures]");

                if (dtHeader.Rows.Count > 0)
                {
                    _workShift.WorkShift_Id = Convert.ToInt32(dtHeader.Rows[0]["WorkShift_Id"]);
                    _workShift.WorkShift_Name = dtHeader.Rows[0]["WorkShift_Name"].ToString();
                    _workShift.WorkShift_Start_Hour = dtHeader.Rows[0]["WorkShift_Start_Hour"].ToString();
                    _workShift.WorkShift_Out_Hour = dtHeader.Rows[0]["WorkShift_Out_Hour"].ToString();
                    _workShift.WorkShift_Creation_Date = Convert.ToDateTime(dtHeader.Rows[0]["WorkShift_Creation_Date"]);
                }
            }
            return _workShift;
        }

        public static Result UpdateWorkShift(WorkShift _workShift)
        {
            Result result = new Result();
            var spOption = 4;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@SpOption", spOption)
                      .AddParam("@WorkShift_Id", _workShift.WorkShift_Id)
                      .AddParam("@WorkShift_Name", _workShift.WorkShift_Name)
                      .AddParam("@WorkShift_Start_Hour", _workShift.WorkShift_Start_Hour)
                      .AddParam("@WorkShift_Out_Hour", _workShift.WorkShift_Out_Hour)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[WorkShiftsProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }
        #endregion

        #region User

        public static Result StoreUser(User _user)
        {
            _user.User_Password = GetSHA256(_user.User_Password);
            Result result = new Result();
            var spOption = 1;
            using (var bl = new Business())
            {
                try
                {

                        bl.AddParam("@SpOption", spOption)
                          .AddParam("@Base_Id", _user.Base_Id)
                          .AddParam("@UserType_Id", _user.UserType_Id)
                          .AddParam("@WorkShift_Id", _user.WorkShift_Id)
                          .AddParam("@User_Name", _user.User_Name)
                          .AddParam("@UserName", _user.UserName)
                          .AddParam("@User_Last_Name", _user.User_Last_Name)
                          .AddParam("@User_Password", _user.User_Password)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[UsersProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }

            return result;
        }

        public static Result StoreUserSA(User _user)
        {
            _user.User_Password = GetSHA256(_user.User_Password);
            Result result = new Result();
            var spOption = 2;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@SpOption",spOption)
                      .AddParam("@Base_Id", _user.Base_Id)
                      .AddParam("@UserType_Id", _user.UserType_Id)
                      .AddParam("@WorkShift_Id", _user.WorkShift_Id)
                      .AddParam("@User_Name", _user.User_Name)
                      .AddParam("@UserName", _user.UserName)
                      .AddParam("@User_Last_Name", _user.User_Last_Name)
                      .AddParam("@User_Email", _user.User_Email)
                      .AddParam("@User_Password", _user.User_Password)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[UsersProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        public static List<User> GetUsers()
        {
            List<User> lstUsers = null;
            var spOption = 3;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SpOption",spOption)
                        //.AddParam("@userTypeName",userTypeName)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[UsersProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstUsers = new List<User>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstUsers.Add(new User()
                            {
                                User_Id = Convert.ToInt32(item["User_Id"]),
                                User_Name = item["User_Name"].ToString(),
                                UserName = item["UserName"].ToString(),
                                User_Status = Convert.ToBoolean(item["User_Status"]),
                                Base_Name = item["Base_Name"].ToString(),
                                UserType_Name = item["UserType_Name"].ToString(),
                                WorkShift_Name = item["WorkShift_Name"].ToString(),
                                User_Creation_Date = Convert.ToDateTime(item["User_Creation_Date"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return lstUsers;
        }

        public static User GetUser(int id)
        {
            User _user = new User();
            var spOption = 4;
            using (var bl = new Business())
            {
                DataTable dtHeader = bl
                                   .AddParam("@SpOption",spOption)
                                   .AddParam("@User_Id", id)
                                   .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[UsersProcedures]");

                if (dtHeader.Rows.Count > 0)
                {
                    _user.User_Id = Convert.ToInt32(dtHeader.Rows[0]["User_Id"]);
                    _user.Base_Id = Convert.ToInt32(dtHeader.Rows[0]["Base_Id"]);
                    _user.UserType_Id = Convert.ToInt32(dtHeader.Rows[0]["UserType_Id"]);
                    _user.WorkShift_Id = Convert.ToInt32(dtHeader.Rows[0]["WorkShift_Id"]);
                    _user.WorkShift_Name = dtHeader.Rows[0]["WorkShift_Name"].ToString();
                    _user.UserType_Name = dtHeader.Rows[0]["UserType_Name"].ToString();
                    _user.Base_Name = dtHeader.Rows[0]["Base_Name"].ToString();
                    _user.User_Name = dtHeader.Rows[0]["User_Name"].ToString();
                    _user.UserName = dtHeader.Rows[0]["UserName"].ToString();
                    _user.User_Status = Convert.ToBoolean(dtHeader.Rows[0]["User_Status"]);
                    _user.User_Creation_Date = Convert.ToDateTime(dtHeader.Rows[0]["User_Creation_Date"]);
                }
            }
            return _user;
        }

        public static Result UpdateUser(User _user)
        {
            Result result = new Result();
            var spOption = 5;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@SpOption", spOption)
                      .AddParam("@User_Id", _user.User_Id)
                      .AddParam("@Base_Id", _user.Base_Id)
                      .AddParam("@UserType_Id", _user.UserType_Id)
                      .AddParam("@WorkShift_Id", _user.WorkShift_Id)
                      .AddParam("@User_Name", _user.User_Name)
                      .AddParam("@User_Last_Name", _user.User_Last_Name)
                      .AddParam("@UserName", _user.UserName)
                      .AddParam("@User_Email", _user.User_Email)
                      .AddParam("@User_Password", _user.User_Password)
                      .AddParam("@User_Status", _user.User_Status)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[UsersProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        public static User GetUserLogin(string userName, string password)
        {
            User _user = new User();
            using (var bl = new Business())
            {
                DataTable dtHeader = bl
                                   .AddParam("@UserName", userName)
                                   .AddParam("@Password", password)
                                   .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[Login]");

                if (dtHeader.Rows.Count > 0)
                {
                    _user.User_Id = Convert.ToInt32(dtHeader.Rows[0]["User_Id"]);
                    _user.UserType_Id = Convert.ToInt32(dtHeader.Rows[0]["UserType_Id"]);
                    _user.UserName = dtHeader.Rows[0]["User_Name"].ToString();
                    _user.UserType_Name = dtHeader.Rows[0]["UserType_Name"].ToString();
                    _user.User_Status = Convert.ToBoolean(dtHeader.Rows[0]["User_Status"]);
                }
            }
            return _user;
        }


        #endregion

        #region Company

        public static Result StoreCompany(Company _company)
        {
            Result result = new Result();
            var spOption = 1;
            using (var bl = new Business())
            {
                try
                {
                    bl
                      .AddParam("@Company_Name", _company.Company_Name)
                      .AddParam("@Company_Address", _company.Company_Address)
                      .AddParam("@Company_Phone_Number", _company.Company_Phone_Number)
                      .AddParam("@SpOption", spOption)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[CompanyProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {

                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        public static List<Company> GetCompanies()
        {
            List<Company> lstCompanies = null;
            var spOption = 3;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl
                        .AddParam("@SpOption", spOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[CompanyProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstCompanies = new List<Company>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstCompanies.Add(new Company()
                            {
                                Company_Id = Convert.ToInt32(item["Company_Id"]),
                                Company_Name = item["Company_Name"].ToString(),
                                Company_Address = item["Company_Address"].ToString(),
                                Company_Phone_Number = item["Company_Phone_Number"].ToString(),
                                Company_Status = Convert.ToBoolean(item["Company_Status"]),
                                Company_Creation_Date = Convert.ToDateTime(item["Company_Creation_Date"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return lstCompanies;
        }

        public static Company GetCompany(int id)
        {
            Company _company = new Company();
            var spOption = 2;
            using (var bl = new Business())
            {
                DataTable dtHeader = bl
                                   .AddParam("@SpOption",spOption)
                                   .AddParam("@Company_Id", id)
                                   .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[CompanyProcedures]");

                if (dtHeader.Rows.Count > 0)
                {
                    _company.Company_Id = Convert.ToInt32(dtHeader.Rows[0]["Company_Id"]);
                    _company.Company_Name = dtHeader.Rows[0]["Company_Name"].ToString();
                    _company.Company_Address = dtHeader.Rows[0]["Company_Address"].ToString();
                    _company.Company_Phone_Number = dtHeader.Rows[0]["Company_Phone_Number"].ToString();
                    _company.Company_Creation_Date = Convert.ToDateTime(dtHeader.Rows[0]["Company_Creation_Date"]);
                    _company.Company_Status = Convert.ToBoolean(dtHeader.Rows[0]["Company_Status"]);
                }
            }
            return _company;
        }

        public static Result UpdateCompany(Company _company)
        {
            Result result = new Result();
            var spOption = 4;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@SpOption",spOption)
                      .AddParam("@Company_Id", _company.Company_Id)
                      .AddParam("@Company_Name", _company.Company_Name)
                      .AddParam("@Company_Address", _company.Company_Address)
                      .AddParam("@Company_Phone_Number", _company.Company_Phone_Number)
                      .AddParam("@Company_Status", _company.Company_Status)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[CompanyProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }
        #endregion

        #region IDType
        public static Result StoreIDType(IDType _idType)
        {
            Result result = new Result();
            var SpOption = 1;
            using (var bl = new Business())
            {
                try
                {

                    bl
                      .AddParam("@SpOption", SpOption)
                      .AddParam("@IDType_Name", _idType.IDType_Name)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[IDTypesProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }

            return result;
        }

        public static List<IDType> GetIDTypes()
        {
            List<IDType> lstIDTypes = null;
            var SpOption = 3;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl
                        .AddParam("@SpOption", SpOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[IDTypesProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstIDTypes = new List<IDType>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstIDTypes.Add(new IDType()
                            {
                                IDType_Id = Convert.ToInt32(item["IDType_Id"]),
                                IDType_Name = item["IDType_Name"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return lstIDTypes;
        }

        public static IDType GetIDType(int id)
        {
            IDType _IDType = new IDType();
            var SpOption = 2;
            using (var bl = new Business())
            {
                DataTable dtHeader = bl
                                   .AddParam("@SpOption", SpOption)
                                   .AddParam("@IDType_Id", id)
                                   .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[IDTypesProcedures]");

                if (dtHeader.Rows.Count > 0)
                {
                    _IDType.IDType_Id = Convert.ToInt32(dtHeader.Rows[0]["IDType_Id"]);
                    _IDType.IDType_Name = dtHeader.Rows[0]["IDType_Name"].ToString();
                }
            }
            return _IDType;
        }

        public static Result UpdateIDType(IDType _IDType)
        {
            Result result = new Result();
            var SpOption = 4;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@SpOption", SpOption)
                      .AddParam("@IDType_Id", _IDType.IDType_Id)
                      .AddParam("@IDType_Name", _IDType.IDType_Name)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[IDTypesProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        #endregion

        #region VisitorType

        public static Result StoreVisitorType(VisitorTypePrqst _visitorType)
        {
            Result result = new Result();
            var spOption = 1;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@SpOption", spOption)
                      .AddParam("@VisitorType_Name", _visitorType.VisitorType_Name)
                      .AddParam("@VisitorType_Bagde_Color", _visitorType.VisitorType_Bagde_Color)
                      .AddParam("@VisitorType_Badge_Number", _visitorType.VisitorType_Bagde_Number)
                      .AddParam("@Base_Id", _visitorType.Base_Id)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[VisitorTypesProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }

            return result;
        }

        public static List<VisitorType> GetVisitorTypes()
        {
            List<VisitorType> lstVisitorTypes = null;
            var spOption = 3;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SpOption", spOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[VisitorTypesProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstVisitorTypes = new List<VisitorType>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstVisitorTypes.Add(new VisitorType()
                            {
                                VisitorType_Id = Convert.ToInt32(item["VisitorType_Id"]),
                                VisitorType_Name = item["VisitorType_Name"].ToString(),
                                VisitorType_Bagde_Number = item["VisitorType_Badge_Number"].ToString(),
                                Base_Name = item["Base_Name"].ToString(),
                                VisitorType_Bagde_Color = item["VisitorType_Badge_Color"].ToString(),
                                VisitorType_Badge_Available = Convert.ToInt32(item["VisitorType_Badge_Available"]),
                                VisitorType_Badge_InUse = Convert.ToInt32(item["VisitorType_Badge_InUse"]),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return lstVisitorTypes;
        }

        public static VisitorType GetVisitorType(int id)
        {
            VisitorType _visitorType = new VisitorType();
            var spOption = 2;
            using (var bl = new Business())
            {
                DataTable dtHeader = bl.AddParam("@SpOption", spOption)
                                   .AddParam("@VisitorType_Id", id)
                                   .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[VisitorTypesProcedures]");

                if (dtHeader.Rows.Count > 0)
                {
                    _visitorType.VisitorType_Id = Convert.ToInt32(dtHeader.Rows[0]["VisitorType_Id"]);
                    _visitorType.Base_Id = Convert.ToInt32(dtHeader.Rows[0]["Base_Id"]);
                    _visitorType.Base_Name = dtHeader.Rows[0]["Base_Name"].ToString();
                    _visitorType.VisitorType_Name = dtHeader.Rows[0]["VisitorType_Name"].ToString();
                    _visitorType.VisitorType_Bagde_Number = dtHeader.Rows[0]["VisitorType_Badge_Number"].ToString();
                    _visitorType.VisitorType_Bagde_Color = dtHeader.Rows[0]["VisitorType_Badge_Color"].ToString();
                }
            }
            return _visitorType;
        }

        public static Result UpdateVisitorType(VisitorType _visitorType)
        {
            Result result = new Result();
            var spOption = 4;
            using (var bl = new Business())
            {
                try
                {
                    bl.AddParam("@SpOption", spOption)
                      .AddParam("@VisitorType_Id", _visitorType.VisitorType_Id)
                      .AddParam("@Base_Id", _visitorType.Base_Id)
                      .AddParam("@VisitorType_Name", _visitorType.VisitorType_Name)
                      .AddParam("@VisitorType_Badge_Number", _visitorType.VisitorType_Bagde_Number)
                      .AddParam("@VisitorType_Bagde_Color", _visitorType.VisitorType_Bagde_Color)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[VisitorTypesProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }


        #endregion

        #region VisitorsReport
        public static Result StoreVisitorsReport(VisitorsReport _visitorsReport)
        {
            Result result = new Result();
            var spOption = 1;
            using (var bl = new Business())
            {
                try
                {

                    bl.AddParam("@SpOption",spOption)
                      .AddParam("@VisitorsReport_Name", _visitorsReport.VisitorsReport_Name)//
                      .AddParam("@VisitorsReport_LastName", _visitorsReport.VisitorsReport_LastName)//
                      .AddParam("@VisitorsReport_Subject", _visitorsReport.VisitorsReport_Subject)//
                      .AddParam("@VisitorsReport_RecievedBy", _visitorsReport.VisitorsReport_RecievedBy)//
                      .AddParam("@VisitorsReport_Photo", _visitorsReport.VisitorsReport_Photo)//
                      .AddParam("@VisitorsReport_Laptop", _visitorsReport.VisitorsReport_Laptop)//
                      .AddParam("@VisitorsReport_Laptop_Brand", _visitorsReport.VisitorsReport_Laptop_Brand)
                      .AddParam("@VisitorsReport_Laptop_Serial_Number", _visitorsReport.VisitorsReport_Laptop_Serial_Number)
                      .AddParam("@Company_Id", _visitorsReport.Company_Id)//
                      .AddParam("@IDType_Id", _visitorsReport.IDType_Id)//
                      .AddParam("@VisitorType_Id", _visitorsReport.VisitorType_Id)//
                      .AddParam("@User_Id", _visitorsReport.User_Id)//
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[VisitorsReportProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }

            return result;
        }


        public static List<VisitorsReport> GetVisitorsReports()
        {
            List<VisitorsReport> lstVisitorsReport = null;
            var spOption = 3;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SpOption",spOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[VisitorsReportProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        lstVisitorsReport = new List<VisitorsReport>();
                        foreach (DataRow item in dt.Rows)
                        {
                            lstVisitorsReport.Add(new VisitorsReport()
                            {
                                VisitorsReport_Id = Convert.ToInt32(item["VisitorsReport_Id"]),
                                Company_Id = Convert.ToInt32(item["Company_Id"]),
                                IDType_Id = Convert.ToInt32(item["IDType_Id"]),
                                VisitorType_Id = Convert.ToInt32(item["VisitorType_Id"]),
                                User_Id = Convert.ToInt32(item["User_Id"]),
                                Base_Id = Convert.ToInt32(item["Base_Id"]),
                                Company_Name = item["Company_Name"].ToString(),
                                IDType_Name = item["IDType_Name"].ToString(),
                                VisitorType_Name = item["VisitorType_Name"].ToString(),
                                User_UserName = item["User_Name"].ToString(),
                                Base_Name = item["Base_Name"].ToString(),
                                VisitorsReport_Badge_Number = item["VisitorsReport_Badge_Number"].ToString(),
                                VisitorsReport_Name = item["VisitorsReport_FullName"].ToString(),
                                VisitorsReport_RecievedBy = item["VisitorsReport_RecievedBy"].ToString(),
                                VisitorsReport_Subject = item["VisitorsReport_Subject"].ToString(),
                                VisitorsReport_Photo = item["VisitorsReport_Photo"].ToString(),
                                VisitorsReport_Laptop_Status = Convert.ToBoolean(item["VisitorsReport_Laptop"]),
                                LaptopRegistered = item["LaptopRegistered"].ToString(),
                                VisitorsReport_StartHour = Convert.ToDateTime(item["VisitorsReport_StartHour"]),
                                VisitorsReport_Status = Convert.ToBoolean(item["VisitorsReport_Status"]),
                               
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return lstVisitorsReport;
        }


        public static VisitorsReport GetVisitorsReport(int id)
        {
            VisitorsReport _visitorsReport = new VisitorsReport();
            var spOption = 2;
            using (var bl = new Business())
            {
                DataTable dtHeader = bl.AddParam("SpOption", spOption)
                                   .AddParam("@VisitorsReport_Id", id)
                                   .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Visit].[VisitorsReportProcedures]");

                if (dtHeader.Rows.Count > 0)
                {
                    _visitorsReport.VisitorsReport_Id = Convert.ToInt32(dtHeader.Rows[0]["VisitorsReport_Id"]);
                    _visitorsReport.Company_Id = Convert.ToInt32(dtHeader.Rows[0]["Company_Id"]);
                    _visitorsReport.Base_Id = Convert.ToInt32(dtHeader.Rows[0]["Base_Id"]);
                    _visitorsReport.IDType_Id = Convert.ToInt32(dtHeader.Rows[0]["IDType_Id"]);
                    _visitorsReport.User_Id = Convert.ToInt32(dtHeader.Rows[0]["User_Id"]);
                    _visitorsReport.VisitorType_Id = Convert.ToInt32(dtHeader.Rows[0]["VisitorType_Id"]);
                    _visitorsReport.Company_Name = dtHeader.Rows[0]["Company_Name"].ToString();
                    _visitorsReport.IDType_Name = dtHeader.Rows[0]["IDType_Name"].ToString();
                    _visitorsReport.VisitorType_Name = dtHeader.Rows[0]["VisitorType_Name"].ToString();
                    _visitorsReport.User_UserName = dtHeader.Rows[0]["User_Name"].ToString();
                    _visitorsReport.Base_Name = dtHeader.Rows[0]["Base_Name"].ToString();
                    _visitorsReport.VisitorsReport_Name = dtHeader.Rows[0]["VisitorsReport_FullName"].ToString();
                    _visitorsReport.VisitorsReport_RecievedBy = dtHeader.Rows[0]["VisitorsReport_RecievedBy"].ToString();
                    _visitorsReport.VisitorsReport_Subject = dtHeader.Rows[0]["VisitorsReport_Subject"].ToString();
                    _visitorsReport.VisitorsReport_Photo = dtHeader.Rows[0]["VisitorsReport_Photo"].ToString();
                    _visitorsReport.VisitorsReport_Laptop_Status = Convert.ToBoolean(dtHeader.Rows[0]["VisitorsReport_Laptop"]);
                    _visitorsReport.LaptopRegistered = dtHeader.Rows[0]["LaptopRegistered"].ToString();
                    _visitorsReport.VisitorsReport_Status = Convert.ToBoolean(dtHeader.Rows[0]["VisitorsReport_Status"]);
                    _visitorsReport.VisitorsReport_StartHour = Convert.ToDateTime(dtHeader.Rows[0]["VisitorsReport_StartHour"]);
                    _visitorsReport.VisitorsReport_Badge_Number = dtHeader.Rows[0]["VisitorsReport_Badge_Number"].ToString();
                }
            }
            return _visitorsReport;
        }


        public static Result UpdateVisitorsReport_Status(int id)
        {
            Result result = new Result();
            var spOption = 4;
            using (var bl = new Business())
            {
                try
                {

                    bl
                      .AddParam("@SpOption",spOption)
                      .AddParam("@VisitorsReport_Id", id)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Visit].[VisitorsReportProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }
                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }


        #endregion

        #region Methods
        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        #endregion
    }
}
