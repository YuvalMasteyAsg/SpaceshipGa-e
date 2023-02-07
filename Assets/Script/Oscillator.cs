using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField]  [Range(0,1)] float  movementFector;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition= transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period == 0f) return;
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float rawSinWaze = Mathf.Sin(cycles * tau);

        movementFector = (rawSinWaze + 1f) / 2f;

        Vector3 offset = movementVector * movementFector;
        transform.position = startingPosition + offset;
    }
}
