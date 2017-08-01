using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.FormFlow.Advanced;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBot.Models
{
    public enum BedSizeOption
    {
        King,
        Queen,
        Single,
        Double
    }

    public enum AmenitiesOptions
    {
        Kitchen,
        ExtraTowels,
        GymAccess,
        Wifi
    }
    [Serializable]
    public class RoomReservation
    {
        public BedSizeOption? BedSize;
        public int? NumberOfOccupants;
        public DateTime? CheckInDate;
        public int? NumberOfDaysToStay;
        public List<AmenitiesOptions> Amenities;
        public static IForm<RoomReservation> BuidForm()
        {
            return new FormBuilder<RoomReservation>()
                .Message("Welcome to the hotel Reservatio Bot!")
                .Field(nameof(NumberOfOccupants))
                .Field(new FieldReflector<RoomReservation>(nameof(Amenities))
                .SetActive(x => x.NumberOfOccupants == 5))
                .AddRemainingFields()
                .Confirm("Confirm {*}")
                .Build();

        }
    }
}