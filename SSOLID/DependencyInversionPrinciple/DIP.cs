using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSOLID.DependencyInversionPrinciple
{
    public class DIP
    {
        // Üstseviye Sınıflar > Soyutlama Katmanı > Alt Seviye Sınıflar
        // DIP'e göre Ust seviye sınıflar ile alt seviye sınıflar arasında tightly coupled olmaması gerekiyor.
        // Notification örneği üzerinden ilerleyim. (SMS ve Email)


        // ilk önce yanlış örneğe bakalım

        public class Email
        {
            public void sendEmail()
            {
                // email gönderildi
            }
        }

        public class SMS
        {
            public void sendSMS()
            {
                // SMS
            }
        }


        public class Notification
        {
            private Email email = new Email();
            private SMS sms = new SMS();

            public void messageSender()
            {
                email.sendEmail();
                sms.sendSMS();
            }
        }


        // Kötü gözükmemesine rağmen kötü bir yapılanma kurduk çünkü yapacağımız en ufak değişiklik Notification sınıfının yapısını değişterecek.
        // Bu durum Dependency Inversion 'ın ihlalidir.

        // Şimdi doğru uygulanma şekline bakalım.

        public interface IMessage
        {
            void sendMessage();

        }

        public class Emails : IMessage
        {
            public void sendMessage()
            {
                Console.WriteLine("Email gönderildi.");
            }
        }

        public class SMSs : IMessage
        {
            public void sendMessage()
            {
                Console.WriteLine("Sms gönderildi.");
            }
        }

        // Yaptığımız bu işlem sayesinde Üst sınıfı alt sınıfın bağımlılıklarından kurtardık.


    }
}
