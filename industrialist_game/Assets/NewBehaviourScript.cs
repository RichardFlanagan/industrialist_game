using UnityEngine;
using System.Collections;

public enum TerrainHeight {
	Flat,
	Hill,
	Mountain,
	Water
};

public enum TerrainClimate {
	Hot,
	Temperate,
	Cool
};

public enum TerrainHumidity {
	Dry,
	Average,
	Wet
};

public class TileInfo {
	private TerrainHeight height;
	private TerrainClimate climate;
	private TerrainHumidity humidity;
	private bool forested;

	public TileInfo(){
		height = TerrainHeight.Flat;
		climate = TerrainClimate.Temperate;
		humidity = TerrainHumidity.Average;
		forested = false;
	}

}
