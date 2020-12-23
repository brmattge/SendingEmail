using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SendingEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o e-mail do remetente;");
            string emailRemetente = Console.ReadLine();

            Console.WriteLine("Digite a senha do remetente:");
            string senhaRemetente = Console.ReadLine();

            Console.WriteLine("Digite o e-mail do destinatário:");
            string emailDestinatario = Console.ReadLine();

            Console.WriteLine("Digite o assunto do e-mail:");
            string assunto = Console.ReadLine();

            Console.WriteLine("Digite a mensagem:");
            string corpo = Console.ReadLine();

            Console.WriteLine("Aperte ENTER para enviar seu e-mail");
            Console.ReadLine();

            try
            {
                MailMessage mailMessage = new MailMessage(emailRemetente, emailDestinatario);

                mailMessage.Subject = $"{assunto}";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = $"<p> {corpo} </p>";
                mailMessage.SubjectEncoding = Encoding.GetEncoding("UTF-8");
                mailMessage.BodyEncoding = Encoding.GetEncoding("UTF-8");

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailRemetente, senhaRemetente);
                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMessage);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Seu e-mail foi enviado.");
                Console.ResetColor();
                Console.ReadLine();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Houve um erro no envio do e-mail.");
                Console.ResetColor();
                Console.ReadLine();
            }
        }
    }
}
