using UnityEngine;
using System.Collections;
/************************************************
 * HOW TO USE
 * Simply apply to any 2D sprite and set the 
 * speed accordingly.
 * 
 * *********************************************/
public class ParalaxScrolling : MonoBehaviour {

	[Tooltip("The speed at which this object scrolls")]
	[SerializeField] private float parallaxingSpeed;

	//The camera itself
	private Transform cam;

	//Where the camera was last frame
	private Vector3 prevPos;
	private Vector3 newPos;

	void Awake(){
		cam = Camera.main.transform;
	}
	
	void Start () {
		prevPos = cam.position;
	}

	void Update () {
		//Calculate how much the camera has moved by this frame
		float camMovementThisFrame = prevPos.x - cam.position.x;

		//Modify speed by different background speeds
		float movementInX = camMovementThisFrame * parallaxingSpeed;

		//Make MovementInX part of a Vector3, ready for the lerp
		newPos = new Vector3(movementInX, this.transform.position.y, this.transform.position.z);

		//Smoothly moves between current position and the target position (with a smoothing modifier)
		transform.position = Vector3.Lerp(transform.position, newPos, 0.5f);

	}
}
