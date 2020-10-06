using EmailService;


namespace EmailLib
{
    public interface ISendEmail
    {
        void SendEmail(Message message);
    }
}
