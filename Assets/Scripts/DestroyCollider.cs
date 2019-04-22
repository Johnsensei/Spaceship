using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollider : MonoBehaviour {

    public Wormhole wormhole;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            wormhole.transform.position.z -15);
	}

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
