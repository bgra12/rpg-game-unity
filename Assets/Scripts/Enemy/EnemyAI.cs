using System;
using UnityEngine;


    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private string initState;
        [SerializeField] private FSMState[] states;

        public Transform player { get; set; } 
        public FSMState currentState{get; set;}


        private void Start()
        {
            changeState(initState);
        }

        private void Update()
        {
            currentState?.updateState(this);
        }

        public void changeState(string newStateId)
        {
            FSMState newState = getState(newStateId);
            if (newState != null)
            {
                currentState = newState;
            }
            else
            {
                return;
            }
        }

        private FSMState getState(string stateId)
        {
            for (int i = 0; i < states.Length; i++)
            {
                if (states[i].id == stateId)
                {
                    return states[i];
                }
            }
            return null;
        }
    }
    