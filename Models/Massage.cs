using MassageStudio.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MassageStudio.App.Models
{
    public class Massage
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public DateTime SetUpDate { get; set; } = DateTime.Now;
        public User User { get; set; }
        public string UserId { get; set; }
        public Term term { get; set; }
        public int termId { get; set; }
    }
}
