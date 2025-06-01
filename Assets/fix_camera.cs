using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fix_camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Mantiene la posición fija
        transform.position = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
