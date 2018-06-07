using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Mail.DAL
{
    public class T_Base_Recipient
    {
        public string connstring = "server=10.132.239.3;uid=sa;pwd=Jsj123456;database=15211160113Mail";
        /// <summary>
        /// 收件人信息增加
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Add(Mail.Model.T_Base_Recipient item)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "Insert into T_Base_Recipient(Id, phoneNum, Name, Job, Dept) values (@Id,@phoneNum,@Name,@Job,@Dept)";
            cm.Parameters.AddWithValue("@Id", item.Id);
            cm.Parameters.AddWithValue("@phoneNum", item.PhoneNum);
            cm.Parameters.AddWithValue("@Name", item.Name);
            cm.Parameters.AddWithValue("@Job", item.Job);
            cm.Parameters.AddWithValue("@Dept", item.Dept);
            int result = cm.ExecuteNonQuery();
            co.Close();
            return result;
        }

        public int Update(Mail.Model.T_Base_Recipient item)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "update T_Base_Recipient set Id=@Id,phoneNum=@phoneNum,Name=@Name,Job=@Job,Dept=@Dept where Id=@Id";
            cm.Parameters.AddWithValue("@Id", item.Id);
            cm.Parameters.AddWithValue("@phoneNum", item.PhoneNum);
            cm.Parameters.AddWithValue("@Name", item.Name);
            cm.Parameters.AddWithValue("@Job", item.Job);
            cm.Parameters.AddWithValue("@Dept", item.Dept);
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
            cm.CommandText = "select count(1) from T_Base_Recipient";
            cm.Connection = co;
            object result = cm.ExecuteScalar();
            co.Close();
            return (int)result;
        }

        public List<Model.T_Base_Recipient> GetList(int currentPage, int pageSize)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = connstring;
            co.Open();
            SqlCommand cm = new SqlCommand();

            cm.Connection = co;
            cm.CommandText = "select top " + pageSize + " * from T_Base_Recipient where Id not in (select top " + pageSize * (currentPage - 1) + " Id from T_Base_Recipient)";
            SqlDataReader dr = cm.ExecuteReader();
            List<Mail.Model.T_Base_Recipient> lst = new List<Model.T_Base_Recipient>();
            while (dr.Read())
            {
                Mail.Model.T_Base_Recipient item = new Model.T_Base_Recipient();
                item.Id = Convert.ToString(dr["Id"]);
                item.PhoneNum = Convert.ToString(dr["phoneNum"]);
                item.Name = Convert.ToString(dr["Name"]);
                item.Job = Convert.ToString(dr["Job"]);
                item.Dept = Convert.ToString(dr["Dept"]);
                lst.Add(item);
            }
            dr.Close();
            co.Close();
            return lst;
        }
    
    }
}
