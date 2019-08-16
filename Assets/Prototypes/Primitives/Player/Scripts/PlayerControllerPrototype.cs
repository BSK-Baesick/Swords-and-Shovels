﻿using UnityEngine;
using UnityEngine.AI;

namespace Prototypes.Primitives.Player.Scripts
{
    /// <summary>
    /// This script handles the game logic for player.
    /// </summary>
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
}
