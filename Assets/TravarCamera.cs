using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Camera cam; // arrasta a MainCamera aqui (ou pega no Start)

    void Start()
    {
        if (cam == null)
            cam = Camera.main;
    }

    void LateUpdate()
    {
        Vector3 dir = transform.position - cam.transform.position;
        dir.y = 0; // trava no eixo Y
        transform.rotation = Quaternion.LookRotation(dir);
    }
}