using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SampleTarget : MonoBehaviour {
        public Transform target;
        public Transform boyfriend;
        private NavMeshAgent agent;
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }
        void Update()
        {
            if (Vector3.Distance(target.position, boyfriend.position) < 7.0f)
            {
                agent.SetDestination(target.position);
            }
            else
            {
                //agent.SetDestination(target.position);
            }
        }
}
