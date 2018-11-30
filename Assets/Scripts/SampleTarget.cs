using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SampleTarget : MonoBehaviour {
        public Transform target;
        public Transform boyfriend;
        private NavMeshAgent agent;
        GameObject varGameObject;
        void Start()
        {
            varGameObject = GameObject.Find("Enemy");
            varGameObject.GetComponent<WanderEnemy>().enabled = false;
            agent = GetComponent<NavMeshAgent>();
        }
        void Update()
        {
            if (Vector3.Distance(target.position, boyfriend.position) < 5.0f)
            {
                //varGameObject.GetComponent<WanderEnemy>().enabled = false;
                agent.SetDestination(target.position);
            }
            else
            {
                varGameObject.GetComponent<WanderEnemy>().enabled = true;
            }
        }
}
