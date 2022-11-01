using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    public bool isAvailable = true;
    public GameObject Customer;
    public Transform LookTransform;
    void Start()
    {
        
    }


    void Update()
    {
        if (Customer != null)
        {    
        Customer.transform.LookAt(LookTransform.position);
        }
    }
}
