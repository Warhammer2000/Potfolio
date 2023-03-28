using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCamera : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    void Start()
    {
        Camera2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Camera1.SetActive(true);

        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Camera2.SetActive(true);
            Camera1.SetActive(false);

        }
    }
}
