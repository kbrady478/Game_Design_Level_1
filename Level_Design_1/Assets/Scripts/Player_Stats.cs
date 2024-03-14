using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Stats : MonoBehaviour
{
    public int hit_Points = 100;
    public int damage_Recieved = 30;
    public TextMeshProUGUI hit_Points_UI;
    
    
    void Update()
    {
        hit_Points_UI.text = "HP: " + hit_Points;
    }

    public void dealt_Damage()
    {
        hit_Points -= damage_Recieved;
    }
}
