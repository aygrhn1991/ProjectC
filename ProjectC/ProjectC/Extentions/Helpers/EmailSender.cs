using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ProjectC.Extentions.Helpers
{
    public class EmailSender
    {
        public static string SendMail(string destinationAddress, string subject, string body)
        {
            string startAddress = "411610370@qq.com";
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(startAddress);
            mailMessage.To.Add(new MailAddress(destinationAddress));
            mailMessage.Subject = subject;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.Body = body;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.qq.com";
            smtpClient.Port = 25;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new System.Net.NetworkCredential(startAddress, "qrhknrhqdmezcaci");
            smtpClient.EnableSsl = true;//SMTP 服务器要求安全连接需要设置此属性
            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "success";
        }
    }
}