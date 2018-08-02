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
        //private readonly TestServer _server;
        //private readonly HttpClient _client;

        //public ValuesTest()
        //{
        //    _server = new TestServer(WebHost.CreateDefaultBuilder().UseStartup<ContosoUniversity.API.Startup>());
        //    _client = _server.CreateClient();
        //}

        [Fact]
        public async Task GetValues()
        {
            var response = await _client.GetAsync("api/values");
            string content = await response.Content.ReadAsStringAsync();
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}