using System;

namespace FiguresLib
{
    public abstract class Figures
    {
        protected short SideCount { get; set; }
        protected short[] SideSizes { get; set; }
        public abstract string Squared();
        protected abstract double SquaredMath();
    }

    public class Figure : Figures
    {
        public Figure(short count, short[] sizes)
        {
                SideCount = count;
                SideSizes = sizes;
        }
        protected bool CheckSides(short count, short[] sizes) => ((sizes.Length != count) && !((sizes.Length == 1) && (count == 0))) ? false : true;
        override public string Squared() => (CheckSides(SideCount, SideSizes)) ?
            string.Format("{0}", SquaredMath()) :
            "Wrong input for SideSizes!";
        override protected double SquaredMath() => 0.0;
    }

    public class Circle : Figure
    {
        public Circle(short count, short[] sizes) : base(0, sizes) { }
        override protected double SquaredMath() => Math.PI * SideSizes[0] * SideSizes[0];
    }

    public class Triangle : Figure
    {
        public Triangle(short count, short[] sizes) : base(3, sizes) { }
        override protected double SquaredMath() => Math.Sqrt((SideSizes[0] + SideSizes[1] - SideSizes[2]) * (SideSizes[0] - SideSizes[1] + SideSizes[2]) * (SideSizes[1] + SideSizes[2] - SideSizes[0]) * (SideSizes[0] + SideSizes[1] + SideSizes[2])) / 4;
    }
}
