using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PastImageBehaviour : MonoBehaviour
{
    public PastImageScriptable ImageRef;
    public GameObject Target;
    public GameObject ProjectilePrefab;
    public ParticleSystem AttackingParticle;
    public float AttackDelay;
    public float AttackPrep;

    private void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(Target.transform.position);          
    }

    float attackTimer = 0;
    bool isAttacking = false;
    private void Update()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= AttackDelay && !isAttacking)
        {
            isAttacking = true;
            GetComponent<NavMeshAgent>().SetDestination(transform.position);
            transform.LookAt(new Vector3(Target.transform.position.x,
                transform.position.y, Target.transform.position.z));
            StartCoroutine("Attack");
        }
        else
        {
            GetComponent<NavMeshAgent>().SetDestination(Target.transform.position);
        }
    }

    IEnumerator Attack()
    {
        AttackingParticle.Play();
        yield return new WaitForSeconds(AttackPrep);
        var projectile = Instantiate(ProjectilePrefab, transform.position +
            new Vector3(0, transform.localScale.x, 0), Quaternion.identity);        
        Vector3 dirToTarget = Target.transform.position - transform.position;
        projectile.GetComponent<Rigidbody>().AddForce(dirToTarget *
            Random.Range(0.25f, 2.0f), ForceMode.Impulse);
        attackTimer = 0;
        isAttacking = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            Debug.Log("Player Killed");
    }
}
