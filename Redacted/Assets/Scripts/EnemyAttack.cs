using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttack : MonoBehaviour
{
    public GameObject ExplosionParticle;    

    private void OnCollisionEnter(Collision collision)
    {        
        ExplosionParticle.transform.parent = null;
        this.GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        Destroy(GetComponent<Rigidbody>());
        ExplosionParticle.GetComponent<ParticleSystem>().Play();
        StartCoroutine("DestroyDelay");
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Hit");
        }
    }
    
    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(ExplosionParticle);
        Destroy(this.gameObject);
    }
}
