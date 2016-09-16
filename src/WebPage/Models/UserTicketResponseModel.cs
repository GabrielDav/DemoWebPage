using System;
using System.ComponentModel.DataAnnotations;

namespace WebPage.Models
{
    public class UserTicketResponseModel
    {
        public string UserEmail { get; set; }
        
        public string UserName { get; set; }
        
        public string Message { get; set; }

        public DateTime Time { get; set; }
    }
}
