using UnityEngine;
using System.Collections;

public class camPos : MonoBehaviour {
	
	public Transform bootPos;
	
	// Use this for initialization
	void Start () {
	 
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = bootPos.position;
	}
}
