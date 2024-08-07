using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Destroing objects when they leave the camera
        if(transform.position.z > topBound || transform.position.z < lowerBound){
            Destroy(gameObject);
        }
    }
}
