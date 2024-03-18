using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Bastard_Hit : MonoBehaviour
{
    public int stun_Timer;
    public Bastard bastard_Controller_Script;
    //public MonoScript bastard_Shooting_Script;
    
        public Material bastard_Material;
        public Color hit_Color, regular_Color;
    
    public void Bastard_Stun()
    {
        print("stun called");
        StopAllCoroutines();
        StartCoroutine(Stun_Timer());
    }// end Bastard_Stun()
    
    IEnumerator Stun_Timer()
    {
        bastard_Controller_Script.enabled = false;
        bastard_Material.color = hit_Color;
        yield return new WaitForSeconds(stun_Timer);
        bastard_Controller_Script.enabled = true;
        bastard_Material.color = regular_Color;
    }
    
}


