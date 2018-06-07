using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mail.BLL
{
    public class T_Base_Mail
    {
        public Mail.DAL.T_Base_Mail dal = new Mail.DAL.T_Base_Mail();
        public List<Mail.Model.T_Base_Mail> GetList(int CurrentPage, int PageSize)
        {
            return dal.GetList(CurrentPage, PageSize);
        }
    }
}
