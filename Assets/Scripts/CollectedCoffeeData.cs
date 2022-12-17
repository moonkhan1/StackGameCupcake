using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedCoffeeData : MonoBehaviour
{
    public static CollectedCoffeeData Instance;
    public List<Transform> CoffeeList;
    public List<GameObject> finalCountList;
    public List<Renderer> Meshes;
    private GameObject _coffees;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {

        CloseAllMeshes();

    }

    public void CloseAllMeshes()
    {
        //  _coffees = GameObject.FindGameObjectWithTag("Collactable");
        // Meshes.Add(_coffees.GetComponentInChildren<Renderer>());
        foreach (var item in Meshes)
        {
            for (int i = 1; i < item.GetComponentsInChildren<Renderer>().Length; i++)
            {
                item.GetComponentsInChildren<Renderer>()[i].enabled = false;
            }

        }
    }

    public void OpenMeshes(int ind)
    {
        foreach (var item in Meshes)
        {
            item.GetComponentsInChildren<Renderer>()[ind].enabled = true;

        }



    }
}
