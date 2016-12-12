using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

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

public class Tile : MonoBehaviour, IPointerClickHandler {

	private int id = 0;
	private TileTerrain terrain;
	private TileForestry forestry;
	private TileDistrict district;
	private bool selected = false;

	public void OnPointerClick(PointerEventData eventData){
		Debug.Log(
			"ID: " + id +
			"\n" + forestry.name + "ly Forested " + terrain.name + 
			"\nTerrain: " + terrain.name +
			"\nForestry: " + forestry.name +
			"\nPosition: " + gameObject.transform.position
		);

		this.GetComponent<SpriteRenderer>().color = new Color(1.0f,1.0f,1.0f);
		this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/Farmland");
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

	public void setDistrict(ref TileDistrict district){
		this.district = district;
	}

	public void setDisplayMode(DisplayMode mode){
		if(mode == DisplayMode.Terrain){
			//this.GetComponent<SpriteRenderer>().sprite = null;
			this.GetComponent<SpriteRenderer>().color = terrain.color.getColor();
		} else if(mode == DisplayMode.Forestry){
			//this.GetComponent<SpriteRenderer>().sprite = null;
			this.GetComponent<SpriteRenderer>().color = forestry.color.getColor();
		} else if(mode == DisplayMode.District){
			setDisplayMode(DisplayMode.Terrain);
			if(this.district != null){
				this.GetComponent<SpriteRenderer>().color = new Color(1.0f,1.0f,1.0f);
				this.GetComponent<SpriteRenderer>().sprite = district.sprite;
			} else{
				setDisplayMode(DisplayMode.Terrain);
			}
		}
	}

	public void setSelected(bool selected = true){
		this.selected = selected;
	}

	public bool isSelected(){
		return selected;
	}

	public int getId(){ return id; }
	public TileTerrain getTerrain(){ return terrain; }
	public TileForestry getForestry(){ return forestry; }
	public TileDistrict getDistrict(){ return district; }
}
