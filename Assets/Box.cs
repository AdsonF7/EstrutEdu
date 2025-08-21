using UnityEngine;

namespace EstrutEdu
{
    public class Box
    {
        public float BaseSecao { get; set; }
        public float AlturaSecao { get; set; }
        public float Comprimento { get; set; }

        //static Mesh CriarMeshBox(
        //    float baseSecao,
        //    float alturaDivisao,
        //    float alturaSecao)
        //{
        //    Mesh mesh = new Mesh();
        //    Vector3[] vertices = new Vector3[8]
        //    {
        //        new Vector3(-baseSecao/2, 0, -alturaSecao/2),
        //        new Vector3(baseSecao/2, 0, -alturaSecao/2),
        //        new Vector3(baseSecao/2, 0, alturaSecao/2),
        //        new Vector3(-baseSecao/2, 0, alturaSecao/2),
        //        new Vector3(-baseSecao/2, alturaDivisao, -alturaSecao/2),
        //        new Vector3(baseSecao/2, alturaDivisao, -alturaSecao/2),
        //        new Vector3(baseSecao/2, alturaDivisao, alturaSecao/2),
        //        new Vector3(-baseSecao/2, alturaDivisao, alturaSecao/2)
        //    };

        //    int[] triangles = new int[]
        //    {
        //        0, 2, 1, 0, 3, 2, // Bottom
        //        4, 5, 6, 4, 6, 7, // Top
        //        3, 7, 6, 3, 6, 2, // Front
        //        0, 1, 5, 0, 5, 4, // Back
        //        0, 4, 7, 0, 7, 3, // Left
        //        1, 2, 6, 1, 6, 5 // Right
        //    };

        //    mesh.vertices = vertices;
        //    mesh.triangles = triangles;
        //    mesh.RecalculateNormals();
        //    return mesh;
        //}

    }
}
