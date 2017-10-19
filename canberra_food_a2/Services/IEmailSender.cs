using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace canberra_food_a2.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
