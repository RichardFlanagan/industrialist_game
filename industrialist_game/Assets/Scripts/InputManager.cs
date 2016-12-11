using UnityEngine;
using System.Collections;

public enum DisplayMode {
	Terrain, Forestry
};

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



		if(Input.GetKey("1")){
			GameObject[] tiles = GameObject.Find("Map").GetComponent<Map>().tiles;
			foreach(GameObject go in tiles){
				Tile tile = go.GetComponent<Tile>();
				tile.setDisplayMode(DisplayMode.Terrain);
			}

			//Tile t = GameObject.Find("Map").GetComponent<Map>().tiles[0].GetComponent<Tile>();
			//t.setDisplayMode(DisplayMode.Terrain);
		} else if(Input.GetKey("2")){
			GameObject[] tiles = GameObject.Find("Map").GetComponent<Map>().tiles;
			foreach(GameObject go in tiles){
				Tile tile = go.GetComponent<Tile>();
				tile.setDisplayMode(DisplayMode.Forestry);
			}
		}
	}
}
