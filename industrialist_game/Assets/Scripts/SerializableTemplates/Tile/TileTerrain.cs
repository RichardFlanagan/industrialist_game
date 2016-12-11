using UnityEngine;
using System.Collections;

[System.Serializable]
public class TileTerrain : Loadable<TileTerrain> {
	public string name = "";
	public SerializableRange range;
	public SerializableColor color;
	public float forestryFactor;
}
