using System.ComponentModel.DataAnnotations;

namespace WebPage.Models
{
    public class UserTicketModel
    {
        [StringLength(255, MinimumLength = 3)]
        public string UserEmail { get; set; }

        [StringLength(255, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
