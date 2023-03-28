using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVON : MonoBehaviour
{
    public GameObject Tv;
    private void Awake()
    {
        Tv = GameObject.Find("tvSet").gameObject;
        Tv.SetActive(false);    
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Tv.SetActive(true);
        }
    }
}
