using UnityEngine;
using System.Collections;

/*
	Tile

	Height/type: flat, hill, mountain, water
	Tree: dense, medium, light
	Natural Resources: 
		Mineable: iron, coal
		Pumpable: oil, gas
		Surface?: game, horse
	Building/Complex:
		Mine: surface mine, primitive shaft mine, industial shaft maine, strip mine
		Forestry:
		Urban: village, agricultural hamlet, low/med/high density urban
		Commercial?: bank, megamall
		Industrial: brickmaker, cokefilds, industial park
		Military: barracks, citadel, castle
		Special: Palace, parliament
	Transport: none, beaten path, paved path, rail
	Fortification: none, palislade, stone wall, trench, fortification line

*/

public class Tile : MonoBehaviour {

	private int id = 0;
	private TileTerrain terrain;
	private TileForestry forestry;

	Tile(){}

	public void click(){
		Debug.Log(
			"ID: " + id +
			"\n" + forestry.name + "ly Forested " + terrain.name + 
			"\nTerrain: " + terrain.name +
			"\nForestry: " + forestry.name +
			"\nPosition: " + gameObject.transform.position
		);
	}

	public void setId(int id){
		this.id = id;
	}

	public void setTerrain(ref TileTerrain terrain){
		this.terrain = terrain;
	}
	
	public void setForestry(ref TileForestry forestry){
		this.forestry = forestry;
	}

	public void setDisplayMode(DisplayMode mode){
		if(mode == DisplayMode.Terrain){
			this.GetComponent<SpriteRenderer>().color = terrain.color.getColor();
		} else if(mode == DisplayMode.Forestry){
			//if(terrain.name == "Water"){
			//	this.GetComponent<SpriteRenderer>().color = terrain.color.getColor();
			//} else{
				this.GetComponent<SpriteRenderer>().color = forestry.color.getColor();
			//}
		}
	}

	public int getId(){ return id; }
	public TileTerrain getTerrain(){ return terrain; }
	public TileForestry getForestry(){ return forestry; }
}
