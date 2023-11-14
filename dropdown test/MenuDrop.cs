using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDrop : MonoBehaviour
    
{
    public bool Open;
    Vector3 targetLow = new Vector3(86, 252, 0);
    Vector3 targetHigh = new Vector3(86, 700, 0);
    // Start is called before the first frame update
    void Start()
    {
        Open = false;
    }
    //trigger when button clicked
    public void Drop()
    {
        //toggle boolean
        Open = !Open;

    }
    // Update is called once per frame
    void Update()
    {
        if (Open == true)
        {
            float step = 900 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetLow, step);
        }
        if (Open == false)
        {
            float step = 900 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetHigh, step);
        }
    }
}
