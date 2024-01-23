using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Death : MonoBehaviour
{
    public GameObject deathCam;
    public GameObject deathCanvas;
    private FirstPersonController FPSControll;

    private void Awake()
    {
        FPSControll = GetComponent<FirstPersonController>();
    }

    private void OnDisable()
    {
        FPSControll.m_MouseLook.SetCursorLock(false);
        deathCam.SetActive(true);
        deathCanvas.SetActive(true);

    }
}