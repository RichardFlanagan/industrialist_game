using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	private int id = 0;
	private TileTerrain terrain;
	private TileForestry forestry;

	Tile(){}

	public void click(){
		Debug.Log(
			"ID: " + id +
			"\nTerrain: " + terrain.name +
			"\nPosition: " + gameObject.transform.position
		);
	}

	public void setId(int id){
		this.id = id;
	}

	public void setTerrain(ref TileTerrain terrain){
		this.terrain = terrain;
		this.GetComponent<SpriteRenderer>().color = terrain.color.getColor();
	}
	
	public void setForestry(ref TileForestry forestry){
		this.forestry = forestry;
	}

	public int getId(){ return id; }
	public TileTerrain getTerrain(){ return terrain; }
	public TileForestry getForestry(){ return forestry; }
}
