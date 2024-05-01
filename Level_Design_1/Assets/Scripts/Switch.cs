using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public static int bossHP = 100;
    public TextMeshProUGUI bossHPText;
    public bool bossDead;
    public int Damage = 40;

    public Checkpoints checkpoint_Script;
    public int checkpoint_Num;
    
    // Start is called before the first frame update
    void Start()
    {
        bossHP = 100;
        bossDead = false;
    }
    private void Update()
    {
        //bossHPText.text = "BOSS HP :" + bossHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            checkpoint_Script.Change_Checkpoint(checkpoint_Num);
            
            bossHP -= 40;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Debug.Log("HEHEHEHE");
            if (bossHP <= 0)
            {
                bossHP = 0;
                bossDead = true;
            }
            gameObject.GetComponent<Animator>().SetBool("isSwitched", true);
        }
    }
    public IEnumerator DamageBoss(int Damage)
    {
        bossHP -= Damage;
        yield return new WaitForSeconds(1.5f);

    }


}
