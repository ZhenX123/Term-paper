using System.Data.SqlClient;

namespace Housesell
{
    class Dao
    {
        SqlConnection sc = new SqlConnection();
        public SqlConnection connect()
        {
            string str = @"Data Source=CAN-HEAR-ME;Database=Housedata;Integrated Security=True";//数据库连接字符串Database connection string
            SqlConnection sc = new SqlConnection(str);//创建数据库连接对象Create a database connection object
            sc.Open();//打开数据库Open the database
            return sc;
        }
        public SqlCommand command(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, connect());
            return cmd;

        }
        public int Execute(string sql)//更新操作update operation
        {
            return command(sql).ExecuteNonQuery();
        }
       public SqlDataReader read(string sql)//读取操作Read operation
        {
        return command(sql).ExecuteReader(); 
    }
        public void DaoClose()
        {
            sc.Close();//关闭数据连接Closing data Connections
        }
        }

    }

