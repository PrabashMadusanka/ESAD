using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Inquirymgt
{
    [DataContract]
    public class AddInquiryRequest
    {

        /// <summary>
        /// InquiryDes
        /// </summary>
        [DataMember(IsRequired = true)]
        public string InquiryDes { get; set; }
        
        /// <summary>
        /// AssignedEmpNo
        /// </summary>
        [DataMember(IsRequired = true)]
        public string AssignedEmpNo { get; set; }

        /// <summary>
        /// MemberId
        /// </summary>
        [DataMember(IsRequired = true)]
        public string MemberId { get; set; }

        /// <summary>
        /// Isdeleted
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool Isdeleted { get; set; }

        /// <summary>
        /// IsActive
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool IsActive { get; set; }

        /// <summary>
        /// LogInfo
        /// </summary>
        [DataMember]
        public string LogInfo { get; set; }

        /// <summary>
        /// LastModifiedDateTime
        /// </summary> 
        public DateTime LastModifiedDateTime { get; set; }
    }
}