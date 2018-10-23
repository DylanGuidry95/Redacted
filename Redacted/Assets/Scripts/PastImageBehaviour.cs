using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PastImageBehaviour : MonoBehaviour
{
    public PastImageScriptable ImageRef;
    public GameObject Target;
    public GameObject ProjectilePrefab;
    public float AttackDelay;

    private void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(Target.transform.position);          
    }

    float attackTimer = 0;
    private void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(Target.transform.position);
        attackTimer += Time.deltaTime;

        if(attackTimer >= AttackDelay)
        {
            StartCoroutine("Attack");
            attackTimer = 0;
        }
    }

    IEnumerator Attack()
    {
        var projectile = Instantiate(ProjectilePrefab);
        projectile.transform.position = transform.position + 
            new Vector3(0, transform.localScale.x, 0);
        projectile.GetComponent<Rigidbody>().useGravity = false;
        yield return new WaitForSeconds(0.5f);
        projectile.GetComponent<Rigidbody>().useGravity = true;
        Vector3 dirToTarget = Target.transform.position - transform.position;
        projectile.GetComponent<Rigidbody>().AddForce(dirToTarget * Random.Range(0.25f, 2.0f), ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            Debug.Log("Player Killed");
    }
}
