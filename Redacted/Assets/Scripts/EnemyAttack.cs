using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttack : MonoBehaviour
{
    public GameObject ExplosionParticle;
    public float PushBackForce;

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
            collision.gameObject.GetComponent<PlayerBehaviour>().TakeDamage();
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward
                * PushBackForce);
        }
    }
    
    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(ExplosionParticle);
        Destroy(this.gameObject);
    }
}
