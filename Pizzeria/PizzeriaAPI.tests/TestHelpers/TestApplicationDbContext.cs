using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PizzeriaAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaAPI.tests.TestHelpers
{

        public class TestApplicationDbContext
        {
            public ApplicationDbContext? applicationDbContext;

            public TestApplicationDbContext()
            {
                //Creating new service provider each time prevents tests to use same InMemoryDatabase
                //So if new entry will be added during one test, it will not be seen by another test
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                var dbOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase("database")
                    .UseInternalServiceProvider(serviceProvider)
                    .EnableSensitiveDataLogging();

                applicationDbContext = new ApplicationDbContext(dbOptionsBuilder.Options);
            }

            public void Dispose()
            {
                applicationDbContext?.Dispose();
            }
        }
    }

