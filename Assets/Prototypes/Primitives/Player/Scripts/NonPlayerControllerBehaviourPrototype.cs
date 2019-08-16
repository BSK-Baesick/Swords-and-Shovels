using UnityEngine;
using UnityEngine.AI;

namespace Prototypes.Primitives.Player.Scripts
{
    /// <summary>
    /// This script handles the game logic for non-player controllers.
    /// </summary>
    
    public class NonPlayerControllerBehaviourPrototype : MonoBehaviour
    {

        // Configuration Parameters
        
        /// <summary>
        /// Tells how much time the enemy will roam on the scene
        /// </summary>
        [SerializeField] private float patrolTime = 10f;

        /// <summary>
        /// The aggro radius of the enemy before it spots and attack the player
        /// </summary>
        [SerializeField] private float aggroRange = 10f;

        /// <summary>
        /// A collection of the enemy's waypoints
        /// </summary>
        [SerializeField] private Transform[] waypoints;
        
        // Class Variables

        /// <summary>
        /// The current array index of waypoints
        /// </summary>
        private int index;

        /// <summary>
        /// The current speed of the agent
        /// </summary>
        private float currentSpeed;

        /// <summary>
        /// The speed of the agent per second
        /// </summary>
        private float agentSpeed;

        /// <summary>
        /// The player current position
        /// </summary>
        private Transform player;

        // Cached References
        // private Animator animator;
        private NavMeshAgent navMeshAgent;

        void Awake()
        {
            // Initialize all the reference component
            // animator = GetComponent<Animator>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
            index = Random.Range(0, waypoints.Length);

            // Check if navMeshAgent component is attached to this gameobject
            if (navMeshAgent != null)
            {
                agentSpeed = navMeshAgent.speed;
            }
            
            // Tick after a specific amount of time
            InvokeRepeating("Tick", 0, 0.5f);

            if (waypoints.Length > 0)
            {
                InvokeRepeating("Patrol", 0, patrolTime);
            }
        }

        void Patrol()
        {
            // Souped conditional statement
            index = index == waypoints.Length - 1 ? 0 : index + 1;
        }

        void Tick()
        {
            navMeshAgent.destination = waypoints[index].position;
        }
    }
}
