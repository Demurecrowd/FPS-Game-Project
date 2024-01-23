using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FlashLight : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource flashAudio;
    public float delayTime = 2f;
    public float maxValue = 30f;
    public Text Percentage;
    public float BatteryLife = 30f;
    public GameObject lightsource;
    private bool isLightOn;
    private bool canLightCharge = true;

    private void Start()
    {

    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode. Mouse1))
        {
            
            if (isLightOn)
            {
                lightsource.SetActive(false);
                isLightOn = false;
                
            }

            

            else
            {
                lightsource.SetActive(true);
                isLightOn = true;
            }

            flashAudio.PlayOneShot(clip);
        }

        if (isLightOn && canLightCharge)
        {

            BatteryLife -= Time.deltaTime;

            if(BatteryLife <= 0f)
            {
                isLightOn = false; 
                lightsource.SetActive(false);
                canLightCharge = false;
                Invoke("TurnChargeON", delayTime);

            }



        }
        else if (!isLightOn && canLightCharge)
        {
            BatteryLife += Time.deltaTime * 0.5f;

        }

        BatteryLife = Mathf.Clamp(BatteryLife, 0f, maxValue);


        Percentage.text = ((BatteryLife / maxValue) * 100).ToString("##") + "%";
        if(canLightCharge == false)
        {
            Percentage.text = "Battery Dead";
        }

        
    }
    void TurnChargeON()
    {
        canLightCharge = true;
    }

    public void Fired()
    {
        BatteryLife -= maxValue / 10f;

       
    }

}
