using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SoutienScolaireV1.Azure.Models;
using System;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

[assembly: FunctionsStartup(typeof(SoutienScolaire.Azure.StartUp))]

namespace SoutienScolaire.Azure
{
    public class StartUp : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string applicationDB = Environment.GetEnvironmentVariable("ApplicationDB");
            builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlite(applicationDB));
        }
    }
}
