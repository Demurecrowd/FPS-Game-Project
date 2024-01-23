using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TwinStickProject
{
    public class Enemy : MonoBehaviour
    {
       
      //  public ObjectPool particlePool;
        public int scoreValue = 10;
        public GameObject particle;
        public Transform target;

        private void OnTriggerEnter(Collider Other)
        {
            if (Other.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
               // gameObject.SetActive(false);
                // Destroy(Other.gameObject);
               // Other.gameObject.SetActive(false);

            }

            if (Other.gameObject.CompareTag("Bullet"))
            {
              //;  GameManager.Instance.AdjustScore(scoreValue);
               // gameObject.SetActive(false);
                Destroy(Other.gameObject);
                Destroy(gameObject);
               // Other.gameObject.SetActive(false);

            }
        }

        //private void OnDisable()
        //{
        //    GameObject clone = particlePool.GetPooledObject();
        //    Vector3 pos = transform.position;
        //    pos.y = 1;
        //    clone.transform.position = pos;      //transform.position + Vector3.up;
        //    clone.transform.rotation = Quaternion.Euler(0, 2, 0);
        //    ParticleSystem ps = clone.GetComponent<ParticleSystem>();
        //    ps.Clear();
        //    clone.SetActive(true);
        //    ps.Play();

        //    //(particle, transform.position + Vector3.up, Quaternion.Euler(0, 2, 0));
        //    // Destroy(clone, 5f);
        //}


    }

}
