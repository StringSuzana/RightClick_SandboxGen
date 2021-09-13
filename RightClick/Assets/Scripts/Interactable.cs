using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ColorOnHover))]
public class Interactable : MonoBehaviour
{

	public float radius = 3f;
	public Transform interactionTransform;

	bool isFocused = false;   
	Transform player;      

	bool hasInteracted = false; // Have we already interacted with the object?

	void Update()
	{
		if (isFocused)  
		{
			float distance = Vector3.Distance(player.position, interactionTransform.position);
			// If we haven't already interacted and the player is close enough
			if (!hasInteracted && distance <= radius)
			{
				// Interact with the object
				hasInteracted = true;
				Interact();
			}
		}
	}
	///<summary>
	/// Call when the object starts being focused
	/// </summary>
	public void OnFocused(Transform playerTransform)
	{
		isFocused = true;
		hasInteracted = false;
		player = playerTransform;
	}

	///<summary>
	/// Called when the object is no longer focused
	/// </summary>
	public void OnDefocused()
	{
		isFocused = false;
		hasInteracted = false;
		player = null;
	}

	///<summary>
	/// This method is just a shell
	/// </summary>
	public virtual void Interact()
	{
		Debug.Log("Override this method");
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}

}