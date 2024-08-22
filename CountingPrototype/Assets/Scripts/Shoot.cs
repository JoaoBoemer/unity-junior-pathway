using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    private float force = 0.0f;
    private bool shot = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateForce();

        if(shot)
        {
            var newBall = Instantiate(ball, transform.position, ball.transform.rotation);
            newBall.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0.5f, 0) * force * 5, ForceMode.Force);
            shot = false;
            force = 0;
        }
    }

    void CalculateForce()
    {
        if(Input.GetKey(KeyCode.Space) && !shot)
        {
            force++;
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            shot = true;
        }

    }
}
