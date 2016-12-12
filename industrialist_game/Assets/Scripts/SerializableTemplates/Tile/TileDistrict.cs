using UnityEngine;
using System.Collections;

[System.Serializable]
public class TileDistrict : Loadable<TileTerrain> {
	public string name = "";
	public string image = "";
	public Sprite sprite;

	void Start(){
		sprite = Resources.Load<Sprite>(image);
	}
}
