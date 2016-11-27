using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Collections.ObjectModel;

namespace DAL
{
    public class DAL
    {
        public List<EMPLOYEE> LstEmpByDept()
        {
            HRM db = new HRM();
            var LstDept = db.DEPARTMENTs.Select(m => m.DeptID).ToList();
            List<EMPLOYEE> lstEmpDept = new List<EMPLOYEE>();
            foreach (var item in LstDept)
            {
                var ds = db.EMPLOYEEs.SingleOrDefault(m => m.DeptID == item);
                lstEmpDept.Add(ds);
            }

            return lstEmpDept;
        }
        public List<EMPLOYEE> LstEmpByGroup()
        {
            HRM db = new HRM();
            var LstGroup = db.GROUPs.Select(m => m.GroupID).ToList();
            List<EMPLOYEE> lstEmpDept = new List<EMPLOYEE>();
            foreach (var item in LstGroup)
            {
                var ds = db.EMPLOYEEs.SingleOrDefault(m => m.GroupID == item);
                lstEmpDept.Add(ds);
            }

            return lstEmpDept;
        }
        public List<EMPLOYEE> LstEmpByRoom()
        {
            HRM db = new HRM();
            var LstRoom = db.ROOMs.Select(m => m.RoomID).ToList();
            List<EMPLOYEE> lstEmpDept = new List<EMPLOYEE>();
            foreach (var item in LstRoom)
            {
                var ds = db.EMPLOYEEs.SingleOrDefault(m => m.RoomID == item);
                lstEmpDept.Add(ds);
            }

            return lstEmpDept;
        }
        public static List<SYS_MENU> DsMenuCha(int ID)
        {
            HRM db = new HRM();
            List<SYS_MENU> ds = db.SYS_MENU.Where(m => m.ParentID == ID).ToList();
            return ds;
        }

        public static ObservableCollection<SALARY> DsLuong()
        {
            HRM db = new HRM();
            ObservableCollection<SALARY> lstSalary = new ObservableCollection<SALARY>();
            foreach (var item in db.SALARies)
            {
                lstSalary.Add(item);
            }
            return lstSalary;
        }
        public static ObservableCollection<EMPLOYEE> DsEmployee()
        {
            HRM db = new HRM();
            ObservableCollection<EMPLOYEE> lstEmp = new ObservableCollection<EMPLOYEE>();
            foreach (var item in db.EMPLOYEEs)
            {
                lstEmp.Add(item);
            }       
            return lstEmp;
        }

        public static void InsertEmployee(string EmpID,string FirstName , string LastName)
        {
            HRM db = new HRM();
            var Item = db.EMPLOYEEs.SingleOrDefault(m => m.EmployeeID == EmpID);
            if(Item == null)
            {
                EMPLOYEE emp = new EMPLOYEE();
                emp.EmployeeID = EmpID;
                emp.FirstName = FirstName;
                emp.LastName = LastName;
                db.EMPLOYEEs.Add(emp);
            }
            else
            {
                EMPLOYEE emp = db.EMPLOYEEs.SingleOrDefault(m => m.EmployeeID == EmpID);
                emp.EmployeeID = EmpID;
                emp.FirstName = FirstName;
                emp.LastName = LastName;
                db.SaveChanges();
            }
            db.SaveChanges();
        }
        public static void DeleteEmployee(string EmpID)
        {
            HRM db = new HRM();
            var Item = db.EMPLOYEEs.SingleOrDefault(m => m.EmployeeID == EmpID);
            if(Item != null)
            {
                db.EMPLOYEEs.Remove(Item);
                db.SaveChanges();
            }
        }

        public static void InsertSalary(string ID, string EmpID, int Workdays)
        {
            HRM db = new HRM();
            var Item = db.SALARies.SingleOrDefault(m => m.ID == ID);
            if (Item == null)
            {
                SALARY sal = new SALARY();
                sal.ID = ID;
                sal.EmployeeID = EmpID;
                sal.WorkDays = Workdays;
                db.SALARies.Add(sal);
            }
            else
            {
                SALARY sal = db.SALARies.SingleOrDefault(m => m.ID == ID);
                sal.ID = ID;
                sal.EmployeeID = EmpID;
                sal.WorkDays = Workdays;
                db.SaveChanges();
            }
            db.SaveChanges();
        }
        public static void DeleteSalary(string ID)
        {
            HRM db = new HRM();
            var Item = db.SALARies.SingleOrDefault(m => m.ID == ID);
            if (Item != null)
            {
                db.SALARies.Remove(Item);
                db.SaveChanges();
            }
        }

    }
}
