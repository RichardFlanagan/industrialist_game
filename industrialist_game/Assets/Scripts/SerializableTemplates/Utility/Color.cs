using UnityEngine;
using System.Collections;

[System.Serializable]
public class SerializableColor : Loadable<SerializableColor> {
	public float r = 0;
	public float g = 0;
	public float b = 0;
	public Color getColor(){
		return new Color(r,g,b);
	}
}
