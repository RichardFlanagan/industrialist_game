using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	
	public static int moveSpeed = 15;
	public static int zoomSpeed = 15;
	public static int boostMultiplier = 5;
	public static int maxZoom = 100;
	public static int minZoom = 3;
	public static Camera cam;
	private static bool boost = false;

	void Start () {
		cam = this.GetComponent<Camera>();
	}
	
	void Update () {
		boost = false;
		updatePosition();
		updateZoomLevel_orthographic();
		//updateZoomLevel_perspective();
	}

	private void updatePosition(){
		Vector3 moveVector = Vector3.zero;

		if(Input.GetKey("w")){ moveVector.y++; }
		if(Input.GetKey("s")){ moveVector.y--; }
		if(Input.GetKey("a")){ moveVector.x--; }
		if(Input.GetKey("d")){ moveVector.x++; }
		if(Input.GetKey(KeyCode.LeftShift)){ boost = true; }

		if(moveVector != Vector3.zero){
			this.transform.position += moveVector.normalized * moveSpeed * Time.deltaTime * (boost?boostMultiplier:1);
		}
	}

	private void updateZoomLevel_orthographic(){
		if(Input.GetKey("q") && (cam.orthographicSize < maxZoom)){
			cam.orthographicSize += zoomSpeed * Time.deltaTime * (boost?boostMultiplier:1);
		}
		if(Input.GetKey("e") && (cam.orthographicSize > minZoom)){
			cam.orthographicSize -= zoomSpeed * Time.deltaTime * (boost?boostMultiplier:1);
		}
	}

	private void updateZoomLevel_perspective(){
		if(Input.GetKey("q") && (cam.transform.position.z > -maxZoom)){
			Vector3 vec = new Vector3(0, 0, 
				zoomSpeed * Time.deltaTime * (boost?boostMultiplier:1)
			);
			cam.transform.position -= vec;
		}
		if(Input.GetKey("e") && (cam.transform.position.z < -minZoom)){
			Vector3 vec = new Vector3(0, 0, 
				zoomSpeed * Time.deltaTime * (boost?boostMultiplier:1)
			);
			cam.transform.position += vec;
		}
	}
}
