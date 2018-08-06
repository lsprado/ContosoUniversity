using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace ContosoUniversity.XUnitTest
{
    public class DepartamentsTest : TestFixture
    {
        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetDepartments()
        {
            var response = await _client.GetAsync("api/Departments");
            string content = await response.Content.ReadAsStringAsync();
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetDepartmentById()
        {
            var response = await _client.GetAsync("api/Departments/1");
            string content = await response.Content.ReadAsStringAsync();
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}