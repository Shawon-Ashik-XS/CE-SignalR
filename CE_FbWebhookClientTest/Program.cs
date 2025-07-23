using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace CE_FbWebhookClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var connecntion = new HubConnectionBuilder().WithUrl("https://86def3b7.ngrok.io/webhookHub").Build();
            connecntion.StartAsync().Wait();
            connecntion.InvokeCoreAsync("SendMessage", args: new[] { "shawon", "Send message 1!" });
            connecntion.On("ReceiveMessage", (string userName, string message) =>
            {
                Console.WriteLine(userName + ':' + message);
            });
            Console.ReadKey();
        }
    }
}
