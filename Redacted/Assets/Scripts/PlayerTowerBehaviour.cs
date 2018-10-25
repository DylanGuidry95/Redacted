using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTowerBehaviour : MonoBehaviour
{
    
    public GameObject RotationJoint;
    public GameObject Enemy;
    public LineRenderer Laser;    
    public GameObject LaserHitParticle;
    public List<GameObject> ActiveParticles;
    public List<float> ParticleLifeTimes;

    private void Start()
    {
        Laser.startWidth = 0;
        Laser.endWidth = 0;
    }

    private void Update()
    {        
        RotationJoint.transform.LookAt(Enemy.transform.position);
        Laser.SetPosition(1, Enemy.transform.position);
        for(int i = 0; i < ActiveParticles.Count; i++)
        {
            ParticleLifeTimes[i] += Time.deltaTime;
            if(ParticleLifeTimes[i] >= 5)
            {
                ActiveParticles[i].GetComponent<ParticleSystem>().Stop();
            }
        }
    }

    [ContextMenu("FIRE")]
    public void Fire()
    {
        StartCoroutine("LaserDraw");
    }

    IEnumerator LaserDraw()
    {
        var obj = Instantiate(LaserHitParticle, Enemy.transform.position, Quaternion.identity);
        ActiveParticles.Add(obj);
        ParticleLifeTimes.Add(0);
        Laser.startWidth = 0.5f;
        Laser.endWidth = 0.5f;
        yield return new WaitForSeconds(1.5f);
        Laser.startWidth = 0;
        Laser.endWidth = 0;
    }
}
