using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControllerPrototype : MonoBehaviour
{

    // Animator animator;
    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Awake()
    {
        // Initialize any component reference
        // animator = (Animator)GetComponent(typeof(Animator));
        navMeshAgent = (NavMeshAgent)GetComponent(typeof(NavMeshAgent));
    }
}
