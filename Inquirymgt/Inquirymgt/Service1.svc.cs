using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace Inquirymgt
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private readonly MySqlConnection _conn;
        private string _connectionString = ConfigurationManager.ConnectionStrings["mysqlConnection"].ConnectionString;
        //private string _connectionString = "Server=mysql5022.site4now.net;Database=db_a4fb29_inquiry;Uid=a4fb29_inquiry;Pwd=sliitESAD123;";
        public Service1()
        {

            _conn = new MySqlConnection(_connectionString);
        }
        

        public IEnumerable<Inquiry> GetInquires()
        {
            
                var sql = "SELECT * FROM Inquiry where Isdeleted=0";
                var result = this._conn.Query<Inquiry>(sql).ToList();
                return result;
           
        }

        public string AddInquires(AddInquiryRequest newinquiry)
        {
            string msg;
            try
            {
                newinquiry.LastModifiedDateTime = DateTime.Now;
                var sql = "INSERT INTO Inquiry (InquiryDes,AssignedEmpNo,MemberId,Isdeleted,IsActive,LogInfo,LastModifiedDateTime)"
                            + "VALUES(@InquiryDes, @AssignedEmpNo, @MemberId, @Isdeleted, @IsActive, @LogInfo,@LastModifiedDateTime); ";
                int result = this._conn.Execute(sql, newinquiry);
                if(result>0)
                {
                    msg = "Sucssefuly added";
                }
                else
                {
                    msg = "Failed to add";
                }
            }
            catch(Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        public string RespondToInquires(string resp, int InquiryID)
        {
            string msg;
            try
            {
                var sql = "UPDATE Inquiry SET InquiryResp=@InquiryResp, LastModifiedDateTime=@LastModifiedDateTime WHERE InquiryID=@InquiryID";
                int result = this._conn.Execute(sql, new { InquiryResp = resp, InquiryID = InquiryID, LastModifiedDateTime = DateTime.Now });
                if (result > 0)
                {
                    msg = "Sucssefuly added";
                }
                else
                {
                    msg = "Failed to add";
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        public IEnumerable<Inquiry> GetInquiresBystaffmember(string assignedEmpNo)
        {
            var sql = "SELECT * FROM Inquiry where AssignedEmpNo=@AssignedEmpNo and Isdeleted=0";
            var result = this._conn.Query<Inquiry>(sql,new { AssignedEmpNo= assignedEmpNo}).ToList();
            return result;
        }

        public string DeleteInquire(int InquiryID)
        {
            string msg;
            try
            {
                var sql = "UPDATE Inquiry SET Isdeleted=@Isdeleted WHERE InquiryID=@InquiryID";
                var result = this._conn.Execute(sql, new { Isdeleted = 1, InquiryID = InquiryID });

                if (result > 0)
                {
                    msg = "Sucssefuly removed";
                }
                else
                {
                    msg = "Failed to removed";
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;


        }
    }

   
}
