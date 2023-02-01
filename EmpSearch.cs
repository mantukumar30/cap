using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SpDemo
{
    internal class EmpSearch
    {
        static void Main()
        {
            int empno;
            Console.WriteLine("Enter Employ Number   ");
            empno = Convert.ToInt32(Console.ReadLine());
            string strcon = ConfigurationManager.ConnectionStrings["sqlpracticeconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("prcEmpSearch", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empno", empno);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Console.WriteLine("Employ No   " + dr["empno"]);
                Console.WriteLine("Employ Name  " + dr["nam"]);
                Console.WriteLine("Department   " + dr["dept"]);
                Console.WriteLine("Designation  " + dr["desig"]);
                Console.WriteLine("Basic   " + dr["basic"]);
            }
            else
            {
                Console.WriteLine("*** Record Not Found ***");
            }
        }
    }
}
