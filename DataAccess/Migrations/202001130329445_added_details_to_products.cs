﻿namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_details_to_products : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Details", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Details");
        }
    }
}
