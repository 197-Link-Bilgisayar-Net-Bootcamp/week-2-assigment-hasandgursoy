using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSOLID.SingleResponsibilityPrinciple
{
    // SRP'ye göre her sınıf veya method tek bir görevi ve sorumluluğu olmalı 
    // Aşşağıdaki product sınıfı hem product yaratıyor hemde DataBase işlemleri gerçekleştiriyor.
    // Olması gereken DataBase işlemleri için ayrı bir sınıf tanımlanmalı.


    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }


        public void CreateProduct(Product product)
        {

            Console.WriteLine("Product yaratıldı.");

        }

        // Solid'e göre bu method'un başka bir sınıfta tanımlanması lazım.
        public void DeleteAllDBDatas()
        {
            Console.WriteLine("Bütün veriler silindi");
        }


    }

    // Olması gereken 

    public class DbOperations
    {
        public void DeleteAllDBDatas()
        {
            Console.WriteLine("Bütün veriler silindi");
        }
    }
}
