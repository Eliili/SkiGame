using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    public float moveDistance = 5.0f;
    public float speed = 2.0f;
    private Vector3 leftPosition;
    private Vector3 rightPosition;
    private Vector3 target;

    void Start()
    {
        leftPosition = transform.position - new Vector3(moveDistance, 0, 0);
        rightPosition = transform.position + new Vector3(moveDistance, 0, 0);
        target = rightPosition;
    }

    void Update()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            if (target == rightPosition)
            {
                target = leftPosition;
            }
            else
            {
                target = rightPosition;
            }
        }
    }
}