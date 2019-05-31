using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour {



    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {

        
	}

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);

        if (transform.position.y <= -20f)
        {
            Destroy(gameObject);
        }
    }
}
