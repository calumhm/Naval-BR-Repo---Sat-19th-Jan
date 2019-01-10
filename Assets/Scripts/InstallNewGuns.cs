using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallNewGuns : MonoBehaviour {
	public GameObject frontTurretPrefab;
    public GameObject sideTurretPrefab;

	private GameObject frontGunMount;
    private GameObject sideGunMount00;
    private GameObject sideGunMount01;
    private GameObject sideGunMount02;
    private GameObject sideGunMount03;
    private GameObject sideGunMount04;
    private GameObject sideGunMount05;

	// Use this for initialization
	void Start () {
		frontGunMount = transform.Find("FrontGuns/FrontGunMount00").gameObject;
        sideGunMount00 = transform.Find("SideGuns/SideGunMount00").gameObject;
        sideGunMount01 = transform.Find("SideGuns/SideGunMount01").gameObject;
        sideGunMount02 = transform.Find("SideGuns/SideGunMount02").gameObject;
        sideGunMount03 = transform.Find("SideGuns/SideGunMount03").gameObject;
        sideGunMount04 = transform.Find("SideGuns/SideGunMount04").gameObject;
        sideGunMount05 = transform.Find("SideGuns/SideGunMount05").gameObject;
        install_guns();
    }

  
    void install_guns() {

        float playerBonus = 0.0f;
        if(this.gameObject.tag == "ship")
        {
            playerBonus = 500.0f;
        }
    
        GameObject newFrontTurret = Instantiate(frontTurretPrefab, frontGunMount.transform.position, frontGunMount.transform.rotation);
        newFrontTurret.transform.parent = frontGunMount.transform;
        newFrontTurret.GetComponent<TurretScript>().damage = Constants.MINIMUMDAMAGE + playerBonus ;
        GameObject newSideTurret00 = Instantiate(sideTurretPrefab, sideGunMount00.transform.position, sideGunMount00.transform.rotation);
        newSideTurret00.transform.parent = sideGunMount00.transform;
        newSideTurret00.GetComponent<TurretScript>().damage = Constants.MINIMUMDAMAGE + playerBonus;
        GameObject newSideTurret01 = Instantiate(sideTurretPrefab, sideGunMount01.transform.position, sideGunMount01.transform.rotation);
        newSideTurret01.transform.parent = sideGunMount01.transform;
        newSideTurret01.GetComponent<TurretScript>().damage = Constants.MINIMUMDAMAGE + playerBonus;
        GameObject newSideTurret02 = Instantiate(sideTurretPrefab, sideGunMount02.transform.position, sideGunMount02.transform.rotation);
        newSideTurret02.transform.parent = sideGunMount02.transform;
        newSideTurret02.GetComponent<TurretScript>().damage = Constants.MINIMUMDAMAGE + playerBonus;
        GameObject newSideTurret03 = Instantiate(sideTurretPrefab, sideGunMount03.transform.position, sideGunMount03.transform.rotation);
        newSideTurret03.transform.parent = sideGunMount03.transform;
        newSideTurret03.GetComponent<TurretScript>().damage = Constants.MINIMUMDAMAGE + playerBonus;
        GameObject newSideTurret04 = Instantiate(sideTurretPrefab, sideGunMount04.transform.position, sideGunMount04.transform.rotation);
        newSideTurret04.transform.parent = sideGunMount04.transform;
        newSideTurret04.GetComponent<TurretScript>().damage = Constants.MINIMUMDAMAGE + playerBonus;
        GameObject newSideTurret05 = Instantiate(sideTurretPrefab, sideGunMount05.transform.position, sideGunMount05.transform.rotation);
        newSideTurret05.transform.parent = sideGunMount05.transform;
        newSideTurret05.GetComponent<TurretScript>().damage = Constants.MINIMUMDAMAGE + playerBonus;
    }
}


