using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Discord.NetBot1.Services;
using System.Threading.Tasks;

namespace Discord.NetBot1
{
	internal sealed class Startup
	{
		static Task Main( string[] args )
		{
			var hostingTask = new HostBuilder()
							  .UseEnvironment( Environments.Production )
							  .ConfigureAppConfiguration( config =>
													      {
														      config
															      .AddEnvironmentVariables( prefix: "Discord.NetBot1_" )
															      // .AddJsonFile("config.json")
															      .AddCommandLine( args );
													      } )
							  .ConfigureDiscord( options =>
											     {
												     // Configure your DiscordSocketClient here, or keep the default settings.
											     } )
							  .ConfigureCommands( options =>
											      {
												      // Configure your CommandService here, or keep the default settings.
											      } )
							  .ConfigureServices( ( context, services ) =>
											      {
												      // Add services to your IOC container.
												      services.AddHostedService<DiscordBotService>();

												      // Event handler supplied as an example.
												      services.AddHostedService<SampleEventHandler>();
											      } )
							  .ConfigureLogging( ( context, logging ) =>
											     {
												     logging.ClearProviders();
												     logging.AddConsole();
												     logging.SetMinimumLevel( context.HostingEnvironment
																		          .EnvironmentName ==
																	          EnvironmentName.Development
																		          ? LogLevel.Debug
																		          : LogLevel.Information );
											     } )
							  .RunConsoleAsync();

			return hostingTask;
		}
	}
}