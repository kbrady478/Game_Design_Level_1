using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Collision : MonoBehaviour
{
    public Player_Movement player_Movement_Script;
    public Player_Stats player_Stats_Script;
    
    public AudioSource audio_Component;
    public AudioClip audio_Clip;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            if (gameObject.tag == "medkit" && player_Stats_Script.hit_Points < 100)
            {
                audio_Component.PlayOneShot(audio_Clip);
                Destroy(gameObject);

                if (player_Stats_Script.hit_Points + 50 > 100)
                {
                    player_Stats_Script.hit_Points = 100;
                }
                else
                    player_Stats_Script.hit_Points += 50;
                
            }
        }
        
    }
}
