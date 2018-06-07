using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mail.BLL
{
    public class T_Base_Mail_Type
    {
        public Mail.DAL.T_Base_Mail_Type dal = new Mail.DAL.T_Base_Mail_Type();
        public List<Mail.Model.T_Base_Mail_Type> GetList(int CurrentPage, int PageSize)
        {
            return dal.GetList(CurrentPage, PageSize);
        }
    }
}
