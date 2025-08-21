using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstrutEdu
{
    public class Geometry
    {
        public virtual Geometry MirrorX() { throw new NotImplementedException(); }
        public virtual Geometry MirrorY() { throw new NotImplementedException(); }
        public virtual Geometry MirrorXY() { throw new NotImplementedException(); }


        //public List<Geometry> ToList(Geometry[] geometry)
        //{
        //    return geometry.ToList();
        //}
    }
}
