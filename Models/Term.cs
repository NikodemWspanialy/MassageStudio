using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MassageStudio.App.Models
{
    public class Term
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public DateTime SetUpDate { get; set; } = DateTime.Now;
        public bool Reserved { get; set; } = false;

        public Massage massage { get; set; } 
    }
}
