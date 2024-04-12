using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassTrigger : MonoBehaviour
{
    public Player_Movement playerMovement;
    public GameObject player;
    public GameObject glassShatter;
    public GameObject[] glassRBs;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        glassRBs = GameObject.FindGameObjectsWithTag("GlassShatter");
        foreach(GameObject rb in glassRBs)
        {
            rb.GetComponent<Rigidbody>().Sleep();
        }
    }
    public void OnTriggerEnter(Collider other) 
    {

        Debug.Log("SLAM!");
        if (playerMovement.velocity.y <= -12 && playerMovement.is_Grounded == false)
        {
            {
                if (other.gameObject.tag == "Player")

                    foreach (GameObject rb in glassRBs)
                    {
                        rb.GetComponent<Rigidbody>().WakeUp();
                        rb.GetComponent<Rigidbody>().AddForce(Vector3.down * 0.5f, ForceMode.Impulse);
                    }
            }
        }
    }

}
