﻿using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Bot.Builder.FormFlow;
using HotelBot.Models;

namespace HotelBot.Dialogs
{
    [Serializable]
    public class HotelBotDialog
    {
        public static readonly IDialog<string> dialog = Chain.PostToChain()
             .Select(msg => msg.Text)
             .Switch(
            new RegexCase<IDialog<string>>(new Regex("^hi", RegexOptions.IgnoreCase), (context, text) =>
              {
                  return Chain.ContinueWith(new GreetingDialog(), AfterGreetingContinuation);
              }),
            new DefaultCase<string, IDialog<string>>((context, text) =>
             {
                 return Chain.ContinueWith(FormDialog.FromForm(RoomReservation.BuidForm, FormOptions.PromptInStart), AfterGreetingContinuation);
             }))
            .Unwrap()
            .PostToUser();
            

        private async static Task<IDialog<string>> AfterGreetingContinuation(IBotContext context, IAwaitable<object> item)
        {
            var token = await item;
            var name = "User";
            context.UserData.TryGetValue<string>("Name", out name);

            return Chain.Return($"Thanks you for using the hotel bot: {name}");
        }
    }
}