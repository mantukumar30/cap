using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;

namespace AdoExample1
{
    class EmploySearch
    {
        static void Main()
        {
            int empno;
            Console.WriteLine("Enter Employ Number   ");
            empno = Convert.ToInt32(Console.ReadLine());
            string strcon = ConfigurationManager.ConnectionStrings["sqlpracticeconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Emp where empno=@eno", conn);
            ad.SelectCommand.Parameters.AddWithValue("@eno", empno);
            DataSet ds = new DataSet();
            ad.Fill(ds, "EmpNew");
            int count = ds.Tables["EmpNew"].Rows.Count;
            if (count==1)
            {
                DataRow dr = ds.Tables["EmpNew"].Rows[0];
                Console.WriteLine("Employ No  " + dr["empno"]);
                Console.WriteLine("Employ Name  " + dr["nam"]);
                Console.WriteLine("Department  " + dr["dept"]);
                Console.WriteLine("Designation " + dr["desig"]);
                Console.WriteLine("Basic   " + dr["basic"]);
                Console.WriteLine("------------------------------");
            }
        }
    }
}
