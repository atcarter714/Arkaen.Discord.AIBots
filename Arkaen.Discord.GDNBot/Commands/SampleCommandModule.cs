using Discord.Commands;
using System.Threading.Tasks;

namespace Discord.NetBot1.Commands
{
	public class SampleCommandModule : ModuleBase<SocketCommandContext>
	{
		[Command( "ping" )]
		public Task PongAsync()
		{
			return base.ReplyAsync( "Pong!" );
		}
	}
}