using UnityEngine;
using UnityEngine.Events;

namespace Prototypes.Primitives.Player.Scripts
{
    /// <summary>
    /// This script handles the mouse manager game logic.
    /// </summary>

    public class MouseManagerPrototype : MonoBehaviour
    {

        // TODO Know what objects are clickable.
        // TODO What does the cursor looks like per different object click?

        // Configuration Parameters

        /// <summary>
        /// The layer that can be interact with
        /// </summary>
        [SerializeField] private LayerMask clickableLayer;

        /// <summary>
        /// Normal pointer
        /// </summary>
        [SerializeField] private Texture2D pointer;

        /// <summary>
        /// Cursor for clickable objects
        /// </summary>
        [SerializeField] private Texture2D target;

        /// <summary>
        /// Cursor for doorways
        /// </summary>
        [SerializeField] private Texture2D doorways;

        /// <summary>
        /// Cursor for combat actions
        /// </summary>
        [SerializeField] private Texture2D combat;

        /// <summary>
        /// Makes the EventVector3 available in the inspector
        /// </summary>
        public EventVector3 onClickedEnvironment;

        // Update is called once per frame
        void Update()
        {
            RaycastHit hit;

            // Check if the object interacted with is clickable or not
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, clickableLayer.value))
            {

                // Whenever the mouse pointer is not hovering and pointing on the door, set this variable to false
                bool door = false;

                // Whenever the mouse pointer is not hovering and pointing on an item, set this variable to false;
                bool item = false;

                // Check if the raycast hit a gameobject with a tag labeled as "Doorway"
                if (hit.collider.gameObject.CompareTag("Doorway"))
                {
                    // Set the cursor to a doorway cursor
                    Cursor.SetCursor(doorways, new Vector2(16, 16), CursorMode.Auto);

                    // Whenever we are hovering into the doorway, set this to true
                    door = true;
                }
                
                else if (hit.collider.gameObject.CompareTag("Item"))
                {
                    // Set the cursor to an item cursor
                    Cursor.SetCursor(combat, new Vector2(16, 16), CursorMode.Auto);
                    
                    // Whenever we are hovering into an item, set this to true
                    item = true;
                }

                else
                {
                    // Set the cursor to a target cursor
                    Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
                }

                // Fires a Vector3 to our agent and will send an event to our navmesh agent
                if (Input.GetMouseButtonDown(0))
                {
                    if (door)
                    {
                        // The transform component of the door hitted by the raycast laser
                        Transform doorway = hit.collider.gameObject.transform;

                        // Invokes the transform position of a doorway
                        onClickedEnvironment.Invoke(doorway.position);
                        Debug.Log("The Door");
                    }
                    
                    else if (item)
                    {
                        // The transform component of an item hitted by the raycast laser
                        Transform itemPos = hit.collider.gameObject.transform;
                        
                        // Invokes the transform position of an item
                        onClickedEnvironment.Invoke(itemPos.position);
                        Debug.Log("The Item");
                    }

                    else
                    {
                        onClickedEnvironment.Invoke(hit.point);
                    }
                }
            }

            else
            {
                // Set the cursor to normal cursor
                Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);
            }
        }
    }

    [System.Serializable]
    public class EventVector3 : UnityEvent<Vector3>
    {
    
    }
}