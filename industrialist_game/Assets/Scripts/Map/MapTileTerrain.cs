using UnityEngine;
using System.Collections;

public class MapTileTerrain {

	public Sprite flatlandsMapSprite;
	public Sprite hillsMapSprite;
	public Sprite mountainsMapSprite;

	public Sprite forestedFlatlandsMapSprite;
	public Sprite forestedHillsMapSprite;
	public Sprite forestedMountainsMapSprite;

	public Sprite waterMapSprite;


	public enum TerrainType {
		Flatland,
		Hill,
		Mountain,
		Water
	};
	public TerrainType type;
	public bool forested = false;

	private string name;
	private Color color;
	private Sprite sprite;

	public MapTileTerrain(){}

	public MapTileTerrain(float terrainPixel, float forestedPixel){
		type = checkType(terrainPixel);
		forested = checkForested(forestedPixel);
		create();
	}

	private TerrainType checkType(float pixel){
		TerrainType terrainType;
		if(pixel > 0.65f){
			terrainType = TerrainType.Mountain;
		} else if(pixel > 0.6f){
			terrainType = TerrainType.Hill;
		} else if(pixel >= 0.5f){
			terrainType = TerrainType.Flatland;
		} else {
			terrainType = TerrainType.Water;
		}
		return terrainType;
	}

	private bool checkForested(float pixel){
		return (pixel > 0.5f);
	}

	private void create(){
		if(forested){
			if(type == TerrainType.Flatland){
				name = "Forest";
				color = new Color(0.13f, 0.54f, 0.13f);
				sprite = forestedFlatlandsMapSprite;
			} else if(type == TerrainType.Hill){
				name = "Forested Hill";
				color = new Color(0.0f, 0.39f, 0.0f);
				sprite = forestedHillsMapSprite;
			} else if(type == TerrainType.Mountain){
				name = "Forested Mountain";
				color = new Color(0.33f, 0.42f, 0.18f);
				sprite = forestedMountainsMapSprite;
			} else {
				name = "Water";
				color = new Color(0.12f, 0.44f, 1.0f);
				sprite = waterMapSprite;
			}
		} else {
			if(type == TerrainType.Flatland){
				name = "Flatlands";
				color = new Color(0.20f, 0.80f, 0.20f);
				sprite = flatlandsMapSprite;
			} else if(type == TerrainType.Hill){
				name = "Hill";
				color = new Color(0.68f, 1.0f, 0.18f);
				sprite = hillsMapSprite;
			} else if(type == TerrainType.Mountain){
				name = "Mountain";
				color = new Color(0.5f, 0.5f, 0.5f);
				sprite = mountainsMapSprite;
			} else {
				name = "Water";
				color = new Color(0.12f, 0.44f, 1.0f);
				sprite = waterMapSprite;
			}
		}
		
	}

	public TerrainType getType(){
		return type;
	}

	public bool isForested(){
		return forested;
	}

	public string getName(){
		return name;
	}

	public Color getColor(){
		return color;
	}

	public Sprite getSprite(){
		return sprite;
	}
	
}
