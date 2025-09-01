using UnityEngine;
using UnityEngine.UIElements;

class CameraControl : MonoBehaviour
{
    public void Start()
    {
        
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Mouse2))
        {
            GetComponent<Transform>().RotateAround(
                new Vector3(0, 0, 0),
                Vector3.up,
                2);
        }
    }
}