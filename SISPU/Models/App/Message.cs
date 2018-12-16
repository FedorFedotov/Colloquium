using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISPU.Models
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class Message
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public GroupChat Chat { get; set; }

        public User User { get; set; }

        public DateTime Date { get; set; }

        public bool IsDeleted { get; set; }

        public Message()
        {
            IsDeleted = false;
        }

    }
}
