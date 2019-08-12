using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    [SerializeField] LayerMask clickableLayer;

    /// <summary>
    /// Normal pointer
    /// </summary>
    [SerializeField] Texture2D pointer;

    /// <summary>
    /// Cursor for clickable objects
    /// </summary>
    [SerializeField] Texture2D target;

    /// <summary>
    /// Cursor for doorways
    /// </summary>
    [SerializeField] Texture2D doorways;

    /// <summary>
    /// Cursor for combat actions
    /// </summary>
    [SerializeField] Texture2D combat;

    /// <summary>
    /// Makes the EvenetVector3 available in the inspector
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


            // Check if the raycast hit a gameobject with a tag labeled as "Doorway"
            if (hit.collider.gameObject.tag == "Doorway")
            {
                // Set the cursor to a doorway cursor
                Cursor.SetCursor(doorways, new Vector2(16, 16), CursorMode.Auto);

                // Whenever we are hovering into the doorway, set this to true
                door = true;
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
                    Transform doorway = hit.collider.gameObject.transform;

                    onClickedEnvironment.Invoke(doorway.position);
                    Debug.Log("The Door");
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
