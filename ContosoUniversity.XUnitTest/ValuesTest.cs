using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ContosoUniversity.XUnitTest
{
    public class ValuesTest : TestFixture
    {
        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetValues()
        {
            var response = await _client.GetAsync("api/values");
            string content = await response.Content.ReadAsStringAsync();
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}