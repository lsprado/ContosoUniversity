﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ContosoUniversity.XUnitTest
{
    public class TestFixture : IDisposable
    {
        protected readonly TestServer _server;
        protected readonly HttpClient _client;

        public TestFixture()
        {
            // To avoid hardcoding path to project, see: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing#integration-testing
            var integrationTestsPath = PlatformServices.Default.Application.ApplicationBasePath; // integration_tests/bin/Debug/netcoreapp2.0
            var applicationPath = Path.GetFullPath(Path.Combine(integrationTestsPath, "../../../../ContosoUniversity.API"));

            _server = new TestServer(WebHost.CreateDefaultBuilder()
                //.UseStartup<ContosoUniversity.API.Startup>()
                .UseStartup<TestStartup>()
                .UseContentRoot(applicationPath)
                .UseEnvironment("Development"));
                
            _client = _server.CreateClient();
        }

        public void Dispose()
        {
            _client.Dispose();
            _server.Dispose();
        }
    }
}
