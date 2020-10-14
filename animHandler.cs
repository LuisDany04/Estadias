using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animHandler : MonoBehaviour {
    Animator animSource;
    private string currentState;
    // Start is called before the first frame update
    void Start() {
        animSource = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

    }


    public void ChangeAnimationState(string newState) {
        if (currentState == newState) return;
        animSource.Play(newState);
        currentState = newState;
    }

    public float animationTime() {
        return animSource.GetCurrentAnimatorStateInfo(0).length;
    }

}
