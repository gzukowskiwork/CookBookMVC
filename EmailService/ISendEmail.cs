using EmailService;
using System.Threading.Tasks;

namespace EmailLib
{
    public interface ISendEmail
    {
        Task SendEmailAsync(Message message);
    }
}
