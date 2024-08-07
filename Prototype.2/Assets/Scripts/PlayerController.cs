using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 10.0f;
    private float xRange = 10.0f;
    public GameObject  projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Limits the player movement according to map size
        if(transform.position.x < -xRange){
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if(transform.position.x > xRange){
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Moves the player horizontally depending on input
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        // Shoots a pizza on space bar
        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
