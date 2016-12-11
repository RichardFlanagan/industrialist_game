using UnityEngine;
using System.Collections;

[System.Serializable]
public class JSONLoader {
	
	public TextureParameters[] textureParameters;
	public TileHeightType[] tileHeightTypes;
	public TileForestryType[] tileForestryTypes;

	public static JSONLoader fromJSON(string path){
		TextAsset asset = Resources.Load(path) as TextAsset;
		return JsonUtility.FromJson<JSONLoader>(asset.text);
	}

}
