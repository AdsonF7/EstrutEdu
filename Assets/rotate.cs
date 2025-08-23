using UnityEngine;

public class Rotate : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        gameObject.transform.Rotate(
            Vector3.up, 
            0.1f);
    }
}
