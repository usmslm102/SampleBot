using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBot.Models
{
    [Serializable]
    public class RoomReservation
    {
        public static IForm<RoomReservation> BuidForm()
        {
            return new FormBuilder<RoomReservation>()
                .Message("Welcome to the hotel Reservatio Bot!")
                .Build();

            
        }
    }
}