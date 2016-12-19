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
        #region GetData
        public List<DEPARTMENT> LstDeptName
        {
            get { return GetListDeptName(); }
        }

        private List<DEPARTMENT> GetListDeptName()
        {
            using (var db = new HRM())
            {
                List<DEPARTMENT> LstDept = db.DEPARTMENT.Select(m => m).ToList();
                return LstDept;
            }
        }
        public List<EMPLOYEE> LstEmpByDept
        {
            get { return GetLstEmpByDept(); }
        }

        private  List<EMPLOYEE> GetLstEmpByDept()
        {
            using (var db = new HRM())
            {
                var LstDept = db.DEPARTMENT.Select(m => m.DeptID).ToList();
                List<EMPLOYEE> lstEmpDept = new List<EMPLOYEE>();
                foreach (var item in LstDept)
                {
                    var ds = db.EMPLOYEE.SingleOrDefault(m => m.DeptID == item);
                    lstEmpDept.Add(ds);
                }
                return lstEmpDept;
            }
        }

        public List<EMPLOYEE> LstEmpByGroup
        {
           get { return GetLstEmpByGroup(); }
        }

        private List<EMPLOYEE> GetLstEmpByGroup()
        {
            using (var db = new HRM())
            {
                var LstGroup = db.GROUP.Select(m => m.GroupID).ToList();
                List<EMPLOYEE> lstEmpDept = new List<EMPLOYEE>();
                foreach (var item in LstGroup)
                {
                    var ds = db.EMPLOYEE.SingleOrDefault(m => m.GroupID == item);
                    lstEmpDept.Add(ds);
                }

                return lstEmpDept;
            }
        }

        public static List<SYS_MENU> DsMenuCha(int ID)
        {
            HRM db = new HRM();
            List<SYS_MENU> ds = db.SYS_MENU.Where(m => m.ParentID == ID).ToList();
            return ds;
        }

        public ObservableCollection<CONTRACTTYPE> ListContractType
        {
            get { return GetListContractType(); }
        }
        public static ObservableCollection<CONTRACTTYPE> GetListContractType()
        {
            using (var db = new HRM())
            {
                ObservableCollection<CONTRACTTYPE> lstType = new ObservableCollection<CONTRACTTYPE>();
                foreach (var item in db.CONTRACTTYPE)
                {
                    lstType.Add(item);
                }
                return lstType;
            }
        }

        public ObservableCollection<DEPARTMENT> ListDepartmentItem
        {
            get { return GetListDepartmentItem(); }
        }
        public static ObservableCollection<DEPARTMENT> GetListDepartmentItem()
        {
            using (var db = new HRM())
            {
                ObservableCollection<DEPARTMENT> lstDept = new ObservableCollection<DEPARTMENT>();
                foreach (var item in db.DEPARTMENT)
                {
                    lstDept.Add(item);
                }
                return lstDept;
            }
        }

        public ObservableCollection<POSITION> ListPositionItem
        {
            get { return GetListPositionItem(); }
        }
        public static ObservableCollection<POSITION> GetListPositionItem()
        {
            using (var db = new HRM())
            {
                ObservableCollection<POSITION> lstPosi = new ObservableCollection<POSITION>();
                foreach (var item in db.POSITION)
                {
                    lstPosi.Add(item);
                }
                return lstPosi;
            }
        }

        public ObservableCollection<GROUP> ListGroupItem
        {
            get { return GetListGroupItem(); }
        }
        public static ObservableCollection<GROUP> GetListGroupItem()
        {
            using (var db = new HRM())
            {
                ObservableCollection<GROUP> lstGroup = new ObservableCollection<GROUP>();
                foreach (var item in db.GROUP)
                {
                    lstGroup.Add(item);
                }
                return lstGroup;
            }
        }

        public static ObservableCollection<SALARY> DsLuong()
        {
            return GetListSalary();
        }
        private static ObservableCollection<SALARY> GetListSalary()
        {
            using (var db = new HRM())
            {
                ObservableCollection<SALARY> lstSalary = new ObservableCollection<SALARY>();
                foreach (var item in db.SALARY)
                {
                    lstSalary.Add(item);
                }
                return lstSalary;
            }
        }

        public static ObservableCollection<EMPLOYEE> DsEmployee()
        {
            return GetListEmployee();
        }
        private static ObservableCollection<EMPLOYEE> GetListEmployee()
        {
            using (var db = new HRM())
            {
                ObservableCollection<EMPLOYEE> lstEmp = new ObservableCollection<EMPLOYEE>();
                foreach (var item in db.EMPLOYEE)
                {
                    lstEmp.Add(item);
                }
                return lstEmp;
            }
        }

        public ObservableCollection<ALLOWANCE> ListAllowance
        {
            get { return GetListAllowance(); }
        }
        public static ObservableCollection<ALLOWANCE> GetListAllowance()
        {
            using (var db = new HRM())
            {
                ObservableCollection<ALLOWANCE> lstAllowance = new ObservableCollection<ALLOWANCE>();
                foreach (var item in db.ALLOWANCE)
                {
                    lstAllowance.Add(item);
                }
                return lstAllowance;
            }
        }

        public ObservableCollection<DEDUCTION> ListDeduction
        {
            get { return GetListDeduction(); }
        }
        public static ObservableCollection<DEDUCTION> GetListDeduction()
        {
            using (var db = new HRM())
            { 
                ObservableCollection<DEDUCTION> lstDeduction = new ObservableCollection<DEDUCTION>();
                foreach (var item in db.DEDUCTION)
                {
                    lstDeduction.Add(item);
                }
                return lstDeduction;
            }
        }

        public ObservableCollection<HISTORY> ListHistory
        {
            get { return GetListHistory(); }
        }
        public static ObservableCollection<HISTORY> GetListHistory()
        {
            using (var db = new HRM())
            {
                ObservableCollection<HISTORY> lstHistory = new ObservableCollection<HISTORY>();
                foreach (var item in db.HISTORY)
                {
                    lstHistory.Add(item);
                }
                return lstHistory;
            }
        }

        public ObservableCollection<TRAINNING> ListTrainning
        {
            get { return GetListTrainning(); }
        }
        public static ObservableCollection<TRAINNING> GetListTrainning()
        {
            using (var db = new HRM())
            {
                ObservableCollection<TRAINNING> lstTrainning = new ObservableCollection<TRAINNING>();
                foreach (var item in db.TRAINNING)
                {
                    lstTrainning.Add(item);
                }
                return lstTrainning;
            }
        }

        public ObservableCollection<WORKING> ListWorking
        {
            get { return GetListWorking(); }
        }
        public static ObservableCollection<WORKING> GetListWorking()
        {
            using (var db = new HRM())
            {
                ObservableCollection<WORKING> lstWorking = new ObservableCollection<WORKING>();
                foreach (var item in db.WORKING)
                {
                    lstWorking.Add(item);
                }
                return lstWorking;
            }
        }

        public ObservableCollection<CANDIDATE> ListCandicate
        {
            get { return GetListCandicate(); }
        }
        public static ObservableCollection<CANDIDATE> GetListCandicate()
        {
            using (var db = new HRM())
            {
                ObservableCollection<CANDIDATE> LstCandicate = new ObservableCollection<CANDIDATE>();
                foreach (var item in db.CANDIDATE)
                {
                    LstCandicate.Add(item);
                }
                return LstCandicate;
            }
        }

        public ObservableCollection<SALARY_ADVANCE> ListAdvance
        {
            get { return GetListAdvance(); }
        }
        public static ObservableCollection<SALARY_ADVANCE> GetListAdvance()
        {
            using (var db = new HRM())
            {
                ObservableCollection<SALARY_ADVANCE> lstAdvance = new ObservableCollection<SALARY_ADVANCE>();
                foreach (var item in db.SALARY_ADVANCE)
                {
                    lstAdvance.Add(item);
                }
                return lstAdvance;
            }
        }

        public ObservableCollection<EMP_ALLOWANCE> ListEmpAllwance
        {
            get { return GetListEmpAllwance(); }
        }
        public static ObservableCollection<EMP_ALLOWANCE> GetListEmpAllwance()
        {
            using (var db = new HRM())
            {
                ObservableCollection<EMP_ALLOWANCE> lstEmpAllwance = new ObservableCollection<EMP_ALLOWANCE>();
                foreach (var item in db.EMP_ALLOWANCE)
                {
                    lstEmpAllwance.Add(item);
                }
                return lstEmpAllwance;
            }
        }

        public ObservableCollection<EMP_DEDUCTED> ListEmpDeduct
        {
            get { return GetListEmpDeduct(); }
        }
        public static ObservableCollection<EMP_DEDUCTED> GetListEmpDeduct()
        {
            using (var db = new HRM())
            {
                ObservableCollection<EMP_DEDUCTED> lstEmpDeducte = new ObservableCollection<EMP_DEDUCTED>();
                foreach (var item in db.EMP_DEDUCTED)
                {
                    lstEmpDeducte.Add(item);
                }
                return lstEmpDeducte;
            }
        }

        public ObservableCollection<REWARD> ListReward
        {
            get { return GetListReward(); }
        }
        public static ObservableCollection<REWARD> GetListReward()
        {
            using (var db = new HRM())
            {
                ObservableCollection<REWARD> lstReward = new ObservableCollection<REWARD>();
                foreach (var item in db.REWARD)
                {
                    lstReward.Add(item);
                }
                return lstReward;
            }
        }

        public ObservableCollection<CONTRACT> ListContract
        {
            get { return GetListContract(); }
        }
        public static ObservableCollection<CONTRACT> GetListContract()
        {
            using (var db = new HRM())
            {
                ObservableCollection<CONTRACT> LstContract = new ObservableCollection<CONTRACT>();
                foreach (var item in db.CONTRACT)
                {
                    LstContract.Add(item);
                }
                return LstContract;
            }
        }


        public ObservableCollection<DISCIPLINE> ListDiscipline
        {
            get { return GetListDiscipline(); }
        }

        public static ObservableCollection<DISCIPLINE> GetListDiscipline()
        {
            using (var db = new HRM())
            {
                ObservableCollection<DISCIPLINE> LstDiscipline = new ObservableCollection<DISCIPLINE>();
                foreach (var item in db.DISCIPLINE)
                {
                    LstDiscipline.Add(item);
                }
                return LstDiscipline;
            }
        }
        #endregion
        #region Save, Delete
        public static void InsertEmployee(EMPLOYEE _emp)
        {
            HRM db = new HRM();
            var Item = db.EMPLOYEE.SingleOrDefault(m => m.EmployeeID == _emp.EmployeeID);
            if(Item == null)
            {
                EMPLOYEE emp = new EMPLOYEE();
                emp.EmployeeID = _emp.EmployeeID;
                emp.FirstName = _emp.FirstName;
                emp.LastName = _emp.LastName;
                emp.Gender = _emp.Gender;
                emp.GroupID = _emp.GroupID;
                emp.PostionID = _emp.PostionID;
                emp.Address = _emp.Address;
                emp.DeptID = _emp.DeptID;
                emp.DOB = _emp.DOB;
                emp.Email = _emp.Email;
                emp.Phone = _emp.Phone;
                db.EMPLOYEE.Add(emp);
            }
            else
            {
                EMPLOYEE emp = db.EMPLOYEE.SingleOrDefault(m => m.EmployeeID == _emp.EmployeeID);
                emp.EmployeeID = _emp.EmployeeID;
                emp.FirstName = _emp.FirstName;
                emp.LastName = _emp.LastName;
                emp.Gender = _emp.Gender;
                emp.GroupID = _emp.GroupID;
                emp.PostionID = _emp.PostionID;
                emp.Address = _emp.Address;
                emp.DeptID = _emp.DeptID;
                emp.DOB = _emp.DOB;
                emp.Email = _emp.Email;
                emp.Phone = _emp.Phone;
            }
            db.SaveChanges();
        }
        public static void DeleteEmployee(string EmpID)
        {
            HRM db = new HRM();
            var Item = db.EMPLOYEE.SingleOrDefault(m => m.EmployeeID == EmpID);
            if(Item != null)
            {
                db.EMPLOYEE.Remove(Item);
                db.SaveChanges();
            }
        }
        public static void InsertDepartment(DEPARTMENT dept)
        {
            HRM db = new HRM();
            var Item = db.DEPARTMENT.SingleOrDefault(m => m.DeptID == dept.DeptID);
            if (Item == null)
            {
                DEPARTMENT _dept = new DEPARTMENT();
                _dept.DeptID = dept.DeptID;
                _dept.DeptName = dept.DeptName;
                _dept.Descr = dept.Descr;
                _dept.Note = dept.Note;

                db.DEPARTMENT.Add(_dept);
            }
            else
            {
                DEPARTMENT _dept = db.DEPARTMENT.SingleOrDefault(m => m.DeptID == dept.DeptID);
                _dept.DeptID = dept.DeptID;
                _dept.DeptName = dept.DeptName;
                _dept.Descr = dept.Descr;
                _dept.Note = dept.Note;
            }
            db.SaveChanges();
        }
        public static void DeleteDepartmentItem(string DeptID)
        {
            HRM db = new HRM();
            var Item = db.DEPARTMENT.SingleOrDefault(m => m.DeptID == DeptID);
            if (Item != null)
            {
                db.DEPARTMENT.Remove(Item);
                db.SaveChanges();
            }
        }
        public static void InsertGroup(GROUP group)
        {
            HRM db = new HRM();
            var Item = db.GROUP.SingleOrDefault(m => m.GroupID == group.DeptID);
            if (Item == null)
            {
                GROUP _group = new GROUP();
                _group.DeptID = group.DeptID;
                _group.GroupID = group.GroupName;
                _group.GroupName = group.Descr;
                _group.Note = group.Note;
                _group.Descr = group.Descr;

                db.GROUP.Add(_group);
            }
            else
            {
                GROUP _group = db.GROUP.SingleOrDefault(m => m.GroupID == group.DeptID);
                group.DeptID = group.DeptID;
                _group.GroupID = group.GroupName;
                _group.GroupName = group.Descr;
                _group.Note = group.Note;
                _group.Descr = group.Descr;
            }
            db.SaveChanges();
        }
        public static void DeleteGroupItem(string GroupID)
        {
            HRM db = new HRM();
            var Item = db.GROUP.SingleOrDefault(m => m.GroupID == GroupID);
            if (Item != null)
            {
                db.GROUP.Remove(Item);
                db.SaveChanges();
            }
        }

        public static void InsertTrainning(TRAINNING train)
        {
            HRM db = new HRM();
            var Item = db.TRAINNING.SingleOrDefault(m => m.ID == train.ID);
            if (Item == null)
            {
                TRAINNING _train = new TRAINNING();
                _train.Reason = train.Reason;
                _train.Place = train.Place;
                _train.Time = train.Time;
                _train.FromDate = train.FromDate;
                _train.ToDate = train.ToDate;
                _train.Result = train.Result;
                _train.Note = train.Note;
                _train.EmployeeID = train.EmployeeID;
                _train.Descr = train.Descr;

                db.TRAINNING.Add(_train);
            }
            else
            {
                TRAINNING _train = db.TRAINNING.SingleOrDefault(m => m.ID == train.ID);
                _train.Reason = train.Reason;
                _train.Place = train.Place;
                _train.Time = train.Time;
                _train.FromDate = train.FromDate;
                _train.ToDate = train.ToDate;
                _train.Result = train.Result;
                _train.Note = train.Note;
                _train.EmployeeID = train.EmployeeID;
                _train.Descr = train.Descr;
            }
            db.SaveChanges();
        }
        public static void DeleteTrainningItem(int ID)
        {
            HRM db = new HRM();
            var Item = db.TRAINNING.SingleOrDefault(m => m.ID == ID);
            if (Item != null)
            {
                db.TRAINNING.Remove(Item);
                db.SaveChanges();
            }
        }

        public static void InsertWorking(WORKING work)
        {
            HRM db = new HRM();
            var Item = db.WORKING.SingleOrDefault(m => m.ID == work.ID);
            if (Item == null)
            {
                WORKING _work = new WORKING();
                _work.Reason = work.Reason;
                _work.DecideNum = work.DecideNum;
                _work.FromDate = work.FromDate;
                _work.ToDate = work.ToDate;
                _work.EmployeeID = work.EmployeeID;
                _work.PositionID = work.PositionID;

                db.WORKING.Add(_work);
            }
            else
            {
                WORKING _work = db.WORKING.SingleOrDefault(m => m.ID == work.ID);
                _work.Reason = work.Reason;
                _work.DecideNum = work.DecideNum;
                _work.FromDate = work.FromDate;
                _work.ToDate = work.ToDate;
                _work.EmployeeID = work.EmployeeID;
                _work.PositionID = work.PositionID;
            }
            db.SaveChanges();
        }
        public static void DeleteWorkingItem(int ID)
        {
            HRM db = new HRM();
            var Item = db.WORKING.SingleOrDefault(m => m.ID == ID);
            if (Item != null)
            {
                db.WORKING.Remove(Item);
                db.SaveChanges();
            }
        }

        public static void InsertAllowance(ALLOWANCE Allowance)
        {
            HRM db = new HRM();
            var Item = db.ALLOWANCE.SingleOrDefault(m => m.ID == Allowance.ID);
            if (Item == null)
            {
                ALLOWANCE _Allowance = new ALLOWANCE();
                _Allowance.Descr = Allowance.Descr;
                _Allowance.Name = Allowance.Name;
                _Allowance.Rate = Allowance.Rate;

                db.ALLOWANCE.Add(_Allowance);
            }
            else
            {
                ALLOWANCE _Allowance = db.ALLOWANCE.SingleOrDefault(m => m.ID == Allowance.ID);
                _Allowance.Descr = Allowance.Descr;
                _Allowance.Name = Allowance.Name;
                _Allowance.Rate = Allowance.Rate;
            }
            db.SaveChanges();
        }
        public static void DeleteAllowanceItem(int ID)
        {
            HRM db = new HRM();
            var Item = db.ALLOWANCE.SingleOrDefault(m => m.ID == ID);
            if (Item != null)
            {
                db.ALLOWANCE.Remove(Item);
                db.SaveChanges();
            }
        }

        public static void InsertDeduction(DEDUCTION Deduct)
        {
            HRM db = new HRM();
            var Item = db.DEDUCTION.SingleOrDefault(m => m.ID == Deduct.ID);
            if (Item == null)
            {
                DEDUCTION _Deduct = new DEDUCTION();
                _Deduct.Descr = Deduct.Descr;
                _Deduct.Name = Deduct.Name;
                _Deduct.Rate = Deduct.Rate;

                db.DEDUCTION.Add(_Deduct);
            }
            else
            {
                DEDUCTION _Deduct = db.DEDUCTION.SingleOrDefault(m => m.ID == Deduct.ID);
                _Deduct.Descr = Deduct.Descr;
                _Deduct.Name = Deduct.Name;
                _Deduct.Rate = Deduct.Rate;
            }
            db.SaveChanges();
        }
        public static void DeleteDeductItem(int ID)
        {
            HRM db = new HRM();
            var Item = db.DEDUCTION.SingleOrDefault(m => m.ID == ID);
            if (Item != null)
            {
                db.DEDUCTION.Remove(Item);
                db.SaveChanges();
            }
        }

        public static void InsertAdvance(SALARY_ADVANCE advance)
        {
            HRM db = new HRM();
            var Item = db.SALARY_ADVANCE.SingleOrDefault(m => m.SalaryAdvanceCode == advance.SalaryAdvanceCode);
            if (Item == null)
            {
                SALARY_ADVANCE _Advance = new SALARY_ADVANCE();
                _Advance.SalaryAdvanceCode = advance.SalaryAdvanceCode;
                _Advance.Reason = advance.Reason;
                _Advance.Money = advance.Money;
                _Advance.EmployeeID = advance.EmployeeID;

                db.SALARY_ADVANCE.Add(_Advance);
            }
            else
            {
                SALARY_ADVANCE _Advance = db.SALARY_ADVANCE.SingleOrDefault(m => m.SalaryAdvanceCode == advance.SalaryAdvanceCode);
                _Advance.SalaryAdvanceCode = advance.SalaryAdvanceCode;
                _Advance.Reason = advance.Reason;
                _Advance.Money = advance.Money;
                _Advance.EmployeeID = advance.EmployeeID;
            }
            db.SaveChanges();
        }
        public static void DeleteAdvanceItem(string Code)
        {
            HRM db = new HRM();
            var Item = db.SALARY_ADVANCE.SingleOrDefault(m => m.SalaryAdvanceCode == Code);
            if (Item != null)
            {
                db.SALARY_ADVANCE.Remove(Item);
                db.SaveChanges();
            }
        }

        public static void InsertContract(CONTRACT contract)
        {
            HRM db = new HRM();
            var Item = db.CONTRACT.SingleOrDefault(m => m.ContractCode == contract.ContractCode);
            if (Item == null)
            {
                CONTRACT _Contract = new CONTRACT();
                _Contract.ContractCode = contract.ContractCode;
                _Contract.ContractType = contract.ContractType;
                _Contract.FromDate = contract.FromDate;
                _Contract.EmployeeID = contract.EmployeeID;
                _Contract.Salary = contract.Salary;
                _Contract.SignDate = contract.SignDate;
                _Contract.ToDate = contract.ToDate;
                _Contract.ValidDate = contract.ValidDate;

                db.CONTRACT.Add(_Contract);
            }
            else
            {
                CONTRACT _Contract = db.CONTRACT.SingleOrDefault(m => m.ContractCode == contract.ContractCode);
                _Contract.ContractCode = contract.ContractCode;
                _Contract.ContractType = contract.ContractType;
                _Contract.FromDate = contract.FromDate;
                _Contract.EmployeeID = contract.EmployeeID;
                _Contract.Salary = contract.Salary;
                _Contract.SignDate = contract.SignDate;
                _Contract.ToDate = contract.ToDate;
                _Contract.ValidDate = contract.ValidDate;

            }
            db.SaveChanges();
        }
        public static void DeleteContractItem(string Code)
        {
            HRM db = new HRM();
            var Item = db.CONTRACT.SingleOrDefault(m => m.ContractCode == Code);
            if (Item != null)
            {
                db.CONTRACT.Remove(Item);
                db.SaveChanges();
            }
        }

        public static void InsertCandicate(CANDIDATE Candicate)
        {
            HRM db = new HRM();
            var Item = db.CANDIDATE.SingleOrDefault(m => m.CandidateCode == Candicate.CandidateCode);
            if (Item == null)
            {
                CANDIDATE _Candicate = new CANDIDATE();
                _Candicate.CandidateCode = Candicate.CandidateCode;
                _Candicate.Birthday = Candicate.Birthday;
                _Candicate.BirthPlace = Candicate.BirthPlace;
                _Candicate.CellPhone = Candicate.CellPhone;
                _Candicate.ContactAddress = Candicate.ContactAddress;
                _Candicate.Education = Candicate.Education;
                _Candicate.Email = Candicate.Email;
                _Candicate.Experience = Candicate.Experience;
                _Candicate.FirstName = Candicate.FirstName;
                _Candicate.Gender = Candicate.Gender;
                _Candicate.HomePhone = Candicate.HomePhone;
                _Candicate.Job = Candicate.Job;
                _Candicate.Language = Candicate.Language;
                _Candicate.LastName = Candicate.LastName;
                _Candicate.MainAddress = Candicate.MainAddress;
                _Candicate.RecruitmentCode = Candicate.RecruitmentCode;
                _Candicate.Photo = Candicate.Photo;
                _Candicate.ExpectSalary = Candicate.ExpectSalary;

                db.CANDIDATE.Add(_Candicate);
            }
            else
            {
                CANDIDATE _Candicate = db.CANDIDATE.SingleOrDefault(m => m.CandidateCode == Candicate.CandidateCode);
                _Candicate.CandidateCode = Candicate.CandidateCode;
                _Candicate.Birthday = Candicate.Birthday;
                _Candicate.BirthPlace = Candicate.BirthPlace;
                _Candicate.CellPhone = Candicate.CellPhone;
                _Candicate.ContactAddress = Candicate.ContactAddress;
                _Candicate.Education = Candicate.Education;
                _Candicate.Email = Candicate.Email;
                _Candicate.Experience = Candicate.Experience;
                _Candicate.FirstName = Candicate.FirstName;
                _Candicate.Gender = Candicate.Gender;
                _Candicate.HomePhone = Candicate.HomePhone;
                _Candicate.Job = Candicate.Job;
                _Candicate.Language = Candicate.Language;
                _Candicate.LastName = Candicate.LastName;
                _Candicate.MainAddress = Candicate.MainAddress;
                _Candicate.RecruitmentCode = Candicate.RecruitmentCode;
                _Candicate.Photo = Candicate.Photo;
                _Candicate.ExpectSalary = Candicate.ExpectSalary;

            }
            db.SaveChanges();
        }
        public static void DeleteCandicateItem(string Code)
        {
            HRM db = new HRM();
            var Item = db.CANDIDATE.SingleOrDefault(m => m.CandidateCode == Code);
            if (Item != null)
            {
                db.CANDIDATE.Remove(Item);
                db.SaveChanges();
            }
        }

        public static void InsertHistory(HISTORY history )
        {
            HRM db = new HRM();
            var Item = db.HISTORY.SingleOrDefault(m => m.ID == history.ID);
            if (Item == null)
            {
                HISTORY _History = new HISTORY();
                _History.Place = history.Place;
                _History.Position = history.Position;
                _History.Reason = history.Reason;
                _History.ToDate = history.ToDate;
                _History.FromDate = history.FromDate;
                _History.EmployeeID = history.EmployeeID;
                

                db.HISTORY.Add(_History);
            }
            else
            {
                HISTORY _History = db.HISTORY.SingleOrDefault(m => m.ID == history.ID);
                _History.Place = history.Place;
                _History.Position = history.Position;
                _History.Reason = history.Reason;
                _History.ToDate = history.ToDate;
                _History.FromDate = history.FromDate;
                _History.EmployeeID = history.EmployeeID;

            }
            db.SaveChanges();
        }
        public static void DeleteHistoryItem(int ID)
        {
            HRM db = new HRM();
            var Item = db.HISTORY.SingleOrDefault(m => m.ID == ID);
            if (Item != null)
            {
                db.HISTORY.Remove(Item);
                db.SaveChanges();
            }
        }

        public static void InsertReward(REWARD Reward)
        {
            HRM db = new HRM();
            var Item = db.REWARD.SingleOrDefault(m => m.ID == Reward.ID);
            if (Item == null)
            {
                REWARD _Reward = new REWARD();
                _Reward.RewardName = Reward.RewardName;
                _Reward.EmployeeID = Reward.EmployeeID;
                _Reward.DecideNum = Reward.DecideNum;
                _Reward.DecideDate = Reward.DecideDate;


                db.REWARD.Add(_Reward);
            }
            else
            {
                REWARD _Reward = db.REWARD.SingleOrDefault(m => m.ID == Reward.ID);
                _Reward.RewardName = Reward.RewardName;
                _Reward.EmployeeID = Reward.EmployeeID;
                _Reward.DecideNum = Reward.DecideNum;
                _Reward.DecideDate = Reward.DecideDate;

            }
            db.SaveChanges();
        }
        public static void DeleteRewardItem(int ID)
        {
            HRM db = new HRM();
            var Item = db.REWARD.SingleOrDefault(m => m.ID == ID);
            if (Item != null)
            {
                db.REWARD.Remove(Item);
                db.SaveChanges();
            }
        }

        public static void InsertDiscipline(DISCIPLINE Discipline)
        {
            HRM db = new HRM();
            var Item = db.DISCIPLINE.SingleOrDefault(m => m.ID == Discipline.ID);
            if (Item == null)
            {
                DISCIPLINE _Discipline = new DISCIPLINE();
                _Discipline.Date = Discipline.Date;
                _Discipline.EmployeeID = Discipline.EmployeeID;
                _Discipline.Descr = Discipline.Descr;

                db.DISCIPLINE.Add(_Discipline);
            }
            else
            {
                DISCIPLINE _Discipline = db.DISCIPLINE.SingleOrDefault(m => m.ID == Discipline.ID);
                _Discipline.Date = Discipline.Date;
                _Discipline.EmployeeID = Discipline.EmployeeID;
                _Discipline.Descr = Discipline.Descr;

            }
            db.SaveChanges();
        }
        public static void DeleteDisciplineItem(int ID)
        {
            HRM db = new HRM();
            var Item = db.DISCIPLINE.SingleOrDefault(m => m.ID == ID);
            if (Item != null)
            {
                db.DISCIPLINE.Remove(Item);
                db.SaveChanges();
            }
        }
        public static void InsertPosition(POSITION Position)
        {
            HRM db = new HRM();
            var Item = db.POSITION.SingleOrDefault(m => m.PositionID == Position.PositionID);
            if (Item == null)
            {
                POSITION _Position = new POSITION();
                _Position.PositionID = Position.PositionID;
                _Position.PositionName = Position.PositionName;
                _Position.Note = Position.Note;
                _Position.Descr = Position.Descr;

                db.POSITION.Add(_Position);
            }
            else
            {
                POSITION _Position = db.POSITION.SingleOrDefault(m => m.PositionID == Position.PositionID);
                _Position.PositionID = Position.PositionID;
                _Position.PositionName = Position.PositionName;
                _Position.Note = Position.Note;
                _Position.Descr = Position.Descr;

            }
            db.SaveChanges();
        }
        public static void DeletePosition(string ID)
        {
            HRM db = new HRM();
            var Item = db.POSITION.SingleOrDefault(m => m.PositionID == ID);
            if (Item != null)
            {
                db.POSITION.Remove(Item);
                db.SaveChanges();
            }
        }

        public static void InsertEmpAllowance(EMP_ALLOWANCE Emp_Allowance)
        {
            HRM db = new HRM();
            var Item = db.EMP_ALLOWANCE.SingleOrDefault(m => m.EmployeeID == Emp_Allowance.EmployeeID && m.AllowanceCode == Emp_Allowance.AllowanceCode);
            if (Item == null)
            {
                EMP_ALLOWANCE _Emp_Allowance = new EMP_ALLOWANCE();
                _Emp_Allowance.EmployeeID = Emp_Allowance.EmployeeID;
                _Emp_Allowance.AllowanceCode = Emp_Allowance.AllowanceCode;
                db.EMP_ALLOWANCE.Add(_Emp_Allowance);
            }
            else
            {
                EMP_ALLOWANCE _Emp_Allowance = db.EMP_ALLOWANCE.SingleOrDefault(m => m.EmployeeID == Emp_Allowance.EmployeeID && m.AllowanceCode == Emp_Allowance.AllowanceCode);

                _Emp_Allowance.EmployeeID = Emp_Allowance.EmployeeID;
                _Emp_Allowance.AllowanceCode = Emp_Allowance.AllowanceCode;

                db.EMP_ALLOWANCE.Add(_Emp_Allowance);

            }
            db.SaveChanges();
        }
        public static void DeleteEmpAllowance(string EmployeeID, int AllowanceCode )
        {
            HRM db = new HRM();
            var Item = db.EMP_ALLOWANCE.SingleOrDefault(m => m.EmployeeID == EmployeeID && m.AllowanceCode == AllowanceCode);

            if (Item != null)
            {
                db.EMP_ALLOWANCE.Remove(Item);
                db.SaveChanges();
            }
        }

        public static void InsertEmpDeducted(EMP_DEDUCTED Emp_Deducted)
        {
            HRM db = new HRM();
            var Item = db.EMP_DEDUCTED.SingleOrDefault(m => m.EmployeeID == Emp_Deducted.EmployeeID && m.DeductCode == Emp_Deducted.DeductCode);
            if (Item == null)
            {
                EMP_DEDUCTED _Emp_Deducted = new EMP_DEDUCTED();
                _Emp_Deducted.EmployeeID = Emp_Deducted.EmployeeID;
                _Emp_Deducted.DeductCode = Emp_Deducted.DeductCode;
                db.EMP_DEDUCTED.Add(_Emp_Deducted);
            }
            else
            {
                EMP_DEDUCTED _Emp_Deducted = db.EMP_DEDUCTED.SingleOrDefault(m => m.EmployeeID == Emp_Deducted.EmployeeID && m.DeductCode == Emp_Deducted.DeductCode);

                _Emp_Deducted.EmployeeID = Emp_Deducted.EmployeeID;
                _Emp_Deducted.DeductCode = Emp_Deducted.DeductCode;

            }
            db.SaveChanges();
        }
        public static void DeleteEmpDeducted(string EmployeeID, int ID)
        {
            HRM db = new HRM();
            var Item = db.EMP_DEDUCTED.SingleOrDefault(m => m.EmployeeID == EmployeeID && m.DeductCode == ID);
            if (Item != null)
            {
                db.EMP_DEDUCTED.Remove(Item);
                db.SaveChanges();
            }
        }

        public static void InsertSalary(SALARY salary)
        {
            HRM db = new HRM();
            var Item = db.SALARY.SingleOrDefault(m => m.ID == salary.ID);
            if (Item == null)
            {
                SALARY sal = new SALARY();
                sal.ID = salary.ID;
                sal.EmployeeID = salary.EmployeeID;
                sal.WorkDays = salary.WorkDays;
                sal.Deducttion = salary.Deducttion;
                sal.Allowance = salary.Allowance;
                db.SALARY.Add(sal);
            }
            else
            {
                SALARY sal = db.SALARY.SingleOrDefault(m => m.ID == salary.ID);
                sal.ID = salary.ID;
                sal.EmployeeID = salary.EmployeeID;
                sal.WorkDays = salary.WorkDays;
                sal.Deducttion = salary.Deducttion;
                sal.Allowance = salary.Allowance;
                db.SALARY.Add(sal);
            }
            db.SaveChanges();
        }
        public static void DeleteSalary(string ID)
        {
            HRM db = new HRM();
            var Item = db.SALARY.SingleOrDefault(m => m.ID == ID);
            if (Item != null)
            {
                db.SALARY.Remove(Item);
                db.SaveChanges();
            }
        }
        #endregion

    }
}
