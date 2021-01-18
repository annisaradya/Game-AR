using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webCamScript : MonoBehaviour
{
	public GameObject webCameraPlane;


  // Use this for initialization
  void Start () {

    if (Application.isMobilePlatform) {
      GameObject cameraParent = new GameObject ("camParent");
      cameraParent.transform.position = this.transform.position;
      this.transform.parent = cameraParent.transform;
      cameraParent.transform.Rotate (Vector3.right, 90);
    }

    Input.gyro.enabled = true;


    WebCamTexture webCameraTexture = new WebCamTexture();
    webCameraPlane.GetComponent<MeshRenderer>().material.mainTexture = webCameraTexture;
    webCameraTexture.Play();

  }
  // Update is called once per frame
  void Update () {

    Quaternion cameraRotation = new Quaternion (Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
    this.transform.localRotation = cameraRotation;
  
  }
}