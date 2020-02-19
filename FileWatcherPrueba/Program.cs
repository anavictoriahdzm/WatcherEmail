using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherPrueba
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher watcher = new FileSystemWatcher(@"C:\Users\Curso\Desktop\Test");

            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;

            //add event hanlders
            watcher.Renamed += watcher_Renamed;

            Console.Read(); //dont forget to stop the program at this line
        }

        private static void watcher_Renamed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("se enviara email");
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            mmsg.To.Add("annamls96@hotmail.com");
            mmsg.Subject = "Prueba VS";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            mmsg.Body = "Esto es una prueba 2";
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;
            mmsg.From = new System.Net.Mail.MailAddress("annavhm96@gmail.com");

            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            cliente.Credentials = new System.Net.NetworkCredential("annavhm96@gmail.com", "animls96");

            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com"; //en caso de estar usando otro dominio es mail.dominio.com

            try
            {
                cliente.Send(mmsg);
            }
            catch (Exception)
            {

                Console.WriteLine("Error");
            }
        }
    }
}
