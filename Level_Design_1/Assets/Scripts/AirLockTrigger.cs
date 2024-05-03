using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirLockTrigger : MonoBehaviour
{
    public GameObject Airlock1;
    public GameObject Airlock2;
    public Animator Airlock1Animator;
    public Animator Airlock2Animator;

    private void Start()
    {
        Airlock1Animator = Airlock1.GetComponent<Animator>();
        Airlock2Animator = Airlock2.GetComponent<Animator>();
        Airlock1Animator.enabled = false;
        Airlock2Animator.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            Airlock1Animator.enabled = true;
            Airlock2Animator.enabled = true;
        }
    }
}