namespace CODEFIRST_ASP.NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEmployeeEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ContractID = c.String(nullable: false, maxLength: 10),
                        Contents = c.String(),
                        ContractType = c.String(),
                        SignDate = c.DateTime(nullable: false),
                        EmpID = c.String(maxLength: 10),
                        Create = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ContractID)
                .ForeignKey("dbo.Employees", t => t.EmpID)
                .Index(t => t.EmpID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpID = c.String(nullable: false, maxLength: 10),
                        Name = c.String(maxLength: 100),
                        Address = c.String(maxLength: 150),
                        Email = c.String(maxLength: 50),
                        Age = c.Int(nullable: false),
                        Status = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        Rank = c.Int(nullable: false),
                        Description = c.String(maxLength: 1000),
                        Create = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.EmpID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.String(nullable: false, maxLength: 10),
                        Name = c.String(maxLength: 100),
                        TeamSize = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 1000),
                        Create = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Employee_EmpID = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.Employees", t => t.Employee_EmpID)
                .Index(t => t.Employee_EmpID);
            
            CreateTable(
                "dbo.ProjectDetails",
                c => new
                    {
                        EmpID = c.String(nullable: false, maxLength: 128),
                        ProjectID = c.String(maxLength: 10),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Employee_EmpID = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.EmpID)
                .ForeignKey("dbo.Employees", t => t.Employee_EmpID)
                .ForeignKey("dbo.Projects", t => t.ProjectID)
                .Index(t => t.ProjectID)
                .Index(t => t.Employee_EmpID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 10),
                        Name = c.String(),
                        Description = c.String(maxLength: 1000),
                        Create = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 10),
                        Name = c.String(),
                        Password = c.String(),
                        Description = c.String(maxLength: 1000),
                        Create = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_UserID = c.String(nullable: false, maxLength: 10),
                        Role_RoleID = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.Role_RoleID })
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_RoleID, cascadeDelete: true)
                .Index(t => t.User_UserID)
                .Index(t => t.Role_RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "Role_RoleID", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.ProjectDetails", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.ProjectDetails", "Employee_EmpID", "dbo.Employees");
            DropForeignKey("dbo.Projects", "Employee_EmpID", "dbo.Employees");
            DropForeignKey("dbo.Contracts", "EmpID", "dbo.Employees");
            DropIndex("dbo.UserRoles", new[] { "Role_RoleID" });
            DropIndex("dbo.UserRoles", new[] { "User_UserID" });
            DropIndex("dbo.ProjectDetails", new[] { "Employee_EmpID" });
            DropIndex("dbo.ProjectDetails", new[] { "ProjectID" });
            DropIndex("dbo.Projects", new[] { "Employee_EmpID" });
            DropIndex("dbo.Contracts", new[] { "EmpID" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.ProjectDetails");
            DropTable("dbo.Projects");
            DropTable("dbo.Employees");
            DropTable("dbo.Contracts");
        }
    }
}
