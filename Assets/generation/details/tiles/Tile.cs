using System;
using UnityEngine;

public class Tile : MonoBehaviour{
	private enum BASE_LEVELS {none, green, yellow, red};

	public int x { get; set; }
	public int y { get; set; }
	public int base_level { get; set; }
	public int soldiers { get; set; }
	public int generating_soldiers_in_hour { get; set; }
	public DateTime soldiers_arriving { get; set; }
	public DateTime battle_start { get; set; }

}
