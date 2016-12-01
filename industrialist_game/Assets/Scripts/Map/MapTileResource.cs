using UnityEngine;
using System.Collections;

public class MapTileResource : MonoBehaviour {

	public Sprite woodMapSprite;
	public Sprite ironMapSprite;
	public Sprite coalMapSprite;

	public enum MapTileResourceType {
		Empty,
		Wood,
		Coal,
		Iron
	}
	public MapTileResourceType type;

	private Color color;
	private Sprite sprite;

	void Start () {
		if(type == MapTileResourceType.Empty){
			color = new Color(0.3f, 0.7f, 0.3f);
			sprite = null;
		} else if(type == MapTileResourceType.Wood){
			color = new Color(0.55f, 0.25f, 0.1f);
			sprite = woodMapSprite;
		} else if(type == MapTileResourceType.Coal){
			color = new Color(0.4f, 0.4f, 0.4f);
			sprite = ironMapSprite;
		} else if(type == MapTileResourceType.Iron){
			color = new Color(0.2f, 0.2f, 0.2f);
			sprite = coalMapSprite;
		}
	}

	void Update () {}

	public MapTileResourceType getType(){
		return type;
	}

	public Color getColor(){
		return color;
	}

	public Sprite getSprite(){
		return sprite;
	}
	
}
