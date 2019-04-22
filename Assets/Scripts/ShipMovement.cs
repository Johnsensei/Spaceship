using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShipMovement : MonoBehaviour
{

    public float shipSpeed;
    public Camera playerCamera;
    public GameController gameController;
    public TextMesh crashText;
    public AudioSource audioSource;
    public float distanceTraveled;
    public ParticleSystem starParticles;
    public AudioClip crashSFX;


    private bool crashed = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!crashed)
        {
            transform.position += playerCamera.transform.forward * shipSpeed * Time.deltaTime;
        }
        }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle" && !crashed){
            crashed = true;
            gameController.launched = false;
            playerCamera.backgroundColor = Color.red;
            audioSource.clip = crashSFX;
            audioSource.Play();
            crashText.gameObject.SetActive(true);
            distanceTraveled = Mathf.RoundToInt(transform.position.z);
            crashText.text += distanceTraveled;
            starParticles.Stop();
            Invoke("ResetScene", 4f);
        }
    }

    public void ResetScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
