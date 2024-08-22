using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    private int Count = 0;

    private int xMaxPosition = 17;
    private int xMinPosition = -20;

    private void Start()
    {
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        Count += 1;
        CounterText.text = "Count : " + Count;
        transform.position = new Vector3(Random.Range(xMinPosition, xMaxPosition), 0, 0);
        Destroy(other.gameObject);
    }
}
