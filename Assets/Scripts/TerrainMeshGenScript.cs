using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class TerrainMeshGenScript : MonoBehaviour {

	Mesh mesh;

	Vector3[] verts;
	int[] tris;

	public int xSize = 20, zSize = 20;
	public int xOffset, zOffset;
	public float pStrength = 2.0f;
	public float pScale = 0.3f;

	void Start () {
		mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;

		CreateShape();
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMesh();
	}

	void CreateShape(){
		verts = new Vector3[(xSize + 1) * (zSize + 1)];

		
		for (int z = 0, i = 0; z <= zSize; z++){

			for (int x = 0; x <= xSize; x++){

				float y = Mathf.PerlinNoise(x * pScale + xOffset, z * pScale + zOffset) * pStrength;
				Debug.Log(y);
			//experimental, trying to level out sea floor
				float _y = y;
				if(_y < (pStrength*pScale)){ _y = 0.0f;}
			//			
				verts[i] = new Vector3(x, _y, z);
				
				i++;
			}
		}

		tris = new int[xSize * zSize * 6];

		int vert = 0; // a counter to add offset after each triangle-pair is created
		int triangle = 0;
		int xRows = 0;

		for (int h = 0; h < zSize; h++)
		{
			for (int i = 0; i < xSize; i++)
			{
				

			
				tris[triangle + 0] = vert + 0;
				tris[triangle + 1] = vert + xSize + 1;
				tris[triangle + 2] = vert + 1;
				tris[triangle + 3] = vert + 1;
				tris[triangle + 4] = vert + xSize + 1;
				tris[triangle + 5] = vert + xSize + 2;

				vert++;
				triangle += 6;

			}
			vert++;
		}
		

		
		
		/* verts = new Vector3[]
		{
			new Vector3(0,0,0)
			new Vector3(0,0,1)
			new Vector3(1,0,0)
			new Vector3
		}; */
	}

	void UpdateMesh(){
		mesh.Clear();

		mesh.vertices = verts;
		mesh.triangles = tris;

		mesh.RecalculateNormals();
	}

	private void OnDrawGizmos() {
		
		if(verts == null)
			return;

		for (int i = 0; i < verts.Length; i++)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(verts[i], .1f);
		}
	}
}
