using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class animHandler : MonoBehaviour
    {
        Animator anim;
        private string currentState;
        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        public void ChangeAnimationState(string newState) {
            if (currentState == newState) return;
            anim.Play(newState);
            currentState = newState;
        }
    }
