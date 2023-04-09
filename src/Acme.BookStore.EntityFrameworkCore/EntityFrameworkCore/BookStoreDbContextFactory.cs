using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Acme.BookStore.EntityFrameworkCore;

/* 这个类需要EF Core控制台命令
 * (like Add-Migration and Update-Database commands) */
/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class BookStoreDbContextFactory : IDesignTimeDbContextFactory<BookStoreDbContext>
{
    public BookStoreDbContext CreateDbContext(string[] args)
    {
        BookStoreEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<BookStoreDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new BookStoreDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Acme.BookStore.DbMigrator/"))
            .AddJsonFile($"appsettings.json", optional: false)
            .AddJsonFile($"appsettings.secrets.json", optional: false);
        return builder.Build();
    }
}
