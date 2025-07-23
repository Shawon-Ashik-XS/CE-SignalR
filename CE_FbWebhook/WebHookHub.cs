using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CE_FbWebhook
{
    public class WebHookHub : Hub
    {
        //public WebHookHub()
        //{

        //}

        void Main(string[] args)
        {
            string v = Webhook("", "", "");
        }

        [HttpGet]
        public string Webhook([FromQuery(Name = "hub.mode")] string mode, [FromQuery(Name = "hub.challenge")] string challenge, [FromQuery(Name = "hub.verify_token")] string verify_token)
        {
            if (mode.Equals("subscribe") && verify_token.Equals("hello"))
            {
                return challenge;
            }
            return "";

        }


        public async Task SendMessage(string userName, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", userName, message);
        }

        //public Task SendMessageToCaller(string message)
        //{
        //    return Clients.Caller.SendAsync("ReceiveMessage", message);
        //}

        //public Task SendMessageToGroup(string message)
        //{
        //    return Clients.Group("SignalR Users").SendAsync("ReceiveMessage", message);
        //}
    }
}
