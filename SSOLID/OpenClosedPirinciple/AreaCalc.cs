using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSOLID.OpenClosedPirinciple
{
    public interface AreaCalculator
    {
        public double Area();


    }

    public class Rectangle : AreaCalculator
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Area()
        {
            return Width * Height;
        }
    }

    public class Circle : AreaCalculator
    {
        public double Radius { get; set; }
        public double PI { get; set; }
        public double Area()
        {
            return Radius * Radius * PI;
        }
    }
}
