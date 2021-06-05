using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace IMS.Utilities
{
    public class DbUtility
    {
        static string cs = ConfigurationManager.ConnectionStrings["DBIMS"].ConnectionString;

        public static SqlConnection conn = new SqlConnection(cs);


        public static DataSet GetData(SqlCommand cmd, CommandType type = CommandType.Text)
        {
            using (conn = new SqlConnection(cs))
            {
                cmd.Connection = conn;
                cmd.CommandType = type;
                DataSet ds = new DataSet();
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
        }

        public static DataTable GetDataTable(SqlCommand cmd, CommandType type = CommandType.Text)
        {
            using (conn = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                cmd.Connection = conn;
                cmd.CommandType = type;
                DataTable dt = new DataTable();
                conn.Open();
                da.Fill(ds);
                if (ds != null && ds.Tables[0] != null)
                {
                    dt = ds.Tables[0];
                }
                return dt;
            }

        }

        public static string ExecuteScalarGetItem(string commandText)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = commandText;
            using (conn = new SqlConnection(cs))
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                conn.Open();
                return cmd.ExecuteScalar().ToString();
            }
        }



        public static Boolean ExecuteScalarGetBoolean(SqlCommand cmd, CommandType type = CommandType.Text)
        {
            using (conn = new SqlConnection(cs))
            {
                cmd.Connection = conn;
                cmd.CommandType = type;
                conn.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }

        public static void ExecuteNonQuery(SqlCommand cmd, CommandType type = CommandType.Text)
        {
            using (conn = new SqlConnection(cs))
            {
                cmd.Connection = conn;
                cmd.CommandType = type;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static SqlDataReader ExecuteReader(SqlCommand cmd, CommandType type = CommandType.Text)
        {
            conn = new SqlConnection(cs);
            cmd.Connection = conn;
            cmd.CommandType = type;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public static DataSet ExecuteReaderDataset(SqlCommand cmd, CommandType type = CommandType.Text)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            using (conn = new SqlConnection(cs))
            {
                cmd.Connection = conn;
                cmd.CommandType = type;
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) { da.Fill(ds); }
                }
                return ds;
            }
        }

        public static int ExecuteNonQuery1(SqlCommand cmd, CommandType type = CommandType.Text)
        {
            int i = 0;
            using (conn = new SqlConnection(cs))
            {

                cmd.Connection = conn;
                cmd.CommandType = type;
                conn.Open();
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        public static Int32 ExecuteScalarGetInt32(SqlCommand cmd, CommandType type = CommandType.Text)
        {
            using (conn = new SqlConnection(cs))
            {
                cmd.Connection = conn;
                cmd.CommandType = type;
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                    return Convert.ToInt32(cmd.ExecuteScalar());
                else
                    return 0;
            }
        }

        public static Int64 ExecuteScalarGetInt64(SqlCommand cmd, CommandType type = CommandType.Text)
        {
            using (conn = new SqlConnection(cs))
            {
                cmd.Connection = conn;
                cmd.CommandType = type;
                conn.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                    return Convert.ToInt64(cmd.ExecuteScalar());
                else
                    return 0;
            }

        }
    }
}