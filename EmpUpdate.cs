using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace AdoExample1
{
    class EmpUpdate
    {
        static void Main()
        {
            int empno, basic;
            string name, dept, desig;
            Console.WriteLine("Enter Employ Number  ");
            empno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employ Name   ");
            name = Console.ReadLine();
            Console.WriteLine("Enter Department   ");
            dept = Console.ReadLine();
            Console.WriteLine("Enter Designation  ");
            desig = Console.ReadLine();
            Console.WriteLine("Enter Basic   ");
            basic = Convert.ToInt32(Console.ReadLine());
            string strcon = ConfigurationManager.ConnectionStrings["sqlpracticeconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Emp where empno=@eno", conn);
            ad.SelectCommand.Parameters.AddWithValue("@eno", empno);
            SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
            DataSet ds = new DataSet();
            ad.Fill(ds, "EmpNew");
            int count = ds.Tables["EmpNew"].Rows.Count;
            if (count==1)
            {
                DataRow dr = ds.Tables["EmpNew"].Rows[0];
                dr["nam"] = name;
                dr["dept"] = dept;
                dr["desig"] = desig;
                dr["basic"] = basic;
                ad.Update(ds, "EmpNew");
                Console.WriteLine("*** Record Updated ***");
            }
        }
    }
}
