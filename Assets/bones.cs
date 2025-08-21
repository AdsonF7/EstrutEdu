using UnityEngine;

public class bonesPhysics : MonoBehaviour
{
    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //float rot = 0f;
    //public Transform[] bones;
    //public float stiffness = 0.0000006f;

    //private Quaternion[] initialRotations;

    //void Start()
    //{
    //    initialRotations = new Quaternion[bones.Length];
    //    for (int i = 0; i < bones.Length; i++)
    //    {
    //        initialRotations[i] = bones[i].localRotation;
    //    }
    //}

    //void Update()
    //{
    //    for (int i = 1; i < bones.Length; i++)
    //    {
    //        Quaternion targetRotation = bones[i - 1].localRotation;
    //        bones[i].localRotation = Quaternion.Slerp(bones[i].localRotation, targetRotation, Time.deltaTime * stiffness);
    //    }
    //}
}
