using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SoutienScolaireV1.Azure.Models;

string local_DB_path;
string azure_DB_path;
string executionRoot;

void CopyDB()
{
    var locked_DB_path = Path.Combine(executionRoot, local_DB_path); // to avoid 'dabatase is locked' we copy the DB to the root
    File.Copy(locked_DB_path, azure_DB_path); // C:\\home\\site\\wwwroot\\Data\\database.db ==> D:\\home\\database.db  (C drive is same as D drive)
    File.SetAttributes(azure_DB_path, FileAttributes.Normal);
}

bool isDevEnv = Environment.GetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT") == "Development" ? true : false;
executionRoot = Environment.GetEnvironmentVariable("HOME") + "\\site\\wwwroot"; // where the azure function is running
local_DB_path = Environment.GetEnvironmentVariable("local_DB_path"); // found in local.settings.json for development - Data\\database.db
azure_DB_path = Environment.GetEnvironmentVariable("azure_DB_path"); // found in azure portal  environment variables - D:\\home\\database.db

// One time copy of the DB (per deployment)
if (!isDevEnv && !File.Exists(azure_DB_path)) CopyDB();

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlite($"Data Source={(isDevEnv ? local_DB_path : azure_DB_path)}"));
    })
    .Build();

host.Run();
