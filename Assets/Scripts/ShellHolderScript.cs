using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellHolderScript : MonoBehaviour
{

    public GameObject shell;
    public GameObject exp;

    private List<GameObject> availableShells = new List<GameObject>();
    private List<GameObject> availableExplosions = new List<GameObject>();


    // Week08 Week 08
    void Start()
    {
        GameObject newShell;
        for (int c = 0; c < 1000; c++)
        {
            newShell = Instantiate(shell, transform.position, Quaternion.identity);
            newShell.SetActive(false);
            newShell.transform.parent = transform;
            availableShells.Add(newShell);
        }

        GameObject newExp;
        for (int c = 0; c < 10000; c++)
        {
            newExp = Instantiate(exp, transform.position, Quaternion.identity);
            newExp.SetActive(false);
            newExp.transform.parent = transform;
            availableExplosions.Add(newExp);
           // ParticleSystem[] pfx = new ParticleSystem[]{availableExplosions.gameObject.transform.Find()}
        }
    }

    // Week08 Week 08
    public GameObject get_shell()
    {
        if (availableShells.Count > 0) {
            GameObject newShell = availableShells[0];
            availableShells.RemoveAt(0);
            return newShell;
        }

        return null;
    }

    // Week08 Week 08
    public void return_shell(GameObject oldShell)
    {
        GameObject shell = availableShells.Find(x => x == oldShell);
        if( !shell ) {
            oldShell.transform.position = transform.position;
            oldShell.GetComponent<Rigidbody>().velocity = Vector3.zero;
            oldShell.SetActive(false);
            availableShells.Add(oldShell);
        }
    }
public GameObject get_Exp()
    {
        if (availableExplosions.Count > 0) {
            GameObject newExp = availableExplosions[0];
            availableExplosions.RemoveAt(0);
            newExp.SetActive(true);
            Debug.Log("successful get_exp");
            return newExp;
        }
        Debug.Log("availableExplosions.Count = 0");
        GameObject shinyExp = Instantiate(exp, transform.position, Quaternion.identity);
        shinyExp.SetActive(true);
        return shinyExp;
    }

    // Week08 Week 08
    public void invoke_return_Exp(GameObject oldExp)
    {
        StartCoroutine(return_Exp(oldExp, 1f));
        
    }
    public IEnumerator return_Exp(GameObject oldExp, float delay)
    {
       GameObject Exp = availableExplosions.Find(x => x == oldExp);
        if( !Exp ) {
            yield return new WaitForSeconds(delay);
            oldExp.transform.position = transform.position;
            oldExp.SetActive(false);
            availableExplosions.Add(oldExp);
        }
    }
}
