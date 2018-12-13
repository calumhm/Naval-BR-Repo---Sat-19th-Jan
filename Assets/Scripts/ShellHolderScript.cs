using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellHolderScript : MonoBehaviour
{

    public GameObject shell;

    private List<GameObject> availableShells = new List<GameObject>();

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
}

