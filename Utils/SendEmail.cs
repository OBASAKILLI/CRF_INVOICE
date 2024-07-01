using System.Net.Mail;
using System.Net;

namespace ECAN_INVOICE.Utils
{
    public class EmailSendStatus
    {
        public bool status { get; set; }
        public string message { get; set; }
    }
    public class SendEmail
    {

        public Task<EmailSendStatus> ActivateAccount(string Subject, string Body, string to, string success_message)
        {
            EmailSendStatus status = new EmailSendStatus();
            try
            {
                string from = "emmanukiptoo98@gmail.com";
                string password = "dizu inwn qvow mxhq";

                SmtpClient client = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(from, password),
                    EnableSsl = true,
                };

                // Create and configure the email message
                MailMessage message = new MailMessage(from, to)
                {
                    Subject = Subject,
                    Body = Body,
                    IsBodyHtml = true
                };

                // Send the email
                client.Send(message);
                status = new EmailSendStatus
                {
                    message = success_message,//"Activation Link has been sent successfylly to your Email",
                    status = true
                };
                return Task.FromResult(status);
            }
            catch (Exception e)
            {
                status = new EmailSendStatus
                {
                    message = e.Message,// "Something went wrong..Please try again",
                    status = false
                };
                return Task.FromResult(status);
            }
        }




    }
}
