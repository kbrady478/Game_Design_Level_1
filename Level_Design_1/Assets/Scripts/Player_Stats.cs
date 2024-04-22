using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player_Stats : MonoBehaviour
{
    public MonoBehaviour player_Movement_Script;
    public MonoBehaviour player_Shield_Script;
    public Checkpoints checkpoint_Script;
    
    public int hit_Points = 100;
    public int damage_Recieved = 30;
    public TextMeshProUGUI hit_Points_UI;

    public TextMeshProUGUI shield_Energy_UI;
    public GameObject death_Screen_UI;
    
    
    void Update()
    {
        if (hit_Points <= 0)
            trigger_Death();
        
        hit_Points_UI.text = "HP: " + hit_Points;
    }

    
    public void dealt_Damage()
    {
        hit_Points -= damage_Recieved;
    }

    
    public void trigger_Death()
    {
        player_Movement_Script.enabled = false;
        player_Shield_Script.enabled = false;
        shield_Energy_UI.enabled = false;
        hit_Points_UI.enabled = false;
        death_Screen_UI.SetActive(true);
        
        if (Input.GetKeyDown(KeyCode.R))
            checkpoint_Script.Death_Sequence();
            player_Movement_Script.enabled = true;
            player_Shield_Script.enabled = true;
            shield_Energy_UI.enabled = true;
            hit_Points_UI.enabled = true;
            death_Screen_UI.SetActive(false);
    }// end trigger_Death
    
    
    public void HealPlayer(int healpoints)
    {
        hit_Points += healpoints;
        hit_Points = Mathf.Clamp(hit_Points, 0, 100);

    }

}
