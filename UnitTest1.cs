using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPM1;
using System.Collections.Generic;
using System;

namespace EPMTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DateTime d1= DateTime.Now;
            EPM1.EPM1 obj = new EPM1.EPM1();
            List<Employee> emp = new List<Employee>();
            emp.Add(new Employee { employeename="Joe",employeephonenumber="256314789",employeeaddress="Jagdambanagar",employeedepartment="Placement", employeegender ="M", basicpay = 40000, deduction = 500, taxablepay = 200,tax = 200,netpay = 300,date = "2020/06/01", city = "Rajwada",country = "India"});
            foreach(Employee employee in emp)
            {
                obj.AddAndDisplayEmployee(employee);
            }
            DateTime d2= DateTime.Now;
        }
    }
}
