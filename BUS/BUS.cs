using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;
using System.Collections.ObjectModel;

namespace BUS
{
    public class BUS
    {
        public static List<SYS_MENU> GetMenuCha(int ID)
        {
            return DAL.DAL.DsMenuCha(ID);
        }
        public static ObservableCollection<SALARY> DsLuong()
        {

            return DAL.DAL.DsLuong();
        }
        public static ObservableCollection<EMPLOYEE> DsEmployee()
        {
            return DAL.DAL.DsEmployee();
        }

        public static void InsertEmployee(string EmpID, string FirstName, string LastName)
        {
            DAL.DAL.InsertEmployee(EmpID, FirstName, LastName);
        }
        public static void DeleteEmployee(string EmpID)
        {
            DAL.DAL.DeleteEmployee(EmpID);
        }
        public static void InsertSalary(string ID, string EmpID, int WorkDays)
        {
            DAL.DAL.InsertSalary(ID, EmpID, WorkDays);
        }
        public static void DeleteSalary(string ID)
        {
            DAL.DAL.DeleteSalary(ID);
        }
    }
}
