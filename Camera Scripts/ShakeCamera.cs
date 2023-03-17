using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ShakeCamera : MonoBehaviour
{
    public float power = 0.2f;
    public float duration = 0.2f;
    public float slowDownAmount = 1f;
    private bool shouldShake;
    private float initalDuration;

    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.localPosition;
        initalDuration = duration;
        
    }

    // Update is called once per frame
    void Update()
    {
        Shake();
    }

    void Shake()
    {
        if (shouldShake)
        {
            if (duration > 0f)
            {
                transform.localPosition = startPosition + UnityEngine.Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initalDuration;
                transform.localPosition = startPosition;
            }
            
        }
    }
}
