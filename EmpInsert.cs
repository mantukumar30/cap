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
    class EmpInsert
    {
        static void Main()
        {
            try
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
                SqlDataAdapter ad = new SqlDataAdapter("select * from Emp", conn);
                DataSet ds = new DataSet();
                SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                ad.Fill(ds, "EmpNew");
                DataRow dr = ds.Tables["EmpNew"].NewRow();
                dr["empno"] = empno;
                dr["nam"] = name;
                dr["dept"] = dept;
                dr["desig"] = desig;
                dr["basic"] = basic;
                ds.Tables["EmpNew"].Rows.Add(dr);
                ad.Update(ds, "EmpNew");
                Console.WriteLine("*** Record Inserted ***");
            } catch (SqlException e)
            {
                Console.WriteLine("EmployNo Primary Key already exists...");
            }
        }
    }
}
