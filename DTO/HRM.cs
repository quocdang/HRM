namespace DTO
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HRM : DbContext
    {
        public HRM()
            : base("name=HRM")
        {
        }

        public virtual DbSet<ALLOWANCE> ALLOWANCEs { get; set; }
        public virtual DbSet<CANDIDATE> CANDIDATEs { get; set; }
        public virtual DbSet<CONTRACT> CONTRACTs { get; set; }
        public virtual DbSet<CONTRACTTYPE> CONTRACTTYPEs { get; set; }
        public virtual DbSet<DEDUCTION> DEDUCTIONs { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENTs { get; set; }
        public virtual DbSet<DISCIPLINE> DISCIPLINEs { get; set; }
        public virtual DbSet<EMP_ALLOWANCE> EMP_ALLOWANCE { get; set; }
        public virtual DbSet<EMP_DEDUCTED> EMP_DEDUCTED { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEEs { get; set; }
        public virtual DbSet<GROUP> GROUPs { get; set; }
        public virtual DbSet<HISTORY> HISTORies { get; set; }
        public virtual DbSet<POSITION> POSITIONs { get; set; }
        public virtual DbSet<REWARD> REWARDs { get; set; }
        public virtual DbSet<SALARY> SALARies { get; set; }
        public virtual DbSet<SALARY_ADVANCE> SALARY_ADVANCE { get; set; }
        public virtual DbSet<SYS_MENU> SYS_MENU { get; set; }
        public virtual DbSet<SYS_USER> SYS_USER { get; set; }
        public virtual DbSet<SYS_USERGROUP> SYS_USERGROUP { get; set; }
        public virtual DbSet<TRAINNING> TRAINNINGs { get; set; }
        public virtual DbSet<WORKING> WORKINGs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ALLOWANCE>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<ALLOWANCE>()
                .Property(e => e.Money)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CANDIDATE>()
                .Property(e => e.CandidateCode)
                .IsUnicode(false);

            modelBuilder.Entity<CANDIDATE>()
                .Property(e => e.ExpectSalary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CONTRACT>()
                .Property(e => e.ContractCode)
                .IsUnicode(false);

            modelBuilder.Entity<CONTRACT>()
                .Property(e => e.Salary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DEDUCTION>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.DeptID)
                .IsUnicode(false);

            modelBuilder.Entity<DISCIPLINE>()
                .Property(e => e.EmployeeID)
                .IsUnicode(false);

            modelBuilder.Entity<EMP_ALLOWANCE>()
                .Property(e => e.EmployeeID)
                .IsUnicode(false);

            modelBuilder.Entity<EMP_ALLOWANCE>()
                .Property(e => e.AllowanceCode)
                .IsUnicode(false);

            modelBuilder.Entity<EMP_DEDUCTED>()
                .Property(e => e.EmployeeID)
                .IsUnicode(false);

            modelBuilder.Entity<EMP_DEDUCTED>()
                .Property(e => e.DeductCode)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.EmployeeID)
                .IsUnicode(false);

            modelBuilder.Entity<GROUP>()
                .Property(e => e.GroupID)
                .IsUnicode(false);

            modelBuilder.Entity<GROUP>()
                .Property(e => e.DeptID)
                .IsUnicode(false);

            modelBuilder.Entity<HISTORY>()
                .Property(e => e.EmployeeID)
                .IsUnicode(false);

            modelBuilder.Entity<POSITION>()
                .Property(e => e.PositionID)
                .IsUnicode(false);

            modelBuilder.Entity<SALARY>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<SALARY>()
                .Property(e => e.RealSalary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SALARY_ADVANCE>()
                .Property(e => e.SalaryAdvanceCode)
                .IsUnicode(false);

            modelBuilder.Entity<SALARY_ADVANCE>()
                .Property(e => e.Money)
                .HasPrecision(19, 4);
        }
    }
}
