using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants {
	// When the game starts, a ship's maximum speed is DEFAULT...
	//  The highest it can get is MAXIMUM...
	public static readonly float MAXIMUMSHIPSPEED = 45.0f;
	public static readonly float DEFAULTMAXSHIPSPEED = 18.0f;

	// When the game starts, a ship's turnspeed is DEFAULT...
	//  The highest it can get is MAXIMUM...
	public static readonly float MAXIMUMTURNSPEED = 6.0f;
	public static readonly float DEFAULTTURNSPEED = 2.0f;

	// When the game starts, a ship's acceleration is DEFAULT...
	//  The highest it can get is MAXIMUM...
	public static readonly float MAXIMUMSHIPACCELERATION = 550000.0f;
	public static readonly float DEFAULTSHIPACCELERATION = 150000.0f;
	
	public static readonly float MAXIMUMSHIPHEALTH = 1000.0f;
	public static readonly float MAXIMUMSHIPSHIELD = 500.0f;

    public static readonly float MINIMUMDAMAGE = 20.0f;
    public static readonly float MAXIMUMDAMAGE = 100.0f;

	// A crate disappears after this many seconds
	public static readonly float CRATETIMEOUT = 45.0f;

    public static readonly float SHELLFORCE = 1500.0f;

	public static readonly float MpS_TO_KNOTS = 1.94384f;
	public enum UpgradeTypes {
		ACCELERATION, MAXSPEED, HEALTH, SHIELD, TURNSPEED
	}
}
