using Burak.Application.Inveon.Data.EntityModels;
using FluentMigrator;
using System;

namespace Burak.Application.Inveon.Data.Migrations
{
    [Migration(1)]
    public class _00001_InitialCreate : Migration
    {
        public override void Up()
        {

            Create.Table(nameof(User)) //Seed with sample users and give guid on documentation
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Username").AsString().Nullable()
                .WithColumn("Password").AsString().Nullable()
                .WithColumn("Role").AsString().Nullable()
                .WithColumn("IsActive").AsBoolean().WithDefaultValue(true)
                .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false)
                .WithColumn("CreatedOnUtc").AsDateTime2().WithDefaultValue(DateTime.Now)
                .WithColumn("UpdatedOnUtc").AsDateTime2().WithDefaultValue(DateTime.Now);


            Create.Table(nameof(Product)) //Seed with sample users and give guid on documentation
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("SKU").AsString().Nullable()
                .WithColumn("ProductName").AsString().Nullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("Price").AsDecimal(20,2).WithDefaultValue(1)
                .WithColumn("Quantity").AsInt32().WithDefaultValue(0)
                .WithColumn("Image1").AsString().Nullable()
                .WithColumn("Image2").AsString().Nullable()
                .WithColumn("IsActive").AsBoolean().WithDefaultValue(true)
                .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false)
                .WithColumn("CreatedOnUtc").AsDateTime2().WithDefaultValue(DateTime.Now)
                .WithColumn("UpdatedOnUtc").AsDateTime2().WithDefaultValue(DateTime.Now);

            //Seed
            Insert.IntoTable(nameof(User)).Row(new { Username = "admin", Password = "admin", Role = "admin",  IsActive = 1, IsDeleted = 0 });
            Insert.IntoTable(nameof(User)).Row(new { Username = "customer", Password = "customer", Role = "customer",  IsActive = 1, IsDeleted = 0 });
            Insert.IntoTable(nameof(Product)).Row(new { SKU = "111111",  ProductName = "Product1", Description = "Description 1", Image1 = "1.jpg", Image2 = "1.jpg", IsActive = 1, IsDeleted = 0 });
            Insert.IntoTable(nameof(Product)).Row(new { SKU = "222222", ProductName = "Product2", Description = "Description 2", Image1 = "2.jpg", Image2 = "2.jpg", IsActive = 1, IsDeleted = 0 });
            Insert.IntoTable(nameof(Product)).Row(new { SKU = "333333", ProductName = "Product3", Description = "Description 3", Image1 = "3.jpg", Image2 = "3.jpg", IsActive = 1, IsDeleted = 0 });
            Insert.IntoTable(nameof(Product)).Row(new { SKU = "444444", ProductName = "Product4", Description = "Description 4", Image1 = "4.jpg", Image2 = "4.jpg", IsActive = 1, IsDeleted = 0 });
            Insert.IntoTable(nameof(Product)).Row(new { SKU = "555555", ProductName = "Product5", Description = "Description 5", Image1 = "5.jpg", Image2 = "5.jpg", IsActive = 1, IsDeleted = 0 });
            Insert.IntoTable(nameof(Product)).Row(new { SKU = "666666", ProductName = "Product6", Description = "Description 6", Image1 = "6.jpg", Image2 = "6.jpg", IsActive = 1, IsDeleted = 0 });
        }

        public override void Down()
        {
            Delete.Table(nameof(User));
            Delete.Table(nameof(Product));
        }
    }
}
