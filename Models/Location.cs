﻿using System.ComponentModel.DataAnnotations;

namespace TicketBooking.Models
{
    public class Location
    {
        [Key]
        public int LocationID {  get; set; }

        public string LocationName { get; set; }
    }
}
