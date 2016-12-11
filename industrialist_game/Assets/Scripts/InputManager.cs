using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	void Start () {}
	
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = 10;

			Vector3 screenPos = this.GetComponent<Camera>().ScreenToWorldPoint(mousePos);
			RaycastHit2D hit = Physics2D.Raycast(screenPos,Vector2.zero);

			if (hit.collider != null) {
				GameObject obj = hit.collider.gameObject;
				Tile tile = obj.GetComponent<Tile>();
				if(tile != null){
					tile.click();
				}
			}
		}
	}
}
