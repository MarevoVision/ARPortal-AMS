﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class PortalWindowController : MonoBehaviour
{
	public PortalController PortalController;

    public AudioSource _Sound;
	private bool isInside = false;
	private bool isOutside = true;
	
	private void OnTriggerStay(Collider col){
		Vector3 playerPos = Camera.main.transform.position +
		                    Camera.main.transform.forward * (Camera.main.nearClipPlane * 4);
		if (transform.InverseTransformPoint(playerPos).z <= 0){
			if (isOutside) {
				isOutside = false;
				isInside = true;
				PortalController.InsidePortal ();
			}
		} else {
			if (isInside) {
				isInside = false;
				isOutside = true;
				PortalController.OutsidePortal ();
			}
		}
	}
    private void Update()
    {
            if (_Sound.volume < 0.5f && isInside == true)
            {
                _Sound.volume = _Sound.volume + Time.deltaTime;
            }
    }
}
