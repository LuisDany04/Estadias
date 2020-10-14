using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponBasic : MonoBehaviour
{
    animHandler anim;
    playerMovement playerMov;


    public bool attacking;

    const string atkk = "Atkk";
    const string idle = "Idle";
    // Start is called before the first frame update
    void Start()
    {
        playerMov = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
        anim = GetComponent<animHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attacking == false && playerMov.InputEnabled == true) {
            anim.ChangeAnimationState(idle);
        }
        attackAnimation();
    }

    public void attackAnimation() {
        if (attacking == false) {
            if (Input.GetKeyDown("space")) {
                Debug.Log("SPACE PRESSED");
                playerMov.InputEnabled = false;
                attacking = true;
                anim.ChangeAnimationState(atkk);
                playerMov.ChangeAnimationState("weaponIdle");
                Invoke("unlockAtkk", anim.animationTime());
            }
        }
    }

    public void causeDamage() {

    }

    public void returnAnimation() {
        anim.ChangeAnimationState(idle);
    }

    public void lockAttk(){
        
    }

    public void unlockAtkk() {
        attacking = false;
        playerMov.InputEnabled = true;
    }
}
