using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawnerScript : MonoBehaviour
{
    public GameObject crate;

    private List<Constants.UpgradeTypes> possibleUpgrades = new List<Constants.UpgradeTypes>();

    void setup_possible_upgrades()
    {
        possibleUpgrades.Add(Constants.UpgradeTypes.ACCELERATION);
        possibleUpgrades.Add(Constants.UpgradeTypes.ACCELERATION);
        possibleUpgrades.Add(Constants.UpgradeTypes.ACCELERATION);
        possibleUpgrades.Add(Constants.UpgradeTypes.SHIELD);
        possibleUpgrades.Add(Constants.UpgradeTypes.SHIELD);
        possibleUpgrades.Add(Constants.UpgradeTypes.SHIELD);
        possibleUpgrades.Add(Constants.UpgradeTypes.SHIELD);
        possibleUpgrades.Add(Constants.UpgradeTypes.SHIELD);
        possibleUpgrades.Add(Constants.UpgradeTypes.SHIELD);
        possibleUpgrades.Add(Constants.UpgradeTypes.SHIELD);
        possibleUpgrades.Add(Constants.UpgradeTypes.SHIELD);
        possibleUpgrades.Add(Constants.UpgradeTypes.SHIELD);
        possibleUpgrades.Add(Constants.UpgradeTypes.topSpeed);
        possibleUpgrades.Add(Constants.UpgradeTypes.topSpeed);
        possibleUpgrades.Add(Constants.UpgradeTypes.topSpeed);
        possibleUpgrades.Add(Constants.UpgradeTypes.topSpeed);
        possibleUpgrades.Add(Constants.UpgradeTypes.TURNSPEED);
        possibleUpgrades.Add(Constants.UpgradeTypes.TURNSPEED);
    }

    // Use this for initialization
    void Start()
    {
        setup_possible_upgrades();
        GameObject newCrate;
        for (int c = 0; c < 1000; c++)
        {
            newCrate = Instantiate(crate, transform.position, Quaternion.identity);
            newCrate.SetActive(false);
            newCrate.transform.parent = transform;
            availableCrates.Add(newCrate);
        }

        InvokeRepeating("spawn_crate", 0.0f, 0.3f);
    }

    void generate_crate_contents(GameObject newCrate, bool deathCrate = false)
    {
        Constants.UpgradeTypes crateType;
        float crateValue;

        // First of all, we want to decide what _type_ of thing we are going to put in the crate.
        // We are going to use the possibleUpgrades List to choose from among the possible types.
        // We need a random number:
        int rUpgrade = Random.Range(0, possibleUpgrades.Count);
        // We use our randam number as an index into the list...
        crateType = possibleUpgrades[rUpgrade];

        // Now we need to decide what the _value_ of the upgrade is
        //  We are going to use a "normalized" value for now. That is to say, the value 
        //  will be in the range 0.0f - 1.0f. We will convert it to the correct range
        //  afterwards. Unfortunately, we cannot just use a randomized value like we did
        //  for the _type_ of crate. 
        // Why not? The problem is that random numbers give us an even distribution,
        //  whereas what we want is mostly low numbers, some middling numbers, a few
        //  high numbers and tiny number of VERY high numbers.. If you think about RPGs 
        //  and Roguelikes, it's easy to find crappy items, but the best items are 
        //  extremely rare. We want the same thing....
        // C# does not provide for different random number distributions. Therefore, we
        //  are just going to generate floating-point numbers in the range 0.0f - 1.0f
        //  and then multiply them by themselves. This will reduce the prevalence
        //  of high numbers.
        float temp = Random.Range(0.0f, 1.0f);
        crateValue = (temp * temp * temp);
        if(deathCrate)
         {
             if(crateValue > 0.9f)
                {
                    crateValue += 1.0f;
                }
         }
        put_contents_in_crate(newCrate, crateType, crateValue);
    }

    // Remember, this value is in the range 0.0 to 1.0 (with a lot more low numbers than high numbers)
    void put_contents_in_crate(GameObject newCrate, Constants.UpgradeTypes type, float value)
    {
        // The contents of the crate are stored in its CrateContents script, so we have to 
        //  get a reference to it...
        CrateContents cc = newCrate.GetComponent<CrateContents>();

        // Setting the type is easy!
        cc.type = type;

        // But how we do the value depends on the range that it can take, and _that_ depends
        //  on what type of upgrade it is...
        // Each "leg" of this if ... else is going to work out the correct value for
        //  the relevant type of upgrade. But where will we get the correct constants 
        //  to send to de_normalise_value(...) ? 
         
            if (type == Constants.UpgradeTypes.ACCELERATION)
            {
                cc.value = de_normalise_value(value, Constants.DEFAULTSHIPACCELERATION, Constants.MAXIMUMSHIPACCELERATION);
            }
            else if (type == Constants.UpgradeTypes.topSpeed)
            {
                cc.value = de_normalise_value(value, Constants.DEFAULTMAXSHIPSPEED, Constants.MAXIMUMSHIPSPEED);
            }
            else if (type == Constants.UpgradeTypes.SHIELD)
            {
                cc.value = de_normalise_value(value, 0f, Constants.MAXIMUMSHIPSHIELD);
            }
            else if (type == Constants.UpgradeTypes.TURNSPEED)
            {
                cc.value = de_normalise_value(value, Constants.DEFAULTTURNSPEED, Constants.MAXIMUMTURNSPEED);
            }
    }

    // The normalised value runs from 0.0 to 1.0
    float de_normalise_value(float normalisedValue, float minValue, float maxValue)
    {
        float deNormalisedValue;

        // The formula that we want is, 
        //  MINIMUMVALUE + (normalisedValue * (MAXIMUMVALUE - MINIMUMVALUE))
        deNormalisedValue = minValue + (normalisedValue * (maxValue - minValue));

        return deNormalisedValue;
    }


    void spawn_crate() {
        Vector3 randomLocation;

        randomLocation.x = Random.Range(-3500.0f, +3500.0f);
        randomLocation.z = Random.Range(-3500.0f, +3500.0f);
        randomLocation.y = Random.Range(-250.0f, -40.0f);
        GameObject newCrate = get_crate();
        newCrate.transform.position = randomLocation;
        newCrate.transform.rotation = Quaternion.identity;
        newCrate.SetActive(true);
        generate_crate_contents(newCrate);
    }
    public void spawn_Deathcrate(Vector3 deathPos) {
        Vector3 deathLocation = deathPos;
        deathLocation.x += Random.Range(-50.0f, +50.0f);
        deathLocation.z += Random.Range(-50.0f, +50.0f);
        deathLocation.y += Random.Range(-180.0f, -40.0f);
        GameObject newCrate = get_crate();
        newCrate.transform.position = deathLocation;
        newCrate.transform.rotation = Quaternion.identity;
        newCrate.SetActive(true);
        generate_crate_contents(newCrate, true);
    }


    private List<GameObject> availableCrates = new List<GameObject>();

    // Week08 Week 08
    public GameObject get_crate() { 
        if (availableCrates.Count > 0) {
            GameObject newShell = availableCrates[0];
            availableCrates.RemoveAt(0);
            return newShell;
        }

        return null;
    }

    // Week08 Week 08
    public void return_crate(GameObject oldCrate) {
        GameObject crate = availableCrates.Find(x => x == oldCrate);
        if (!crate) {
            oldCrate.transform.position = transform.position;
            oldCrate.GetComponent<Rigidbody>().velocity = Vector3.zero;
            oldCrate.SetActive(false);
            availableCrates.Add(oldCrate);
        }
    }

}



