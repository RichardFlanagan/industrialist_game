using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

	public GameObject tilePrefab;
	public int mapWidth = 128;
	public int mapHeight = 96;
	public GameObject[] tiles;
	
	public Texture2D heightTexture;
	public Texture2D climateTexture;
	public Texture2D humidityTexture;
	public Texture2D forestTexture;
	
	private float tileWidth;
	private float tileHeight;

	void Start () {
		// Create a new array
		tiles = new GameObject[mapWidth*mapHeight];

		// Generate the texture that will be used for the terrain height, climate, humidity and forest cover
		// heightTexture = new TextureCreator().generateTerrainTexture(this.transform);
		// climateTexture = new TextureCreator().generateForestTexture(this.transform);
		// humidityTexture = new TextureCreator().generateForestTexture(this.transform);
		// forestTexture = new TextureCreator().generateForestTexture(this.transform);

        JSONLoader jsl = JSONLoader.fromJSON("Data/terrain_texture_parameters");
		TerrainTextureDataObject heightTextureDescription = jsl.terrainTextureParameters[0];
        TerrainTextureDataObject forestTextureDescription = jsl.terrainTextureParameters[1];
        
		heightTexture = new TextureCreator().generateTexture(this.transform, heightTextureDescription);
		forestTexture = new TextureCreator().generateTexture(this.transform, forestTextureDescription);

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
		// Tile
		GameObject tile = (GameObject) Instantiate(tilePrefab, pos, Quaternion.identity);
		tile.transform.parent = this.gameObject.transform;
		
		MapTile mapTile = tile.GetComponent<MapTile>();
		mapTile.id = (i*mapWidth+j);

		float terrainPixel = heightTexture.GetPixel(i, j).r;
		float forestPixel = forestTexture.GetPixel(i, j).r;
		MapTileTerrain terrain = new MapTileTerrain(terrainPixel, forestPixel);
		mapTile.setTerrain(terrain);
		
		// Terrain
		// TileTerrains.TileTerrain terrain;
		// terrain = TileTerrains.getTerrain(terrainTexture.GetPixel(i, j).r);
		// mapTile.setTerrain(terrain);

		// Resources
		// TileResources.TileResource resource;
		// resource = TileResources.getResource(terrain, forestTexture.GetPixel(i, j).r);
		// mapTile.setResource(resource);

		tiles[mapTile.id] = tile;
	}


	public void findTile(Vector2 pos){
		int index = (int) (pos.y / tileHeight) * 10 + (int) (pos.x / tileWidth);
		tiles[index].GetComponent<MapTile>().click();

		Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pz.z = 0;
		Debug.Log(pz);
	}

}
