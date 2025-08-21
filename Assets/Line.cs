

namespace EstrutEdu
{
    public class Line : Geometry
    {
        public Point2D StartPoint { get; set; }
        public Point2D EndPoint { get; set; }

        public Line(Point2D startPoint, Point2D endPoint)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
        }

        public Point2D[] GetPoints()
        {
            return new Point2D[] { StartPoint, EndPoint };
        }

        public override Geometry MirrorX()
        {
            return this;
        }

        public override Geometry MirrorY()
        {
            return this;
        }

        public override Geometry MirrorXY()
        {
            return this;
        }
    }
}

