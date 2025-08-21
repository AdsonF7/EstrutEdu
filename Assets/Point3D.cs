using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstrutEdu
{
    public class Point3D : Geometry
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public Point3D(float X, float Y, float Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public override Geometry MirrorX()
        {
            return new Point3D(-X, Y, Z);
        }

        public override Geometry MirrorY()
        {
            return new Point3D(X, -Y, Z);
        }

        public override Geometry MirrorXY()
        {
            return new Point3D(-X, -Y, Z);
        }

        public bool Equal(Point3D point)
        {
            return (this.X == point.X && this.Y == point.Y && this.Z == point.Z) ? true : false;

        }
    }
}
