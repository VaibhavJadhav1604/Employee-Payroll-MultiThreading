using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;
using System.Data;

namespace EPM2
{
    public class Employee
    {
        public int employeeid { get; set; }
        public string employeename { get; set; }
        public string employeephonenumber { get; set; }
        public string employeeaddress { get; set; }
        public string employeedepartment { get; set; }
        public string employeegender { get; set; }
        public double basicpay { get; set; }
        public double deduction { get; set; }
        public double taxablepay { get; set; }
        public double tax { get; set; }
        public double netpay { get; set; }
        public string date { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }
    public class EPM2
    {
        public static string str = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Ado_Payroll_Service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection con = new SqlConnection(str);

        public void AddAndDisplayEmployee(Employee employee)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("AddEmployee", this.con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeName", employee.employeename);
            cmd.Parameters.AddWithValue("@PhoneNumber", employee.employeephonenumber);
            cmd.Parameters.AddWithValue("@Address", employee.employeeaddress);
            cmd.Parameters.AddWithValue("@Department", employee.employeedepartment);
            cmd.Parameters.AddWithValue("@Gender", employee.employeegender);
            cmd.Parameters.AddWithValue("@BasicPay", employee.basicpay);
            cmd.Parameters.AddWithValue("@Deduction", employee.deduction);
            cmd.Parameters.AddWithValue("@TaxablePay", employee.taxablepay);
            cmd.Parameters.AddWithValue("@Tax", employee.tax);
            cmd.Parameters.AddWithValue("@NetPay", employee.netpay);
            cmd.Parameters.AddWithValue("@StartDate", employee.date);
            cmd.Parameters.AddWithValue("@City", employee.city);
            cmd.Parameters.AddWithValue("@Country", employee.country);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    employee.employeeid = reader.GetInt32(0);
                    employee.employeename = reader.GetString(1);
                    employee.employeephonenumber = reader.GetString(2);
                    employee.employeeaddress = reader.GetString(3);
                    employee.employeedepartment = reader.GetString(4);
                    employee.employeegender = reader.GetString(5);
                    employee.basicpay = reader.GetDouble(6);
                    employee.deduction = reader.GetDouble(7);
                    employee.taxablepay = reader.GetDouble(8);
                    employee.tax = reader.GetDouble(9);
                    employee.netpay = reader.GetDouble(10);
                    employee.date = reader.GetString(11);
                    employee.city = reader.GetString(12);
                    employee.country = reader.GetString(13);

                    Console.WriteLine("EmployeeId:" + employee.employeeid);
                    Console.WriteLine("EmployeeName:" + employee.employeename);
                    Console.WriteLine("PhoneNumber:" + employee.employeephonenumber);
                    Console.WriteLine("Address:" + employee.employeeaddress);
                    Console.WriteLine("Department:" + employee.employeedepartment);
                    Console.WriteLine("Gender:" + employee.employeegender);
                    Console.WriteLine("BasicPay:" + employee.basicpay);
                    Console.WriteLine("Deduction:" + employee.deduction);
                    Console.WriteLine("TaxablePay:" + employee.taxablepay);
                    Console.WriteLine("Tax:" + employee.tax);
                    Console.WriteLine("NetPay:" + employee.netpay);
                    Console.WriteLine("Date:" + employee.date);
                    Console.WriteLine("City:" + employee.city);
                    Console.WriteLine("Country:" + employee.country);
                    Console.WriteLine("\n");
                }
            }
        }

        public void AddEmployeeWithThread(List<Employee> employees)
        {
            employees.ForEach(employee =>
            {
                Task thread=new Task(() =>
                {
                    Console.WriteLine("EmployeeBeingAdded : " + employee.employeename);
                    AddAndDisplayEmployee(employee);
                    Console.WriteLine("Employee Added: " + employee.employeename);
                });
                thread.Start();
            });
        }
        static void Main(string[] args)
        {

        }
    }
}
