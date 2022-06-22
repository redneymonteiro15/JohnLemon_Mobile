using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vetor;
        vetor.y = 90;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, vetor.y, transform.eulerAngles.z);
    }
}
