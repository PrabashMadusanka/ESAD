using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Inquirymgt
{
    [DataContract]
    public class Inquiry
    {
            /// <summary>
            /// InquiryID
            /// </summary>
            [DataMember]
            public int InquiryID { get; set; }
            /// <summary>
            /// InquiryDes
            /// </summary>
            [DataMember]
            public string InquiryDes { get; set; }
            /// <summary>
            /// InquiryResp
            /// </summary>
            [DataMember]
            public string InquiryResp { get; set; }

            /// <summary>
            /// AssignedEmpNo
            /// </summary>
            [DataMember]
            public string AssignedEmpNo { get; set; }

            /// <summary>
            /// MemberId
            /// </summary>
            [DataMember]
            public string MemberId { get; set; }

            /// <summary>
            /// Isdeleted
            /// </summary>
            [DataMember]
            public bool Isdeleted { get; set; }

            /// <summary>
            /// IsActive
            /// </summary>
            [DataMember]
            public bool IsActive { get; set; }

            /// <summary>
            /// LogInfo
            /// </summary>
            [DataMember]
            public string LogInfo { get; set; }


            /// <summary>
            /// LastModifiedDateTime
            /// </summary>
            [DataMember]
            public DateTime LastModifiedDateTime { get; set; }

    }
 }
