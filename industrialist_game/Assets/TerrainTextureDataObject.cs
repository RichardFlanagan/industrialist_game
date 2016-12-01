﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class TerrainTextureDataObject {

	public string name = "Procedural terrain texture";
	public int resolution = 256;
	public float frequency = 6.0f;
	public int octaves = 6;
	public float lacunarity = 2.0f;
	public float persistence = 0.75f;
	public int dimensions = 2;
	public int scale = 1;

	public static TerrainTextureDataObject fromJSON(string jsonString){
		return JsonUtility.FromJson<TerrainTextureDataObject>(jsonString);
	}

}
