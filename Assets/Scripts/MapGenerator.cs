﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {


	public bool autoUpdate;
	public int mapWidth, mapHeight;
	public float noiseScale;

	public int octaves;

	[Range (0,1)]
	public float persistence;
	public float lacunarity;
	//public GameObject noise;

	public int seed;
	public Vector2 offset;

	public void GenerateMap(){
		float[,] noiseMap = NoiseGenerator.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistence, lacunarity, offset);

		MapDisplay display = FindObjectOfType<MapDisplay>();
		display.DrawNoiseMap(noiseMap);
	}

	void OnValidate(){
		if(mapWidth < 1)
			mapWidth = 1;

		if(mapHeight < 1)
			mapHeight = 1;

		if(lacunarity < 1)
			lacunarity = 1;

		if(octaves < 0)
			octaves = 0;
	}

}
