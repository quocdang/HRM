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
        public static ObservableCollection<DEPARTMENT> DsDept()
        {
            return DAL.DAL.GetListDepartmentItem();
        }
        public static ObservableCollection<POSITION> DsPos()
        {
            return DAL.DAL.GetListPositionItem();
        }
        public static ObservableCollection<ROOM> DsRoom()
        {
            return DAL.DAL.GetListRoomItem();
        }
        public static ObservableCollection<GROUP> DsGroup()
        {
            return DAL.DAL.GetListGroupItem();
        }
        public static ObservableCollection<DEPARTMENT> ListDepartMent()
        {
            return DAL.DAL.GetListDepartmentItem();
        }
        public static ObservableCollection<ALLOWANCE> ListAllowance()
        {
             return DAL.DAL.GetListAllowance();
        }
        public static ObservableCollection<DEDUCTION> ListDeduction()
        {
            return DAL.DAL.GetListDeduction(); 
        }
        public static ObservableCollection<HISTORY> ListHistory()
        {
            return DAL.DAL.GetListHistory(); 
        }
        public static ObservableCollection<TRAINNING> ListTrainning()
        {
            return DAL.DAL.GetListTrainning(); 
        }
        public static ObservableCollection<WORKING> ListWorking()
        {
            return DAL.DAL.GetListWorking(); 
        }
        public static ObservableCollection<CANDIDATE> ListCandicate()
        { 
            return DAL.DAL.GetListCandicate(); 
        }
        public static ObservableCollection<SALARY_ADVANCE> ListAdvance()
        {
            return DAL.DAL.GetListAdvance(); 
        }
        public static ObservableCollection<EMP_ALLOWANCE> ListEmpAllwance()
        {
            return DAL.DAL.GetListEmpAllwance(); 
        }
        public static ObservableCollection<EMP_DEDUCTED> ListEmpDeduct()
        {
            return DAL.DAL.GetListEmpDeduct(); 
        }
        public static ObservableCollection<REWARD> ListReward()
        {
            return DAL.DAL.GetListReward(); 
        }
        public static ObservableCollection<CONTRACT> ListContract()
        {
            return DAL.DAL.GetListContract(); 
        }
        public static ObservableCollection<DISCIPLINE> ListDiscipline()
        {
            return DAL.DAL.GetListDiscipline();
        }

        public static void InsertEmployee(EMPLOYEE emp)
        {
            DAL.DAL.InsertEmployee(emp);
        }
        public static void DeleteEmployee(string EmpID)
        {
            DAL.DAL.DeleteEmployee(EmpID);
        }
        public static void InsertSalary(SALARY sal)
        {
            DAL.DAL.InsertSalary(sal);
        }
        public static void DeleteSalary(string ID)
        {
            DAL.DAL.DeleteSalary(ID);
        }
        public static void InsertDepartment(DEPARTMENT dept)
        {
            DAL.DAL.InsertDepartment(dept);
        }
        public static void DeleteDepartmentItem(string DeptID) { }

        public static void InsertGroup(GROUP group) { DAL.DAL.InsertGroup(group); }
        public static void DeleteGroupItem(string GroupID) { DAL.DAL.DeleteGroupItem(GroupID); }

        public static void InsertTrainning(TRAINNING train) { DAL.DAL.InsertTrainning(train); }
        public static void DeleteTrainningItem(int ID) { DAL.DAL.DeleteTrainningItem(ID); }

        public static void InsertWorking(WORKING work) { DAL.DAL.InsertWorking(work); }
        public static void DeleteWorkingItem(int ID) { DAL.DAL.DeleteWorkingItem(ID); }

        public static void InsertAllowance(ALLOWANCE Allowance) { DAL.DAL.InsertAllowance(Allowance); }
        public static void DeleteAllowanceItem(string Code) { DAL.DAL.DeleteAllowanceItem(Code); }

        public static void InsertDeduction(DEDUCTION Deduct) { DAL.DAL.InsertDeduction(Deduct); }
        public static void DeleteDeductItem(string Code) { DAL.DAL.DeleteDeductItem(Code); }

        public static void InsertAdvance(SALARY_ADVANCE advance) { DAL.DAL.InsertAdvance(advance); }
        public static void DeleteAdvanceItem(string Code) { DAL.DAL.DeleteAdvanceItem(Code); }

        public static void InsertContract(CONTRACT contract) { DAL.DAL.InsertContract(contract); }
        public static void DeleteContractItem(string Code) { DAL.DAL.DeleteContractItem(Code); }

        public static void InsertCandicate(CANDIDATE Candicate) { DAL.DAL.InsertCandicate(Candicate); }
        public static void DeleteCandicateItem(string Code) { DAL.DAL.DeleteCandicateItem(Code); }

        public static void InsertHistory(HISTORY history) { DAL.DAL.InsertHistory(history); }
        public static void DeleteHistoryItem(int ID) { DAL.DAL.DeleteHistoryItem(ID); }

        public static void InsertReward(REWARD Reward) { DAL.DAL.InsertReward(Reward); }
        public static void DeleteRewardItem(int ID) { DAL.DAL.DeleteRewardItem(ID); }

        public static void InsertDiscipline(DISCIPLINE Discipline) { DAL.DAL.InsertDiscipline(Discipline); }
        public static void DeleteDisciplineItem(int ID) { DeleteDisciplineItem(ID); }

        public static void InsertEmpAllowance(EMP_ALLOWANCE Emp_Allowance) { DAL.DAL.InsertEmpAllowance(Emp_Allowance); }
        public static void DeleteEmpAllowance(string EmployeeID, string AllowanceCode) { DAL.DAL.DeleteEmpAllowance(EmployeeID, AllowanceCode); }

        public static void InsertEmpDeducted(EMP_DEDUCTED Emp_Deducted) { DAL.DAL.InsertEmpDeducted(Emp_Deducted); }
        public static void DeleteEmpDeducted(string EmployeeID, string DeductedCode) { DAL.DAL.DeleteEmpDeducted(EmployeeID,DeductedCode); }

        public static void InsertPosition(POSITION Position) { DAL.DAL.InsertPosition(Position); }
        public static void DeletePosition(string PositionID) { DAL.DAL.DeletePosition(PositionID); }


    }
}
