using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public Player player_script;
    public GameManager GM;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        int r = Random.Range(-1, 2);
        transform.position = new Vector3(transform.position.x + r/100, transform.position.y - 0.02f, transform.position.z);

        if (transform.position.y <= -20f)
        {
            Destroy(gameObject);
        }
    }

}
