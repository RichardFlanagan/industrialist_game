using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	private Tile selectedTile;

	void Start () {}

	void Update () {
		// if(Input.GetMouseButtonDown(0)){
		// 	Vector3 mousePos = Input.mousePosition;
		// 	mousePos.z = 10;

		// 	Vector3 screenPos = this.GetComponent<Camera>().ScreenToWorldPoint(mousePos);
		// 	RaycastHit2D hit = Physics2D.Raycast(screenPos,Vector2.zero);

		// 	if (hit.collider != null) {
		// 		GameObject obj = hit.collider.gameObject;
		// 		Tile tile = obj.GetComponent<Tile>();
		// 		if(tile != null){
		// 			if(selectedTile != null){
		// 				selectedTile.setSelected(false);
		// 			}
		// 			selectedTile = tile;
		// 			tile.setSelected();
		// 			tile.click();
		// 		}
		// 	}
		// }



		// if(Input.GetKey("1")){
		// 	GameObject[] tiles = GameObject.Find("Map").GetComponent<Map>().tiles;
		// 	foreach(GameObject go in tiles){
		// 		Tile tile = go.GetComponent<Tile>();
		// 		tile.setDisplayMode(DisplayMode.Terrain);
		// 	}
		// } else if(Input.GetKey("2")){
		// 	GameObject[] tiles = GameObject.Find("Map").GetComponent<Map>().tiles;
		// 	foreach(GameObject go in tiles){
		// 		Tile tile = go.GetComponent<Tile>();
		// 		tile.setDisplayMode(DisplayMode.Forestry);
		// 	}
		// }
	}

	// void OnGUI() {
	// 	if(Input.GetKey("p")){
	//         GUI.BeginGroup(new Rect(Screen.width/2-50, Screen.height/2-50, 100, 100));
	//         GUI.Box(new Rect(0,0,100,100), "Group is here");
	//         GUI.Button(new Rect(10,40,80,30), "Click me");
	//         GUI.EndGroup();
 //    	}

 //    	GUI.BeginGroup(new Rect(0, Screen.height-100, Screen.width, 100));
 //    	GUI.Box(new Rect(0,0,Screen.width,100), "Group is here");
 //    	if(GUI.Button(new Rect(100,30,80,30), "Click me")){
 //    		if(selectedTile != null){
 //    			selectedTile.setDisplayMode(DisplayMode.Forestry);
 //    		}
 //    		Debug.Log("button press");
 //    	}
	// 	GUI.EndGroup();


 //    }
}
