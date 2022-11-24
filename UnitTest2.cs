using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPM2;
using System.Collections.Generic;
using System;

namespace EPMTestProject
{
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod2()
        {
            DateTime d1 = DateTime.Now;
            EPM2.EPM2 obj = new EPM2.EPM2();
            List<Employee> emp = new List<Employee>();
            emp.Add(new Employee { employeename = "DeeDee", employeephonenumber = "145236987", employeeaddress = "SambhajiNagar", employeedepartment = "Security", employeegender = "F", basicpay = 35000, deduction = 500, taxablepay = 200, tax = 200, netpay = 300, date = "2020/04/13", city = "Kolhapur", country = "India" });
            emp.Add(new Employee { employeename = "Marky", employeephonenumber = "785412369", employeeaddress = "JijauChowk", employeedepartment = "HR", employeegender = "M", basicpay = 20000, deduction = 400, taxablepay = 100, tax = 100, netpay = 200, date = "2019/02/25", city = "Nashik", country = "India" });
            obj.AddEmployeeWithThread(emp);
            DateTime d2 = DateTime.Now;
        }
    }
}
