using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float pos = 10f;
    public GameObject CameraObj;
    public CapsuleCollider colliderCapsula;

 
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) // Sonido de Pasos.
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }
        }
        else if (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0)
        {
            GetComponent<AudioSource>().Stop();
        }

        if (Input.GetButton("Fire1")) // Agacharse.
        {
            colliderCapsula.height = 1.0f;
        }
        else
        {
            colliderCapsula.height = 1.8f;
        }
    }

    private void FixedUpdate()
    {
        // Avanzar según la direccion de la cámara donde este mirando.
        GetComponent<Rigidbody>().MovePosition(transform.position + (new Vector3(CameraObj.transform.forward.x, 0f, CameraObj.transform.forward.z) * pos * Input.GetAxis("Vertical") + new Vector3(CameraObj.transform.right.x, 0f, CameraObj.transform.right.z) * pos * Input.GetAxis("Horizontal")) * Time.deltaTime);

        
    }



}
