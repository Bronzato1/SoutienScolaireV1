using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SoutienScolaireV1.Azure.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

[assembly: FunctionsStartup(typeof(SoutienScolaire.Azure.StartUp))]

namespace SoutienScolaire.Azure
{
    public class StartUp : FunctionsStartup
    {
        string local_DB_path;
        string azure_DB_path;
        string executionRoot;

        public void CopyDB() 
        {
            var locked_DB_path = Path.Combine(executionRoot, local_DB_path); // to avoid 'dabatase is locked' we copy the DB to the root
            File.Copy(locked_DB_path, azure_DB_path); // C:\\home\\site\\wwwroot\\Data\\database.db ==> D:\\home\\database.db  (C drive is same as D drive)
            File.SetAttributes(azure_DB_path, FileAttributes.Normal);
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {            
            bool isDevEnv = Environment.GetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT") == "Development" ? true : false;
            executionRoot = Environment.GetEnvironmentVariable("HOME") + "\\site\\wwwroot"; // where the azure function is running
            local_DB_path = Environment.GetEnvironmentVariable("local_DB_path"); // found in local.settings.json for development - Data\\database.db
            azure_DB_path = Environment.GetEnvironmentVariable("azure_DB_path"); // found in azure portal  environment variables - D:\\home\\database.db

            // One time copy of the DB (per deployment)
            if (!isDevEnv && !File.Exists(azure_DB_path)) CopyDB();

            builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlite($"Data Source={(isDevEnv ? local_DB_path : azure_DB_path)}"));
        }
    }
}
