using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject particleEffect;
    public string playerTag = "Player";
    public GameObject kamera;
    //CollisionShake cameraShake = kamera.GetComponent<CollisionShake>();

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            kamera.GetComponent<CollisionShake>();
            Instantiate(particleEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}