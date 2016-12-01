using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

	public GameObject tilePrefab;
	public int mapWidth = 128;
	public int mapHeight = 96;
	public GameObject[] tiles;
	
	private Texture2D terrainTexture;
	private Texture2D forestTexture;
	
	private float tileWidth;
	private float tileHeight;

	void Start () {
		tiles = new GameObject[mapWidth*mapHeight];
		terrainTexture = new TextureCreator().generateTerrainTexture(this.transform);
		forestTexture = new TextureCreator().generateForestTexture(this.transform);

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
				Vector3 pos = new Vector3(
					(tileWidth * j) + xOffset - xStart, 
					(tileHeight * 0.75f* i) - yStart, 
					0
				);

				createTile(i, j, pos);
			}
		}
	}

	void createTile(int i, int j, Vector3 pos){
		// Tile
		GameObject tile = (GameObject) Instantiate(tilePrefab, pos, Quaternion.identity);
		tile.transform.parent = this.gameObject.transform;
		
		MapTile mapTile = tile.GetComponent<MapTile>();
		mapTile.id = (i*mapWidth+j);

		float terrainPixel = terrainTexture.GetPixel(i, j).r;
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
