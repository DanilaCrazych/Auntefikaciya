using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;

namespace mail
{
    internal class OtpravkaIproverka
    {
        int code;
        public void otpravka()
        {

            Random random = new Random();
            int code = random.Next(1000, 999999);
            //Console.WriteLine(code);

            Console.WriteLine("Введите вашу почту: ");
            String mail = Console.ReadLine();

            MailAddress from = new MailAddress("mag7istr2206@yandex.ru", "Менеджер Антон");
            MailAddress to = new MailAddress(mail);
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Подтверждение почты";
            message.Body = "<h2>Ваш код подтверждения для регистрации: </h2>" + code.ToString();
            message.IsBodyHtml = true;


            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.yandex.ru";
            smtpClient.Port = 25;
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("mag7istr2206@yandex.ru", "22062004ddDD!");

            smtpClient.Send(message);

            Console.WriteLine("Код подтверждения отправлен!");
            proverka();
        }

        public void proverka()
        {
            while (true)
            {
                Console.WriteLine("Введите код: ");
                if (Console.ReadLine() == code.ToString())
                {
                    Console.WriteLine("Aунтефикация не пройдена! ");
                    otpravka();                  
                }
                else
                {
                    Console.WriteLine("Aунтефикация прошла успешно! ");
                    break;
                }
            }
        }

    }
}