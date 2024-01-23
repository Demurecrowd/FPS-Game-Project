using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public GameObject target;
    public string eventName1;
    public string eventName2;
    public bool HasKey = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            HasKey = true;
        }

        if(other.gameObject.CompareTag("Door"))
        {
            if(HasKey == true)
            {
                iTweenEvent.GetEvent(target,eventName1).Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Door"))
        {
            iTweenEvent.GetEvent(target, eventName2).Play();
        }
    }
}
