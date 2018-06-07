using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mail.Model
{
    /// <summary>
    /// author koje
    /// 邮件的类型
    /// </summary>
    public class T_Base_Mail_Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Overtime { get; set; }  //  代表超时的日期
    }
    /// <summary>
    /// 邮件
    /// </summary>
    public class T_Base_Mail
    {
        public int Id { get; set; }
        public DateTime EnteringTime { get; set; }
        public bool IsReturn { get; set; }
        public bool IsRecieved { get; set; }
        public int TypeId { get; set; }
        public string RecipientId { get; set; }
    }
    
    /// <summary>
    /// 收件人信息
    /// </summary>
    public class T_Base_Recipient
    {
        public string Id { get; set; }
        public string PhoneNum { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string Dept { get; set; }
    }
}
