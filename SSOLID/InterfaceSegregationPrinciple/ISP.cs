using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSOLID.InterfaceSegregationPrinciple
{
    public class ISP
    {
        // Implemente edilen interfacelerin özelliklerini tam olarak kullanılması gekerekir.
        // Aksi durumda yanlış bir uygulamaya dönüşür.
        // Eğer uygulanan interface'in bazı methodları dışarıda kalıyorsa başka bir interface oluşturulmalı.

        // ilk önce yanlış bir uygulamaya bakalım

        public interface WrongProduct
        {
            public int Id { get; set; }
            public int Weight { get; set; }
            public int Stock { get; set; }
            public int Size { get; set; }


        }

        // Biz bu product interfacesini implemente ettik ancak korsan işletim sistemlerinin ağırlığı olmaz
        // Size'ı olmaz demekki doğru bir yol izlemememişiz.
        public class KorsanWindowsSurumu : WrongProduct
        {
            public int Id { get; set; }
            public int Weight { get; set; }
            public int Stock { get; set; }
            public int Size { get; set; }
        }

        // Doğru uygulanan örneğe geçelim.

        public interface IProduct
        {
            public int Id { get; set; }
            public int Stock { get; set; }
            public int Price { get; set; }
        }

        public interface IClothes
        {
            public int Size { get; set; }
            public string Color { get; set; }
            public string Model { get; set; }
        }


        // Aşşağıda görüldüğü gibi herşey yerli yerinde ve işlevsel dışarıda kalan tek bir özellikle bile yok.
        public class Shirt : IProduct, IClothes
        {
            public int Id { get; set; }
            public int Stock { get; set; }
            public int Price { get; set; }
            public int Size { get; set; }
            public string Color { get; set; }
            public string Model { get; set; }
        }

        public class IllegalWindowsKey : IProduct
        {
            public int Id { get; set; }
            public int Stock { get; set; }
            public int Price { get; set; }
        }


    }
}
