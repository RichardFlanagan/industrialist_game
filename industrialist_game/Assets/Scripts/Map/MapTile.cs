using UnityEngine;
using System.Collections;

public class MapTile : MonoBehaviour {

	public int id;
	//public TileTerrains.TileTerrain terrain;
	public MapTileTerrain terrain;
	//public TileResources.TileResource resource;
	private GameObject resourceIcon = null;

	void Start () {
		//setResource(new TileResources.EmptyResource());
	}
	
	void Update () {}

	// public void setTerrain(TileTerrains.TileTerrain terrain){
	// 	this.terrain = terrain;
	// 	this.GetComponent<SpriteRenderer>().color = terrain.color;
	// }

	public void click(){
		print("ID: " + id);
		print("Terrain: " + terrain.getName());
		print("Position: " + gameObject.transform.position);
	}

	public void setTerrain(MapTileTerrain terrain){
		this.terrain = terrain;
		this.GetComponent<SpriteRenderer>().color = terrain.getColor();
	}

	public void setResourceIconsDisplay(bool display){
		resourceIcon.GetComponent<SpriteRenderer>().enabled = display;
	}

	// public void setResource(TileResources.TileResource resource){
	// 	this.resource = resource;

	// 	if(resourceIcon == null){
	// 		resourceIcon = new GameObject();
	// 		resourceIcon.name = "ResourceIcon";
	// 		SpriteRenderer renderer = resourceIcon.AddComponent<SpriteRenderer>();
	// 		//renderer.sprite = resource.sprite;
	// 		renderer.sortingOrder = 1;
	// 		resourceIcon.transform.parent = this.transform;

	// 		float offset = this.GetComponent<SpriteRenderer>().bounds.extents.y*0.5f;
	// 		resourceIcon.transform.position = new Vector3(
	// 			this.transform.position.x, 
	// 			this.transform.position.y - offset, 
	// 			this.transform.position.z);
	// 	}
	// 	resourceIcon.GetComponent<SpriteRenderer>().sprite = resource.sprite;
	// }
}
