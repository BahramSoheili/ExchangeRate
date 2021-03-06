using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Testing
{ 
    public class TestContext<TStartup>: IDisposable
        where TStartup : class
    {
        public HttpClient Client { get; private set; }

        private TestServer server;

        public TestContext()
        {
            SetUpClient();
        }

        private void SetUpClient()
        {
            var projectDir = Directory.GetCurrentDirectory();

            server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Tests")
                .UseContentRoot(projectDir)
                .UseConfiguration(new ConfigurationBuilder()
                    .SetBasePath(projectDir)
                    .AddJsonFile("appsettings.json", true)
                    .Build()
                )                
                .UseStartup<TStartup>());

            Client = server.CreateClient();
        }            
        public void Dispose()
        {
            server?.Dispose();
            Client?.Dispose();
        }
    }
}
