using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MediTwit.Models;

namespace MediTwit.ViewModel
{
    public class HomeIndexViewModel
    {
        [Display(Name = "Twit")]
        [Required]
        [StringLength(141)]
        public string TwitContent { get; set; }

        public IEnumerable<Twit> Twits { get; set; } 

    }

}