using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{ 
    public PlayerScriptable PlayerRef;
    public ParticleSystem DeathParticle;

    private void Awake()
    {
        PlayerRef.SetUp();
    }

    bool DirtyDeath = true;
    private void Update()
    {
        if(PlayerRef.IsDead() && DirtyDeath)
        {            
            DirtyDeath = false;
            DeathParticle.Play();
        }
        if(!DirtyDeath && GetComponent<MeshRenderer>().material.color.a > 0)
        {
            Color color = GetComponent<MeshRenderer>().material.color;
            GetComponent<MeshRenderer>().material.color = new Color(color.r, color.g,
                color.b, color.a -= Time.deltaTime);
        }
    }

    public void TakeDamage()
    {
        PlayerRef.TakeDamage();
    }
}
