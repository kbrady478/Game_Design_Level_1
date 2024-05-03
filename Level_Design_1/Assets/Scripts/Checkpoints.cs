using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public int current_Checkpoint;
    
    // Waypoints
    public GameObject[] checkpoint_Objects;
    public GameObject bastard_Start_Point;
    
    // Controllers
    public GameObject player_Controller;
    public GameObject bastard_Controller;
    
    public Player_Stats player_Stats_Script;
    public Player_Shield player_Shield_Script;

    public GameObject[] lever_Light_First = {null, null, null};
    public GameObject[] lever_Light_Second = {null, null, null};
    public GameObject[] lever_Light_Third = {null, null , null};
    
    private void Start()
    {
        player_Controller.transform.position = checkpoint_Objects[0].transform.position;
        current_Checkpoint = 0;
    }// end Start


    public void Change_Checkpoint(int switch_Num)
    {
        current_Checkpoint = switch_Num; 
        turn_On_Lights(switch_Num);
    }// end Change_Checkpoint

    public void Death_Sequence()
    {
        player_Stats_Script.hit_Points = 100;
        player_Shield_Script.energy_Pool = 100;

        bastard_Controller.transform.position = bastard_Start_Point.transform.position;
        player_Controller.transform.position = checkpoint_Objects[current_Checkpoint].transform.position;
    }// end Death_Sequence

    private void turn_On_Lights(int switch_Num)
    {
        if (switch_Num == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                lever_Light_First[i].SetActive(true);
            }
        }

        if (switch_Num == 2)
        {
            for (int i = 0; i < 3; i++)
            {
                lever_Light_Second[i].SetActive(true);
            }
        }

        if (switch_Num == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                lever_Light_Third[i].SetActive(true);
            }
        }
        
    }// end turn_On_Lights
    
}
