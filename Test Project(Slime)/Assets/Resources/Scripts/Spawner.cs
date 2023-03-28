using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject SpawngameObject;
    public static Spawner instance;
    private void Start()
    {
        instance = this;
        SpawngameObject = Resources.Load<GameObject>("Prefabs/Enemy");
    }
    public void Spawn()
    {
        Instantiate(SpawngameObject, transform.position, Quaternion.identity);  
    }
}
