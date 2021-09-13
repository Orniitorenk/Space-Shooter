using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    Rigidbody physic;
    [SerializeField] int speed;
    [SerializeField] int tilt;
    [SerializeField] GameObject bolt;
    [SerializeField] GameObject shotSpawn;
    [SerializeField] float nextFire;
    [SerializeField] float fireRate;
    [SerializeField] AudioSource audioPlayer;

    public Boundary boundary;
    

    void Start()
    {
        physic = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
    }

     void Update()
     {
        
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate; 
            Instantiate(bolt, shotSpawn.transform.position, shotSpawn.transform.rotation);
            audioPlayer.Play();
        }
        
     }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        physic.velocity = movement * speed;

        Vector3 position = new Vector3(
            Mathf.Clamp(physic.position.x, boundary.xMin, boundary.xMax),
            0,
            Mathf.Clamp(physic.position.z, boundary.zMin, boundary.zMax));


        physic.position = position;

        physic.rotation = Quaternion.Euler(0, 0 ,physic.velocity.x * tilt);
    }
}
