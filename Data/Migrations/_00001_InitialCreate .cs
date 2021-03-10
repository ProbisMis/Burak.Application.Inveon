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
            //Seed
            //Insert.IntoTable(nameof(Country)).Row(new { CountryName = "Turkey", CountryIsoCode = "TR" });
            //Insert.IntoTable(nameof(Country)).Row(new { CountryName = "United States", CountryIsoCode = "US" });
            //Insert.IntoTable(nameof(Country)).Row(new { CountryName = "United Kingdom", CountryIsoCode = "UK" });

            Create.Table(nameof(User)) //Seed with sample users and give guid on documentation
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Username").AsString().Nullable()
                .WithColumn("Password").AsString().Nullable()
                .WithColumn("IsActive").AsBoolean().WithDefaultValue(true)
                .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false)
                .WithColumn("CreatedOnUtc").AsDateTime2().WithDefaultValue(DateTime.Now)
                .WithColumn("UpdatedOnUtc").AsDateTime2().WithDefaultValue(DateTime.Now);

            Insert.IntoTable(nameof(User)).Row(new { Username = "admin", Password = "admin", IsActive = 1, IsDeleted = 0 });
        }

        public override void Down()
        {
            Delete.Table(nameof(User));
        }
    }
}
