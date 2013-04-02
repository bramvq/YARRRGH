using UnityEngine;
using System.Collections;

public class Boat : MonoBehaviour {
	
	//public float playerSpeed = 50;

	protected Animator animator;
	float oldPosX = 0;
	float oldPosY = 0;
	// Use this for initialization
	void Start () {
		
		animator = GetComponent<Animator>();
		transform.position = new Vector3(0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		
		//
		// POSITIE
		//
		rigidbody.AddForce(Vector3.right * Input.GetAxis("Mouse X") * 9000 * Time.deltaTime );
		rigidbody.AddForce(Vector3.forward * Input.GetAxis("Mouse Y") * 9000 * Time.deltaTime);
		//transform.Translate(Vector3.right * Input.GetAxis("Mouse X") * playerSpeed * Time.deltaTime );
		//transform.Translate(Vector3.forward * Input.GetAxis("Mouse Y") * playerSpeed * Time.deltaTime );
		
		
		
		
		
		//
		//  ROTATIE + ANIMATIE
		//
		float StickX = Input.GetAxis("Mouse X");
		float StickY = Input.GetAxis("Mouse Y");
		
		if (Input.GetAxis("Mouse X") < 0 )
			StickX *= -1;
		
		if (Input.GetAxis("Mouse Y") < 0 )
			StickY *= -1;
		
		
		if (StickX > 0 || StickY > 0){
			animator.SetBool("varen", true );			
			
			float moveX = transform.position.x - oldPosX;
			float moveY = transform.position.z - oldPosY;
			
		
			float angle = Mathf.Atan2(-moveY,moveX);
			//float angle2 = Mathf.Atan2(-Input.GetAxis("Mouse Y"),Input.GetAxis("Mouse X"));
			//float angle = (angle1+angle2)/2;
			angle *= 180/Mathf.PI;
	
	        Quaternion target = Quaternion.Euler(0, angle, 0);
			if (angle!=0){
				transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 15);
				print(transform.rotation.y - target.y);
			}
				
		}
		else
			animator.SetBool("varen", false );			
		
		oldPosX = transform.position.x;
		oldPosY = transform.position.z;
	}
}
