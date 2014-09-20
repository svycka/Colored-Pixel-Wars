using UnityEngine;
using System.Collections;

public class MapGeneration : MonoBehaviour {
	private const int MAP_SIZE_X = 50;
	private const int MAP_SIZE_Y = 50;

	void Start () {
		float nextPositionX = 0;
		float nextPositionY = 0;
		for(int x = 0; x < MAP_SIZE_X; x++){
			for(int y = 0; y < MAP_SIZE_Y; y++){
				GameObject tile = GameObject.CreatePrimitive(PrimitiveType.Plane);
				tile.transform.position = new Vector3(x + nextPositionX, y + nextPositionY, 0);
				tile.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
				tile.transform.Rotate (new Vector3 (-90, 0, 0));
				tile.AddComponent ("Tile");
				tile.name = "tile";
				tile.tag = "notActiveTile";
				nextPositionY += 0.1f;
			}
			nextPositionX += 0.1f;
			nextPositionY = 0;
		}

	}

	void Update () {
	
	}
}
