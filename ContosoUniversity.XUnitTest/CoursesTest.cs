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
    public class CoursesTest : TestFixture
    {
        
        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetCourses()
        {
            var response = await _client.GetAsync("api/Courses");
            string content = await response.Content.ReadAsStringAsync();
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetCourseById()
        {
            var response = await _client.GetAsync("api/Courses/1");
            string content = await response.Content.ReadAsStringAsync();
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}