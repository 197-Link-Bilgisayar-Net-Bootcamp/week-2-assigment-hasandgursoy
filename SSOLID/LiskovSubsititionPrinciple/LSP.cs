using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSOLID.LiskovSubsititionPrinciple
{
    public class LSP
    {
        // Her iki tarafda da geçerli olan Subscriber özellikleri
        public class BaseSubscriber
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        // Her iki tarafdada geçerli olan subscribe login methodu
        public interface ISubscribeLoginner
        {

            public void Login();

        }

        // Miras alınan her sınıfın ve interface'in özellileri tam olarak gerekliydi.
        public class StandartSubscriber : BaseSubscriber, ISubscribeLoginner
        {
            public void Login()
            {
                Console.WriteLine($"{Name}");
                Console.WriteLine($"{Email}");
                Console.WriteLine($"{Password}");

                Console.WriteLine("Standart üyeliğinize hoş geldiniz.");
            }
        }

        // Miras alınan her sınıfın ve interface'in özellileri tam olarak gerekliydi.
        public class PremiumSubscriber : BaseSubscriber, ISubscribeLoginner
        {
            public string PremiumKey { get; set; }

            public PremiumSubscriber(string premiumKey)
            {
                PremiumKey = premiumKey;
            }

            public void Login()
            {
                Console.WriteLine($"{Name}");
                Console.WriteLine($"{Email}");
                Console.WriteLine($"{Password}");


                if (PremiumKey is not null)
                {
                    Console.WriteLine("Premium üyeliğinize hoş geldiniz.");
                }
            }


        }

    }
}
