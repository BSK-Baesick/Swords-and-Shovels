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
        private bool _isplayerNotNull;

        void Awake()
        {
            _isplayerNotNull = player != null;
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
                // Patrol after a specific amount of time
                InvokeRepeating("Patrol", 0, patrolTime);
            }
        }

        void Patrol()
        {
            // Shorthand for if-else statement
            index = index == waypoints.Length - 1 ? 0 : index + 1;
        }

        void Tick()
        {
            // Enemy's current destination
            navMeshAgent.destination = waypoints[index].position;
            
            // Cut the speed of the enemy when patrolling
            navMeshAgent.speed = agentSpeed / 2;
            
            // Check if the player is in the scene and the distance between the enemy and the player is less than the aggro range
            if (_isplayerNotNull && Vector3.Distance(transform.position, player.position) < aggroRange)
            {
                // Chase the player
                navMeshAgent.destination = player.position;
                
                // Speed up the movement of the enemy
                navMeshAgent.speed = agentSpeed;
            }
        }
    }
}
