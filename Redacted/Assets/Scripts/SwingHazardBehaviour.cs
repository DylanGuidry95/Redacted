using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SwingHazardBehaviour : MonoBehaviour
{
    [SerializeField]
    private bool IsTriggered;
    [SerializeField]
    private Animator SwingAnim;
    public float ImpactForce;

    private void Awake()
    {        
    }    
    private void Update()
    {        
        SwingAnim.SetBool("IsActive", IsTriggered);        
    }

    public void Trigger()
    {
        IsTriggered = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Rigidbody>().AddForce(transform.forward * ImpactForce, ForceMode.Impulse);
        }
    }
}
