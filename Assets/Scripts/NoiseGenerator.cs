using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NoiseGenerator {

	
	public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int octaves, float persistence, float lacunarity, Vector2 offsetParam){

		float[,] noiseMap = new float[mapWidth, mapHeight];
		
		System.Random prng = new System.Random(seed);
		//PsuedoRandom No Generator
		Vector2[] octaveOffsets = new Vector2[octaves];
		for (int i = 0; i < octaves; i++)
		{
			float offsetX = prng.Next(-100000, 100000) + offsetParam.x;
			float offsetY = prng.Next(-100000, 100000) + offsetParam.y;
			octaveOffsets[i] = new Vector2 (offsetX, offsetY);
		}

		if(scale <= 0){ 
			scale = 0.0001f;
		}
			

		float maxNoiseHeight = float.MinValue;
		float minNoiseHeight = float.MaxValue;

		float halfWidth = mapWidth / 2.0f;
		float halfHeight = mapHeight / 2.0f;

		for (int y = 0; y < mapHeight; y++)
		{

			for (int x = 0; x < mapWidth; x++)
			{
				float amplitude = 1;
				float frequency = 1;
				float noiseHeight = 0;

				for (int i = 0; i < octaves; i++)
				{
					float sampleX = (x-halfWidth) / scale * frequency + octaveOffsets[i].x;
					float sampleY = (y-halfHeight) / scale * frequency + octaveOffsets[i].y;

					float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
					noiseHeight += perlinValue * amplitude;
					noiseMap [x, y] = perlinValue;

					amplitude *= persistence;
					frequency *= lacunarity;
				}

				if (noiseHeight > maxNoiseHeight){
					maxNoiseHeight = noiseHeight;
					}else if (noiseHeight < minNoiseHeight ){
						minNoiseHeight = noiseHeight;
				}
				noiseMap[x, y] = noiseHeight;
			}

		}
		
		for (int y = 0; y < mapHeight; y++)
		{
			for (int x = 0; x < mapWidth; x++)
			{
				noiseMap[x,y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap [x, y]);
			//Normalizes noiseMap values
			}

		}
		return noiseMap;
	}

}
