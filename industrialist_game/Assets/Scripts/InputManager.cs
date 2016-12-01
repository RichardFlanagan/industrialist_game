using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	void Start () {}
	
	void Update () {
		// if(Input.GetMouseButtonDown(0)){
		// 	Vector3 mousePos = Input.mousePosition;
		// 	mousePos.z = 10;

		// 	Vector3 screenPos = this.GetComponent<Camera>().ScreenToWorldPoint(mousePos);
		// 	RaycastHit2D hit = Physics2D.Raycast(screenPos,Vector2.zero);

		// 	if (hit.collider != null) {
		// 		GameObject obj = hit.collider.gameObject;
		// 		MapTile mapTile = obj.GetComponent<MapTile>();
		// 		if(mapTile != null){
		// 			mapTile.click();
		// 		}
		// 	}
		// }

		if(Input.GetMouseButtonDown(0)){
			Vector2 mousePos = Input.mousePosition;
			Debug.Log("click"+mousePos);
		}
	}
}
