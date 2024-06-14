using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionShake : MonoBehaviour
{
    [SerializeField] private float shakeDuration = 1f;
    [SerializeField] private float shakeAmount = 100f;

    private Vector3 originalPos;
    private Transform camTransform;

    private void Start()
    {
        camTransform = transform;
        originalPos = camTransform.localPosition;
    }

    public void Shake()
    {
        StartCoroutine(DoShake());
        Debug.Log("Impact!");

    }

    private IEnumerator DoShake()
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            Vector3 randomOffset = Random.insideUnitSphere * shakeAmount;
            camTransform.localPosition = originalPos + randomOffset;

            elapsed += Time.deltaTime;
            yield return null;
        }

        camTransform.localPosition = originalPos;
    }
}
