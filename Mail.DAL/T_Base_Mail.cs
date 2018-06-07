using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Mail.DAL
{
    /// <summary>
    /// 邮件
    /// </summary>
    public class T_Base_Mail
    {
        public string connstring = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113Mail";
        public int Add(Mail.Model.T_Base_Mail item)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "Insert into T_Base_Mail(enteringTime,isReturn,isReceived,typeId,RecipientId) values (@enteringTime,@isReturn,@isReceived,@typeId,@RecipientId)";
            cm.Parameters.AddWithValue("@enteringTime", item.EnteringTime);
            cm.Parameters.AddWithValue("@isReturn", item.IsReturn);
            cm.Parameters.AddWithValue("@isReceived", item.IsRecieved);
            cm.Parameters.AddWithValue("@typeId", item.TypeId);
            cm.Parameters.AddWithValue("@RecipientId", item.RecipientId);
            int result = cm.ExecuteNonQuery();
            
            co.Close();
            return result;
        }
        
        public int Update(Mail.Model.T_Base_Mail item)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "update T_Base_Mail set enteringTime=@enteringTime,isReturn=@isReturn,isReceived@isReceived,@typeId,@RecipientId where Id=@Id";
            cm.Parameters.AddWithValue("@enteringTime", item.EnteringTime);
            cm.Parameters.AddWithValue("@isReturn", item.IsReturn);
            cm.Parameters.AddWithValue("@isReceived", item.IsRecieved);
            cm.Parameters.AddWithValue("@typeId", item.TypeId);
            cm.Parameters.AddWithValue("@RecipientId", item.RecipientId);
            cm.Parameters.AddWithValue("@Id", item.Id);
            int result = cm.ExecuteNonQuery();
            co.Close();
            return result;
        }

        public int GetCount()
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select count(1) from T_Base_Mail";
            cm.Connection = co;
            object result = cm.ExecuteScalar();
            co.Close();
            return (int)result;
        }

        public List<Model.T_Base_Mail> GetList(int currentPage, int pageSize)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();

            cm.Connection = co;
            cm.CommandText = "select top " + pageSize + " * from T_Base_Mail where Id not in (select top " + pageSize * (currentPage - 1) + " Id from T_Base_Mail)";
            SqlDataReader dr = cm.ExecuteReader();
            List<Mail.Model.T_Base_Mail> lst = new List<Model.T_Base_Mail>();
            while (dr.Read())
            {
                Mail.Model.T_Base_Mail item = new Model.T_Base_Mail();
                item.Id = Convert.ToInt32(dr["Id"]);
                item.EnteringTime = Convert.ToDateTime(dr["enteringTime"]);
                item.IsReturn = Convert.ToBoolean(dr["isReturn"]);
                item.IsRecieved = Convert.ToBoolean(dr["isReceived"]);
                item.TypeId = Convert.ToInt32(dr["typeId"]);
                item.RecipientId = Convert.ToString(dr["RecipientId"]);
                lst.Add(item);
            }
            dr.Close();
            co.Close();
            return lst;
        }

        public List<Model.T_Base_Mail> GetOutList()
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();

            cm.Connection = co;
            cm.CommandText = "select T_Base_Mail.Id from T_Base_Mail,T_Base_Mail_Type where T_Base_Mail.typeId = T_Base_Mail_Type.Id AND DATEADD(DD,Overtime,enteringTime) <　GETDATE();";
            SqlDataReader dr = cm.ExecuteReader();
            List<Mail.Model.T_Base_Mail> lst = new List<Model.T_Base_Mail>();
            while (dr.Read())
            {
                Mail.Model.T_Base_Mail item = new Model.T_Base_Mail();
                item.Id = Convert.ToInt32(dr["Id"]);
                lst.Add(item);
            }
            dr.Close();
            co.Close();
            return lst;
        }

    }
}
