using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

	[SerializeField] private float Speed     =   1.0f;
	[SerializeField] private float ResetPosX = -40.0f;
	[SerializeField] private float DistanceX =  60.5f;

	[SerializeField] private GameObject OtherPlatform;

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.x <= ResetPosX)
		{
			transform.position = new Vector3( (OtherPlatform.transform.position.x + DistanceX) , transform.position.y , transform.position.z);
		}
		else
		{
			transform.Translate(Vector3.right * (Speed * Time.deltaTime));
		}
	}
}
