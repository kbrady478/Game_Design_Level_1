using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject player;
    public int bossHP = 102;
    public TextMeshProUGUI bossHPText;
    public bool bossDead;
    public int Damage = 40;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bossDead = false;
    }
    private void Update()
    {
        bossHPText.text = "BOSS HP " + bossHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == player)
        {
            bossHP -= 40;
            if(bossHP <= 0)
            {
                bossDead = true;
            }
        }
        Debug.Log("HEHEHEHE");
    }
    public IEnumerator DamageBoss(int Damage)
    {
        bossHP -= Damage;
        yield return new WaitForSeconds(1.5f);

    }


}
