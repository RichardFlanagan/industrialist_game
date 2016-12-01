using UnityEngine;

// http://catlikecoding.com/unity/tutorials/noise/
public class TextureCreator {

	private int resolution = 256;
	private float frequency = 6.0f;
	private int octaves = 6;
	private float lacunarity = 2.0f;
	private float persistence = 0.75f;
	private int dimensions = 2;

	public NoiseMethodType type;
	[Range(-10000, 10000)]
	public int seed = 0;
	public int scale = 1;


	public Texture2D generateTerrainTexture(Transform parent){
		resolution = 256;
		frequency = 6.0f;
		octaves = 6;
		lacunarity = 2.0f;
		persistence = 0.75f;
		dimensions = 2;

		Texture2D texture = createtexture("Procedural terrain texture");
		generateTexture(texture, parent);
		return texture;
	}

	public Texture2D generateForestTexture(Transform parent){
		resolution = 256;
		frequency = 4.0f;
		octaves = 32;
		lacunarity = 10.0f;
		persistence = 0.9f;
		dimensions = 2;

		Texture2D texture = createtexture("Procedural terrain texture");
		generateTexture(texture, parent);
		return texture;
	}

	private Texture2D createtexture(string textureName){
		Texture2D texture = new Texture2D(resolution, resolution, TextureFormat.RGB24, true);
		texture.name = textureName;
		texture.wrapMode = TextureWrapMode.Clamp;
		texture.filterMode = FilterMode.Trilinear;
		texture.anisoLevel = 9;
		return texture;
	}

	
	private void generateTexture(Texture2D texture, Transform parent) {
		//seed = Random.Range(0, 100);
		//Debug.Log(seed);

		Vector3 point00 = parent.TransformPoint(new Vector3(seed, seed));
		Vector3 point10 = parent.TransformPoint(new Vector3(seed+scale, seed));
		Vector3 point01 = parent.TransformPoint(new Vector3(seed, seed+scale));
		Vector3 point11 = parent.TransformPoint(new Vector3(seed+scale, seed+scale));

		NoiseMethod method = Noise.methods[(int)type][dimensions - 1];
		float stepSize = 1.0f / resolution;
		for (int y = 0; y < resolution; y++) {
			Vector3 point0 = Vector3.Lerp(point00, point01, (y + 0.5f) * stepSize);
			Vector3 point1 = Vector3.Lerp(point10, point11, (y + 0.5f) * stepSize);
			for (int x = 0; x < resolution; x++) {
				Vector3 point = Vector3.Lerp(point0, point1, (x + 0.5f) * stepSize);
				float sample = Noise.Sum(method, point, frequency, octaves, lacunarity, persistence);
				if (type != NoiseMethodType.Value) {
					sample = sample * 0.5f + 0.5f;
				}
				texture.SetPixel(x, y, new Color(sample, sample, sample));
			}
		}
		texture.Apply();
	}
}



// using UnityEngine;

// // http://catlikecoding.com/unity/tutorials/noise/
// public class TextureCreator : MonoBehaviour {

// 	// [Range(2, 512)]
// 	// public int resolution = 256;
	
// 	// public float frequency = 6.0f;
	
// 	// [Range(1, 8)]
// 	// public int octaves = 6;

// 	// [Range(1f, 4f)]
// 	// public float lacunarity = 2f;

// 	// [Range(0f, 1f)]
// 	// public float persistence = 0.75f;

// 	// [Range(1, 3)]
// 	// public int dimensions = 2;

// 	public NoiseMethodType type;
// 	public Texture2D texture;

// 	private int resolution = 256;
// 	private float frequency = 6.0f;
// 	private int octaves = 6;
// 	private float lacunarity = 2.0f;
// 	private float persistence = 0.75f;
// 	private int dimensions = 2;

// 	[Range(-10000, 10000)]
// 	public int seed = 0;
// 	public int scale = 1;


// 	public void createTexture () {
// 		if (texture == null) {
// 			texture = new Texture2D(resolution, resolution, TextureFormat.RGB24, true);
// 			texture.name = "Procedural Texture";
// 			texture.wrapMode = TextureWrapMode.Clamp;
// 			texture.filterMode = FilterMode.Trilinear;
// 			texture.anisoLevel = 9;
// 		}
// 		generateTexture();
// 	}
	
// 	private void generateTexture () {
// 		if (texture.width != resolution) {
// 			texture.Resize(resolution, resolution);
// 		}
		
// 		// Vector3 point00 = transform.TransformPoint(new Vector3(-0.5f,-0.5f));
// 		// Vector3 point10 = transform.TransformPoint(new Vector3( 0.5f,-0.5f));
// 		// Vector3 point01 = transform.TransformPoint(new Vector3(-0.5f, 0.5f));
// 		// Vector3 point11 = transform.TransformPoint(new Vector3( 0.5f, 0.5f));

// 		//int seed = Random.Range(-10000, 10000);
// 		//int scale = 1;

// 		Vector3 point00 = transform.TransformPoint(new Vector3(seed, seed));
// 		Vector3 point10 = transform.TransformPoint(new Vector3(seed+scale, seed));
// 		Vector3 point01 = transform.TransformPoint(new Vector3(seed, seed+scale));
// 		Vector3 point11 = transform.TransformPoint(new Vector3(seed+scale, seed+scale));

// 		NoiseMethod method = Noise.methods[(int)type][dimensions - 1];
// 		float stepSize = 1f / resolution;
// 		for (int y = 0; y < resolution; y++) {
// 			Vector3 point0 = Vector3.Lerp(point00, point01, (y + 0.5f) * stepSize);
// 			Vector3 point1 = Vector3.Lerp(point10, point11, (y + 0.5f) * stepSize);
// 			for (int x = 0; x < resolution; x++) {
// 				Vector3 point = Vector3.Lerp(point0, point1, (x + 0.5f) * stepSize);
// 				float sample = Noise.Sum(method, point, frequency, octaves, lacunarity, persistence);
// 				if (type != NoiseMethodType.Value) {
// 					sample = sample * 0.5f + 0.5f;
// 				}

// 				texture.SetPixel(x, y, new Color(sample, sample, sample));
// 			}
// 		}
// 		texture.Apply();
// 	}
// }