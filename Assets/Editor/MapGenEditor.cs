using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof (MapGenerator))]
public class MapGenEditor : Editor {

	public override void OnInspectorGUI() {
		MapGenerator mapGen = (MapGenerator)target; // the object the Editor is inspecting, "target", is cast as 
													//a MapGenerator, and stored as reference
		if(DrawDefaultInspector()){
			if (mapGen.autoUpdate){
				mapGen.GenerateMap();
			}
		}

		if(GUILayout.Button("Generate")){
			mapGen.GenerateMap();
		}
	}
}
