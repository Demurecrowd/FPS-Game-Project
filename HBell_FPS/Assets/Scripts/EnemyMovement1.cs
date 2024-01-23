using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement1  : MonoBehaviour
{
  
    NavMeshAgent agent;

    Transform tr_Player;
  
    
    
    
    //float f_RotSpeed = 3.0f, f_MoveSpeed = 3.0f;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        tr_Player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        //agent.SetDestination(tr_Player.position);
      
        if (tr_Player == null)
        {
            return;
        }
        else
        {
            agent.SetDestination(tr_Player.position);
        }
        
        
        
        ///* Look at Player*/
        //transform.rotation = Quaternion.Slerp(transform.rotation
        //                                      , Quaternion.LookRotation(tr_Player.position - transform.position)
        //                                      , f_RotSpeed * Time.deltaTime);

        ///* Move at Player*/
        //transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
    }





    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
        }
    }
}