using UnityEngine;
using System.Collections;

public class MapmodeButtonScript : MonoBehaviour {

	public void terrainMapmode(){
		GameObject[] tiles = GameObject.Find("Map").GetComponent<Map>().tiles;
		foreach(GameObject go in tiles){
			Tile tile = go.GetComponent<Tile>();
			tile.setDisplayMode(DisplayMode.Terrain);
		}
	}

	public void OnClick(){
		GameObject[] tiles = GameObject.Find("Map").GetComponent<Map>().tiles;
		foreach(GameObject go in tiles){
			Tile tile = go.GetComponent<Tile>();
			tile.setDisplayMode(DisplayMode.Forestry);
		}
	}
}
