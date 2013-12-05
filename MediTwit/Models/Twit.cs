using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediTwit.Models
{
    public class Twit
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        public string TwitContent { get; set; }

        public DateTime CreatedAt { get; set; }

    }

}