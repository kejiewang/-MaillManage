using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Mail.DAL
{

    /// <summary>
    /// kojewang
    /// 邮件的类型管理
    /// </summary>
    class T_Base_Mail_Type
    {
        public string connstring = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113Mail";
        public int Add(Mail.Model.T_Base_Mail_Type item)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "Insert into T_Base_Mail_Type(typeName,Overtime) values (@typeName,@Overtime)";
            cm.Parameters.AddWithValue("@typeName", item.Name);
            cm.Parameters.AddWithValue("@Overtime", item.Overtime);
            int result = cm.ExecuteNonQuery();
            co.Close();
            return result;
        }

        public int Update(Mail.Model.T_Base_Mail_Type item)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "update T_Base_Mail_Type set typeName=@typeName,Overtime=@Overtime where Id=@Id";
            cm.Parameters.AddWithValue("@typeName", item.Name);
            cm.Parameters.AddWithValue("@Overtime", item.Overtime);
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
            cm.CommandText = "select count(1) from T_Base_Mail_Type";
            cm.Connection = co;
            object result = cm.ExecuteScalar();
            co.Close();
            return (int)result;
        }

        public List<Model.T_Base_Mail_Type> GetList(int currentPage, int pageSize)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();

            cm.Connection = co;
            cm.CommandText = "select top " + pageSize + " * from T_Base_Mail_Type where Id not in (select top " + pageSize * (currentPage - 1) + " Id from T_Base_Mail_Type)";
            SqlDataReader dr = cm.ExecuteReader();
            List<Mail.Model.T_Base_Mail_Type> lst = new List<Model.T_Base_Mail_Type>();
            while (dr.Read())
            {
                Mail.Model.T_Base_Mail_Type item = new Model.T_Base_Mail_Type();
                item.Id = Convert.ToInt32(dr["Id"]);
                item.Name = Convert.ToString(dr["typeName"]);
                item.Overtime = Convert.ToInt32(dr["Overtime"]);
                lst.Add(item);
            }
            dr.Close();
            co.Close();
            return lst;
        }

    }
}
