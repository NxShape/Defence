using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public float Speed;
	
	public void Update()
	{
		if(PopupManager.Instance.OpenedPopup.Count > 0) return;
		
		if(Input.GetKey(KeyCode.LeftArrow))
			transform.Translate(-Vector3.right * Time.deltaTime * Speed);

		if(Input.GetKey(KeyCode.RightArrow))
			transform.Translate(Vector3.right * Time.deltaTime * Speed);

		if(Input.GetKey(KeyCode.UpArrow))
			transform.Translate(Vector3.forward * Time.deltaTime * Speed);
		
		if(Input.GetKey(KeyCode.DownArrow))
			transform.Translate(-Vector3.forward * Time.deltaTime * Speed);
	}
}
