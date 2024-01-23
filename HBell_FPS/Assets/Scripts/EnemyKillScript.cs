using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
        }
    }
}