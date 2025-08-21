using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EstrutEdu
{
    public static class Point2DExpansion
    {
        public static Vector3[] ToVector3(this Point2D[] points)
        {
            Vector3[] result = new Vector3[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                result[i] = new Vector3(points[i].X, 0, points[i].Y);
            }
            return result;
        }
    }
    public class Point2D : Geometry
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point2D(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public override Geometry MirrorX()
        {
            return new Point2D(-X, Y);
        }

        public override Geometry MirrorY()
        {
            return new Point2D(X, -Y);
        }

        public override Geometry MirrorXY()
        {
            return new Point2D(-X, -Y);
        }

        public bool Equal(Point2D point)
        {
            return (this.X == point.X && this.Y == point.Y) ? true : false;
        }
    }
}
