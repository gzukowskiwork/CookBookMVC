using EmailService;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailLib
{
    public interface ISendEmail
    {
        void SendEmail(Message message);
    }
}
