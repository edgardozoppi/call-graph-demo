using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Chat
{
	class Client
	{
		private Server server;
		private IList<string> messages;

		public Client()
		{
			messages = new List<string>();
			this.Id = Guid.NewGuid();			
		}

		public Guid Id { get; private set; }

		public async Task<MessageResult> ConnectAsync(Server server)
		{
			var result = await server.AcceptAsync(this);
			this.server = server;
			return result;
		}

		public async Task<MessageResult> SendAsync(string message)
		{
			var result = await server.ReceiveAsync(this.Id, message);
			return result;
		}

		public async Task<MessageResult> ReceiveAsync(string message)
		{
			await Task.Delay(3);
			messages.Add($"Server: {message}");

			var result = new SuccessMessageResult();
			return result;
		}
	}
}
