using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace HotelBot.Dialogs
{
    [Serializable]
    public class GreetingDialog : IDialog
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Hi I'm Bot");
            context.Wait(MesaageRecievedAsync);
        }

        public async Task MesaageRecievedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            var userName = String.Empty;
            var getName = false;

            context.UserData.TryGetValue<string>("Name", out userName);
            context.UserData.TryGetValue<bool>("GetName", out getName);

            if (getName)
            {
                userName = message.Text;
                context.UserData.SetValue("Name", userName);
                context.UserData.SetValue("GetName", false);
            }


            if (string.IsNullOrEmpty(userName))
            {
                await context.PostAsync("What is your Name?");
                context.UserData.SetValue<bool>("GetName", true);
            }
            else
            {
                await context.PostAsync(String.Format("HI {0}. How Can I Help you today?", userName));
            }
            context.Wait(MesaageRecievedAsync);
        }
    }
}