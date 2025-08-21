using System.Collections.Generic;
using UnityEngine;
using Assets;
using System.Linq;

namespace EstrutEdu
{
    public class Steel : MonoBehaviour
    {
        Transform go_alma;
        Transform go_aba1;
        Transform go_aba2;
        Mesh mesh;
        public float _height = 1;
        public SteelType _steeltype;

        public Point2D[] Section(float bf, float d, float tf, float tw, float dl, float h)
        {
            float radius = (h - dl) / 2;
            Point2D p0 = new Point2D(tw / 2000, d / 2000);
            Point2D p1 = new Point2D(bf / 2000, d / 2000);
            Point2D p2 = new Point2D(bf / 2000, (d / 2 - tf) / 1000);
            Point2D p3 = new Point2D((tw / 2 + radius) / 1000, (d / 2 - tf) / 1000);
            Point2D p4 = new Point2D(tw / 2000, (d / 2 - tf - radius) / 1000);
            List<Point2D> points = new List<Point2D>();
            points.AddRange(new Point2D[] { p0, p1, p2, p3, p4 });
            //points.AddRange(Transformation.MirrorY(new Point2D[] { p4, p3, p2, p1, p0 }));
            //points.AddRange(Transformation.MirrorXY(new Point2D[] { p0, p1, p2, p3, p4 }));
            //points.AddRange(Transformation.MirrorX(new Point2D[] { p4, p3, p2, p1, p0 }));
            return points.ToArray();
        }
        public float Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public enum SteelType
        {
            PERFIL_W150_x_130,
            PERFIL_W150_x_180,
            PERFIL_W200_x_150,
            PERFIL_W200_x_193,
            PERFIL_W200_x_225,
            PERFIL_W200_x_266,
            PERFIL_W200_x_313,
            PERFIL_W250_x_179,
            PERFIL_W250_x_223,
            PERFIL_W250_x_253,
            PERFIL_W250_x_284,
            PERFIL_W250_x_327,
            PERFIL_W250_x_385,
            PERFIL_W250_x_448,
            PERFIL_W310_x_210,
            PERFIL_W310_x_238,
            PERFIL_W310_x_283,
            PERFIL_W310_x_327,
            PERFIL_W310_x_387,
            PERFIL_W310_x_445,
            PERFIL_W310_x_520,
            PERFIL_W360_x_329,
            PERFIL_W360_x_390,
            PERFIL_W360_x_440,
            PERFIL_W360_x_510,
            PERFIL_W360_x_578,
            PERFIL_W360_x_640,
            PERFIL_W360_x_720,
            PERFIL_W360_x_790,
            PERFIL_W410_x_388,
            PERFIL_W410_x_461,
            PERFIL_W410_x_530,
            PERFIL_W410_x_600,
            PERFIL_W410_x_670,
            PERFIL_W410_x_750,
            PERFIL_W410_x_850,
            PERFIL_W460_x_520,
            PERFIL_W460_x_600,
            PERFIL_W460_x_680,
            PERFIL_W460_x_740,
            PERFIL_W460_x_820,
            PERFIL_W460_x_890,
            PERFIL_W530_x_660,
            PERFIL_W530_x_720,
            PERFIL_W530_x_740,
            PERFIL_W530_x_820,
            PERFIL_W530_x_850,
            PERFIL_W530_x_920,
            PERFIL_W610_x_1010,
            PERFIL_W610_x_1130,
            PERFIL_W610_x_1250,
            PERFIL_W610_x_1400,
            PERFIL_W610_x_1550,
            PERFIL_W610_x_1740,

        }
        public Dictionary<SteelType, float[]> _dimensions = new Dictionary<SteelType, float[]>()
    {
        { SteelType.PERFIL_W150_x_130, new float[6] { 148, 100, 118, 138, 4.3f, 4.9f } },
        { SteelType.PERFIL_W150_x_180, new float[6] { 153, 102, 119, 139, 5.8f, 7.1f } },
        { SteelType.PERFIL_W200_x_150, new float[6] { 200, 100, 170, 190, 4.3f, 5.2f } },
        { SteelType.PERFIL_W200_x_193, new float[6] { 203, 102, 170, 190, 5.8f, 6.5f } },
        { SteelType.PERFIL_W200_x_225, new float[6] { 206, 102, 170, 190, 6.2f, 8.0f } },
        { SteelType.PERFIL_W200_x_266, new float[6] { 207, 133, 170, 190, 5.8f, 8.4f } },
        { SteelType.PERFIL_W200_x_313, new float[6] { 210, 134, 170, 190, 6.4f, 10.2f } },
        { SteelType.PERFIL_W250_x_179, new float[6] { 251, 101, 220, 240, 4.8f, 5.3f } },
        { SteelType.PERFIL_W250_x_223, new float[6] { 254, 102, 220, 240, 5.8f, 6.9f } },
        { SteelType.PERFIL_W250_x_253, new float[6] { 257, 102, 220, 240, 6.1f, 8.4f } },
        { SteelType.PERFIL_W250_x_284, new float[6] { 260, 102, 220, 240, 6.4f, 10.0f } },
        { SteelType.PERFIL_W250_x_327, new float[6] { 258, 146, 220, 240, 6.1f, 9.1f } },
        { SteelType.PERFIL_W250_x_385, new float[6] { 262, 147, 220, 240, 6.6f, 11.2f } },
        { SteelType.PERFIL_W250_x_448, new float[6] { 266, 148, 220, 240, 7.6f, 13.0f } },
        { SteelType.PERFIL_W310_x_210, new float[6] { 303, 101, 272, 292, 5.1f, 5.7f } },
        { SteelType.PERFIL_W310_x_238, new float[6] { 305, 101, 272, 292, 5.6f, 6.7f } },
        { SteelType.PERFIL_W310_x_283, new float[6] { 309, 102, 271, 291, 6.0f, 8.9f } },
        { SteelType.PERFIL_W310_x_327, new float[6] { 313, 102, 271, 291, 6.6f, 10.8f } },
        { SteelType.PERFIL_W310_x_387, new float[6] { 310, 165, 271, 291, 5.8f, 9.7f } },
        { SteelType.PERFIL_W310_x_445, new float[6] { 313, 166, 271, 291, 6.6f, 11.2f } },
        { SteelType.PERFIL_W310_x_520, new float[6] { 317, 167, 271, 291, 7.6f, 13.2f } },
        { SteelType.PERFIL_W360_x_329, new float[6] { 349, 127, 308, 332, 5.8f, 8.5f } },
        { SteelType.PERFIL_W360_x_390, new float[6] { 353, 128, 308, 332, 6.5f, 10.7f } },
        { SteelType.PERFIL_W360_x_440, new float[6] { 352, 171, 308, 332, 6.9f, 9.8f } },
        { SteelType.PERFIL_W360_x_510, new float[6] { 355, 171, 308, 332, 7.2f, 11.6f } },
        { SteelType.PERFIL_W360_x_578, new float[6] { 358, 172, 308, 332, 7.9f, 13.1f } },
        { SteelType.PERFIL_W360_x_640, new float[6] { 347, 203, 288, 320, 7.7f, 13.5f } },
        { SteelType.PERFIL_W360_x_720, new float[6] { 350, 204, 288, 320, 8.6f, 15.1f } },
        { SteelType.PERFIL_W360_x_790, new float[6] { 354, 205, 288, 320, 9.4f, 16.8f } },
        { SteelType.PERFIL_W410_x_388, new float[6] { 399, 140, 357, 381, 6.4f, 8.8f } },
        { SteelType.PERFIL_W410_x_461, new float[6] { 403, 140, 357, 381, 7.0f, 11.2f } },
        { SteelType.PERFIL_W410_x_530, new float[6] { 403, 177, 357, 381, 7.5f, 10.9f } },
        { SteelType.PERFIL_W410_x_600, new float[6] { 407, 178, 357, 381, 7.7f, 12.8f } },
        { SteelType.PERFIL_W410_x_670, new float[6] { 410, 179, 357, 381, 8.8f, 14.4f } },
        { SteelType.PERFIL_W410_x_750, new float[6] { 413, 180, 357, 381, 9.7f, 16.0f } },
        { SteelType.PERFIL_W410_x_850, new float[6] { 417, 181, 357, 381, 10.9f, 18.2f } },
        { SteelType.PERFIL_W460_x_520, new float[6] { 450, 152, 404, 428, 7.6f, 10.8f } },
        { SteelType.PERFIL_W460_x_600, new float[6] { 455, 153, 404, 428, 8.0f, 13.3f } },
        { SteelType.PERFIL_W460_x_680, new float[6] { 459, 154, 404, 428, 9.1f, 15.4f } },
        { SteelType.PERFIL_W460_x_740, new float[6] { 457, 190, 404, 428, 9.0f, 14.5f } },
        { SteelType.PERFIL_W460_x_820, new float[6] { 460, 191, 404, 428, 9.9f, 16.0f } },
        { SteelType.PERFIL_W460_x_890, new float[6] { 463, 192, 404, 428, 10.5f, 17.7f } },
        { SteelType.PERFIL_W530_x_660, new float[6] { 525, 165, 478, 502, 8.9f, 11.4f } },
        { SteelType.PERFIL_W530_x_720, new float[6] { 524, 207, 478, 502, 9.0f, 10.9f } },
        { SteelType.PERFIL_W530_x_740, new float[6] { 529, 166, 478, 502, 9.7f, 13.6f } },
        { SteelType.PERFIL_W530_x_820, new float[6] { 528, 209, 477, 502, 9.5f, 13.3f } },
        { SteelType.PERFIL_W530_x_850, new float[6] { 535, 166, 478, 502, 10.3f, 16.5f } },
        { SteelType.PERFIL_W530_x_920, new float[6] { 533, 209, 478, 502, 10.2f, 15.6f } },
        { SteelType.PERFIL_W610_x_1010,new float[6] { 603, 228, 541, 573, 10.5f, 14.9f } },
        { SteelType.PERFIL_W610_x_1130,new float[6] { 608, 228, 541, 573, 11.2f, 17.3f } },
        { SteelType.PERFIL_W610_x_1250,new float[6] { 612, 229, 541, 573, 11.9f, 19.6f } },
        { SteelType.PERFIL_W610_x_1400,new float[6] { 617, 230, 541, 573, 13.1f, 22.2f } },
        { SteelType.PERFIL_W610_x_1550,new float[6] { 611, 324, 541, 573, 12.7f, 19.0f } },
        { SteelType.PERFIL_W610_x_1740,new float[6] { 616, 325, 541, 573, 14.0f, 21.6f } },
    };
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //Mesh m = new Mesh();
            //m.name = "viga t";
            //List<Vector3> vertices = new List<Vector3> { };
            //List<int> triangles = new List<int> { };
            //for (float i = -0.5f; i <= 0.5f; i+= 0.1f)
            //{
            //    section()
            //    if (i > -0.5f)
            //    {
            //        triangles.Add(vertices.Count - 4);
            //        triangles.Add(vertices.Count - 1);
            //        triangles.Add(vertices.Count - 2);
            //        triangles.Add(vertices.Count - 4);
            //        triangles.Add(vertices.Count - 3);
            //        triangles.Add(vertices.Count - 1);
            //    }
            //}

            //m.vertices = vertices.ToArray();

            //m.triangles = triangles.ToArray();
            mesh = new Mesh();
            go_alma = gameObject.transform.GetChild(0);
            go_aba1 = gameObject.transform.GetChild(1);
            go_aba2 = gameObject.transform.GetChild(2);
            //go_alma.GetComponent<MeshFilter>().mesh = mesh;
        }

        // Update is called once per frame
        void Update()
        {
            float[] d = _dimensions[_steeltype];
            //mesh.vertices = section(d[1], d[0], d[5], d[4], d[2], d[3]).ToVector3();
            //mesh.triangles = new int[] { 0, 1, 15, 0, 1, 14};
            go_alma.transform.localScale = new Vector3(d[4] / 1000, 1, (d[0] - d[5]) / 1000);
            go_aba1.transform.localScale = new Vector3(d[1] / 1000, 1, d[5] / 1000);
            go_aba2.transform.localScale = new Vector3(d[1] / 1000, 1, d[5] / 1000);
            go_aba1.transform.localPosition = new Vector3(0, 0, (d[0] - d[5]) / 2000);
            go_aba2.transform.localPosition = new Vector3(0, 0, -(d[0] - d[5]) / 2000);
        }
    }
}
