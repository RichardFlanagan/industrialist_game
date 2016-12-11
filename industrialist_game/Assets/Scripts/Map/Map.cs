using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

	public GameObject tilePrefab;
	public int mapWidth = 128;
	public int mapHeight = 96;
	public GameObject[] tiles;
	
	public Texture2D heightTexture;
	//public Texture2D forestTexture;
	
	private float tileWidth;
	private float tileHeight;

	private JSONLoader dataFiles;

	void Start () {
		// Create a new array
		tiles = new GameObject[mapWidth*mapHeight];

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

		
		// Load data files
        dataFiles = JSONLoader.fromJSON("Data/terrain_texture_parameters");

        // Generate the texture that will be used for the terrain height, climate, humidity and forest cover
		heightTexture = new TextureCreator().generateTexture(this.transform, dataFiles.textureParameters[0]);
		//forestTexture = new TextureCreator().generateTexture(this.transform, dataFiles.textureParameters[1]);

		tileWidth = tilePrefab.GetComponent<SpriteRenderer>().bounds.size.x;
		tileHeight = tilePrefab.GetComponent<SpriteRenderer>().bounds.size.y;

		generateGrid();
	}

	void Update(){}

	void generateGrid(){
		/*
			Regular hexagon
			Bounding box = 1 unit
			Then sidelength = 0.5 unit
			/\	0.25
		   | |	0.5
		   \/	0.25
		   Offset is now 0.75 as the top 0.25 slots into the previous row bottom
		*/

		int xStart = (int) (mapWidth * tileWidth * 0.5f);
		int yStart = (int) (mapHeight * tileHeight * 0.75f * 0.5f);

		for(int i=0; i<mapHeight; i++){
			for(int j=0; j<mapWidth; j++){
				float xOffset = (i%2==0) ? 0.0f : (tileWidth * 0.5f);
				Vector2 pos = new Vector2(
					(tileWidth * j) + xOffset - xStart, 
					(tileHeight * 0.75f* i) - yStart
				);

				createTile(i, j, pos);
			}
		}
	}

	void createTile(int i, int j, Vector2 pos){
		GameObject tileGameObject = (GameObject) Instantiate(tilePrefab, pos, Quaternion.identity);
		tileGameObject.transform.parent = this.gameObject.transform;
		
		Tile tile = tileGameObject.GetComponent<Tile>();
		tile.setId(i*mapWidth+j);

		float terrainPixel = heightTexture.GetPixel(i, j).r;
		for(int n=0; n < dataFiles.tileTerrainTypes.Length; n++){
			TileTerrain item = dataFiles.tileTerrainTypes[n];
			if( (item.range.min <= terrainPixel) && (item.range.max > terrainPixel) ){
				tile.setTerrain(ref item);
			}
		}

		tiles[tile.getId()] = tileGameObject;
	}

}
