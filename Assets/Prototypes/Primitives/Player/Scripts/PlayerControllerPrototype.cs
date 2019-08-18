using UnityEngine;
using UnityEngine.AI;

namespace Prototypes.Primitives.Player.Scripts
{
    /// <summary>
    /// This script handles the game logic for player.
    /// </summary>
    public class PlayerControllerPrototype : MonoBehaviour
    {

        private Animator animator;
        private NavMeshAgent navMeshAgent;

        // Start is called before the first frame update
        private void Awake()
        {
            // Initialize any component reference
            animator = (Animator)GetComponent(typeof(Animator));
            navMeshAgent = (NavMeshAgent)GetComponent(typeof(NavMeshAgent));
        }

        private void Update()
        {
            animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);
        }
    }
}
