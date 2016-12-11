using UnityEngine;

public class TextureCreator {

	private NoiseMethodType type = NoiseMethodType.Value;
	private int seed = 0;

	public TextureCreator(){
		regenerateSeed();
	}

	public TextureCreator(int seed){
		setSeed(seed);
	}

	/**
	 *	Generate a new pseudorandom seed. Seeds change the resulting texture
	 */
	public void regenerateSeed(){
		this.seed = Random.Range(-10000, 10000);
	}

	/**
	 *	Set the seed
	 */
	public void setSeed(int seed){
		if(seed > -10000 && seed < 10000){
			this.seed = seed;
		}
	}

	/**
	 *	Generate a new procedural texture
	 */
	public Texture2D generateTexture(Transform parent, TextureParameters textureDescription){
		Texture2D texture = createTextureContainer(textureDescription.name, textureDescription.resolution);
		generateTexture(texture, parent, textureDescription);
		return texture;
	}


	/**
	 *	Create and configure a blank Texture2D object
	 */
	private Texture2D createTextureContainer(string textureName, int textureResolution){
		Texture2D texture = new Texture2D(textureResolution, textureResolution, TextureFormat.RGB24, true);
		texture.name = textureName;
		texture.wrapMode = TextureWrapMode.Clamp;
		texture.filterMode = FilterMode.Trilinear;
		texture.anisoLevel = 9;
		return texture;
	}
	
	/**
	 *	Generate a new procedural texture
	 *  http://catlikecoding.com/unity/tutorials/noise/
	 */
	private void generateTexture(Texture2D texture, Transform parent, TextureParameters args) {
		int scale = args.scale;
		int resolution = args.resolution;

		Vector3 point00 = parent.TransformPoint(new Vector3(seed, seed));
		Vector3 point10 = parent.TransformPoint(new Vector3(seed+scale, seed));
		Vector3 point01 = parent.TransformPoint(new Vector3(seed, seed+scale));
		Vector3 point11 = parent.TransformPoint(new Vector3(seed+scale, seed+scale));

		NoiseMethod method = Noise.methods[(int)type][args.dimensions - 1];
		float stepSize = 1.0f / resolution;

		for (int y = 0; y < resolution; y++) {
			
			Vector3 point0 = Vector3.Lerp(point00, point01, (y + 0.5f) * stepSize);
			Vector3 point1 = Vector3.Lerp(point10, point11, (y + 0.5f) * stepSize);
			
			for (int x = 0; x < resolution; x++) {
				
				Vector3 point = Vector3.Lerp(point0, point1, (x + 0.5f) * stepSize);
				float sample = Noise.Sum(method, point, args.frequency, args.octaves, args.lacunarity, args.persistence);
				
				if (type != NoiseMethodType.Value) {
					sample = sample * 0.5f + 0.5f;
				}
				
				texture.SetPixel(x, y, new Color(sample, sample, sample));
			}
		}

		texture.Apply();
	}
}
