using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    
    void Start()
    {
        float redColor = Random.Range(0.0f, 1.0f);
        float greenColor = Random.Range(0.0f, 1.0f);
        float blueColor = Random.Range(0.0f, 1.0f);
        float alphaColor = Random.Range(0.0f, 1.0f);

        transform.localScale = Vector3.one * 2.0f;
        
        Material material = Renderer.material;
        
        material.color = new Color(redColor, greenColor, blueColor, alphaColor);

        InvokeRepeating("MoveCube", 1.0f, 1.0f);
    }
    
    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime, 2.0f, 0.0f);
    }

    void MoveCube()
    {
        float xPos = Random.Range(0.0f, 5.0f);
        float yPos = Random.Range(0.0f, 5.0f);
        float zPos = Random.Range(0.0f, 5.0f);

        transform.position = new Vector3(xPos, yPos, zPos);
    }
}
