﻿using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace LearningCSharp
{
    public class Init
    {
        public static async Task Main(string[] args)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            Demonstrator.RunDemonstrations();
            var builder = new HostBuilder();
            builder.ConfigureAppConfiguration(configurationBuilder => { });

            await builder.RunConsoleAsync(token);
        }
    }
}