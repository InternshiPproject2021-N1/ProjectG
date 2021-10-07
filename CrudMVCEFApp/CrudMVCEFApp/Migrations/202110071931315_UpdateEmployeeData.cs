namespace CrudMVCEFApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployeeData : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Employees(EmployeeName,EmployeeDesignation,EmployeeAddress,EmployeePassport,EmployeePhone,EmployeeGender,City,Project,CompanyName,PinCode,DepartmentId)" +
                "Values('KM','S.E','Hyderabad','K849271',123456789,'Male','Hyderabad','Automation','Infosys',500045,1)");
        }
        
        public override void Down()
        {
        }
    }
}
