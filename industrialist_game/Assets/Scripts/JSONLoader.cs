using UnityEngine;
using System.Collections;

[System.Serializable]
public class JSONLoader {
	
	public TerrainTextureDataObject[] terrainTextureParameters;

	public static JSONLoader fromJSON(string path){
		TextAsset asset = Resources.Load(path) as TextAsset;
		return JsonUtility.FromJson<JSONLoader>(asset.text);
	}

}
