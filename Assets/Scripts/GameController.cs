using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject asteroid;
    public ShipMovement ship;
    public float spawnDistance;
    public float spawnIncrement;
    public TextMesh launchText;
    public bool launched = false;

    public float spawnPointer = 0f;

	// Use this for initialization
	void Awake () {
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (!launched && Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1.0f;
            launched = true;
            launchText.gameObject.SetActive(false);
            ship.audioSource.Play();

        }

        if(launched){
            Invoke("SpawnAsteroids", 5f);
        }
    }

    void SpawnAsteroids(){
        if (ship.transform.position.z > spawnPointer)
        {
            GameObject asteroidObject = Instantiate(asteroid);
            asteroidObject.transform.position = new Vector3(
                Random.Range(-2.5f, 2.5f),
                Random.Range(-2.5f, 2.5f),
                ship.transform.position.z + spawnDistance
            );

            spawnPointer = ship.transform.position.z + spawnIncrement;
        }
    }
}
