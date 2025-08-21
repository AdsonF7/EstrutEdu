using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstrutEdu
{
    public class Face : Geometry
    {
   
        public Point3D[] GetPoints { get; private set; }
        private Point3D p1;
        private Point3D p2;
        private Point3D p3;
        private Point3D p4;

        public float Area
        { get
            {
                if (GetPoints.Length == 4) return GetArea(this.p1, this.p3, this.p2) + GetArea(this.p1, this.p3, this.p4);
                return GetArea(this.p1, this.p2, this.p3);
            }
        }

        public Face(Point3D p1, Point3D p2, Point3D p3)
        {
            GetPoints = new Point3D[3];
            GetPoints[0] = p1;
            GetPoints[1] = p2;
            GetPoints[2] = p3;
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }

        public Face(Point3D p1, Point3D p2, Point3D p3, Point3D p4)
        {
            GetPoints = new Point3D[4];
            GetPoints[0] = p1;
            GetPoints[1] = p2;
            GetPoints[2] = p3;
            GetPoints[3] = p4;
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
        }

        public Face[] QuadsToTris()
        {
            if (GetPoints.Length == 4)
            {
                float a1 = Math.Abs(GetArea(this.p1, this.p3, this.p2) - GetArea(this.p1, this.p3, this.p4));
                float a2 = Math.Abs(GetArea(this.p2, this.p4, this.p1) - GetArea(this.p2, this.p4, this.p3));
                if (a1 < a2) return new Face[2] { new Face(this.p1, this.p3, this.p2), new Face(this.p1, this.p3, this.p4) };
                return new Face[2] { new Face(this.p2, this.p4, this.p1), new Face(this.p2, this.p4, this.p3) };
            }
            return new Face[1] { new Face(p1, p2, p3) };
        }

        
        
        public static float GetArea(Point3D p1, Point3D p2, Point3D p3)
        {
            float d1 = p1.X * p2.Y * p3.Z;
            float d2 = p1.Y * p2.Z * p3.X;
            float d3 = p1.Z * p2.X * p3.Y;
            float d4 = p1.Z * p2.Y * p3.X;
            float d5 = p1.X * p2.Z * p3.Y;
            float d6 = p1.Y * p2.X * p3.Z;
            float area = (d1 + d2 + d3 - (d4 + d5 + d6)) / 2;
            return area;
        }
    }
}
