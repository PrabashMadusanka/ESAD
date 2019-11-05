using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Inquirymgt
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        IEnumerable<Inquiry> GetInquires();

        [OperationContract]
        IEnumerable<Inquiry> GetInquiresBystaffmember(string assignedEmpNo);

        [OperationContract]
        string AddInquires(AddInquiryRequest newinquiry);

        [OperationContract]
        string RespondToInquires(string resp,int InquiryID);

        [OperationContract]
        string DeleteInquire(int InquiryID);

    }


   
}
