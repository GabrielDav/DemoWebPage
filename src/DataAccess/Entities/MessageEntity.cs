using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    [Table("UserTicket")]
    public class UserTicketEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required, MaxLength(255)]
        public string Email { get; set; }
        
        [Required]
        public string Message { get; set; }
    }
}
