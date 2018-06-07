using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mail.BLL
{
    public class T_Base_Recipient
    {
        public Mail.DAL.T_Base_Recipient dal = new Mail.DAL.T_Base_Recipient();
        public List<Mail.Model.T_Base_Recipient> GetList(int CurrentPage, int PageSize)
        {
            return dal.GetList(CurrentPage, PageSize);
        }
    }
}
