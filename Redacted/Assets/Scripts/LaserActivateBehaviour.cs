using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserActivateBehaviour : MonoBehaviour
{
    public float Cooldown;
    public Color ActiveColor;
    public Color CooldownColor;
    public GameObject DeactiveParticle;
    public PlayerTowerBehaviour Laser;
    float cooldownTimer = 0;
    bool OnCooldown;

    private void Start()
    {
        GetComponent<MeshRenderer>().material.color = ActiveColor;
    }

    private void Update()
    {
        if(OnCooldown)
        {
            cooldownTimer += Time.deltaTime;
        }
        if(cooldownTimer >= Cooldown)
        {
            DeactiveParticle.GetComponent<ParticleSystem>().Stop();
            OnCooldown = false;
            GetComponent<MeshRenderer>().material.color = ActiveColor;
        }
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.tag == "Player")
        {
            DeactiveParticle.GetComponent<ParticleSystem>().Play();
            OnCooldown = true;
            GetComponent<MeshRenderer>().material.color = CooldownColor;
            Laser.Fire();
            cooldownTimer = 0;
        }
    }
}
