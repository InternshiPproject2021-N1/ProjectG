namespace CODEFIRST_ASP.NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFieldType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Create", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Create", c => c.DateTime(nullable: false));
        }
    }
}
