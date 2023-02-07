using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1;
    [SerializeField] float rotationThrust = 1;
    [SerializeField] ParticleSystem leftJetParticale;
    [SerializeField] ParticleSystem rightJetParticale;
    [SerializeField] ParticleSystem mainJetParticale;
    CollistionHandler ch;
    Rigidbody rb;
    BoxCollider bc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        ProccesThrust();
        ProccesRotatoin();
        ProccesCheats();
    }
    void ProccesThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            mainJetParticale.Play();
            Debug.Log("Pressed Space");
        }
        else
        {
            mainJetParticale.Stop();
        }
    }
    void ProccesRotatoin()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateMovment(1);
            leftJetParticale.Play();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateMovment(-1);
            Debug.Log("Rotation  Right");
            rightJetParticale.Play();
        }
        else
        {
            rightJetParticale.Stop();
            leftJetParticale.Stop();
             
        }
    }
    void RotateMovment(int rotaionDirection)// -1 / 1 
    {
        rb.freezeRotation = true; // Freezing roation for manual rotaion
        transform.Rotate(rotaionDirection * Vector3.forward * rotationThrust * Time.deltaTime);
        rb.freezeRotation = false;
    }    

    void ProccesCheats()
    {
        if (Input.GetKey(KeyCode.L))
        {
            ch.LoadNextLevel();
        }
        else if (Input.GetKey(KeyCode.K))
        {
            DisableColliions();
        }
    }
    public void DisableColliions()
    {

        bc.enabled = !bc.enabled;
    }
}

