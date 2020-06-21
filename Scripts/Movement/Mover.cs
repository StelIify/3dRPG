
using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        NavMeshAgent navMashAgent;
        Animator anim;
        void Awake()
        {
            navMashAgent = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();

        }

        // Update is called once per frame
        void Update()
        {
            // MoveUsingKeyBoard();
            UpdateAnimator();
        }
        private void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("ForwardSpeed", speed);
        }

        public void Cancel()
        {
            navMashAgent.isStopped = true;
        }
        
        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination);

        }
        public void MoveTo(Vector3 destination)
        {
            navMashAgent.destination = destination;
            navMashAgent.isStopped = false;
        }



        /*
     private void MoveUsingKeyBoard()
     {
         float horizontalMovement = Input.GetAxis("Horizontal");
         float verticalMovent = Input.GetAxis("Vertical");
         Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovent);
         Vector3 moveDestination = transform.position + movement;
         navigation.destination = moveDestination;
     }
     */
    }

}
