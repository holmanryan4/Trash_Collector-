using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [Display(Name = "Pickup Day")]
        public string PickupDay { get; set; }
        public double Balance { get; set; }

        [Display(Name = "Start Day")]
        public DateTime StartDay { get; set; }

        [Display(Name = "End Day")]
        public DateTime EndDay { get; set; }

        [Display(Name = "One Time Pickup")]
        public DateTime OneTimePickup { get; set; }

        [Display(Name = "Account Status")]
        public bool AccountStatus { get; set; }


    }
}
