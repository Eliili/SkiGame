using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera vCam;
    public GameObject character;
    private Collider characterCollider;
    
    private float shakeDuration = 0.2f;
    private float shakeAmount = 1f;

    private float timer;
    private CinemachineBasicMultiChannelPerlin noise;
    
    private void Awake()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
    }

    private void ShakeCamera()
    {
        //noise = CinemachineVirtualCamera.GetCinemachineComponent(noise);
        noise.m_AmplitudeGain = shakeAmount;
        
        timer = shakeDuration;
    }

    //public CinemachineCore.Stage CinemachineBasicMultiChannelPerlin { get; set; }

    void StopShake()
    {
        //noise = CinemachineVirtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Noise);
        noise.m_AmplitudeGain = 0f;
        timer = 0;
    }

    void Update()
    {
        if (characterCollider.gameObject.CompareTag("SnowPile"))
        {
            ShakeCamera();
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                StopShake();
            }
        }
    }
}