using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour
{
    public int healpoints = 20;
    public Player_Stats playerStats;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("INCREASEHP->");
            player.GetComponent<Player_Stats>().HealPlayer(healpoints);
            Destroy(gameObject, 0);

        }
    }
}
