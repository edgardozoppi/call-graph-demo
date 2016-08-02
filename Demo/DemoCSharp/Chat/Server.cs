using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Chat
{
	abstract class MessageResult
	{
		public abstract int Status { get; }

		public override string ToString()
		{
			return $"Message result status: {this.Status}";
		}
	}

	class SuccessMessageResult : MessageResult
	{
		public override int Status
		{
			get { return 0; }
		}

		public override string ToString()
		{
			return $"Success message result status: {this.Status}";
		}
	}

	class ErrorMessageResult : MessageResult
	{
		public override int Status
		{
			get { return -1; }
		}

		public override string ToString()
		{
			return $"Error message result status: {this.Status}";
		}
	}

	class Server
	{
		private IDictionary<Guid, Client> clients;
		private IList<string> messages;

		public Server()
		{
			clients = new Dictionary<Guid, Client>();
			messages = new List<string>();
		}

		public Task<MessageResult> AcceptAsync(Client client)
		{
			clients.Add(client.Id, client);

			var result = new SuccessMessageResult();
			return Task.FromResult<MessageResult>(result);
		}

		public async Task<MessageResult> SendAsync(string message)
		{
			MessageResult result = new ErrorMessageResult();

			if (clients.Count > 0)
			{
				var tasks = new List<Task>();

				foreach (var client in clients.Values)
				{
					var task = client.ReceiveAsync(message);
					tasks.Add(task);
				}

				await Task.WhenAll(tasks);
				result = new SuccessMessageResult();
			}

			return result;
		}

		public async Task<MessageResult> ReceiveAsync(Guid clientId, string message)
		{
			await Task.Delay(3);
			messages.Add($"Client {clientId}: {message}");

			var result = new ErrorMessageResult();
			return result;
		}
	}
}
