using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{ 
    public PlayerScriptable PlayerRef;
    public ParticleSystem DeathParticle;

    public GameObject UI;

    private void Awake()
    {
        PlayerRef.SetUp();
        UI.SetActive(false);
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
        if(PlayerRef.IsDead())
            UI.SetActive(true);
    }

    public void TakeDamage()
    {
        PlayerRef.TakeDamage();
    }
}
