using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOnAwake : MonoBehaviour
{
    public GameObject[] Particles;
    public GameObject LastP;
    public GameObject TheWall;
    void Start()
    { 
        Particles = new GameObject[25];
        for(int i = 0; i < Particles.Length; i++)
        {
            Particles[i] = transform.GetChild(i).gameObject;    
            Particles[i].SetActive(false);
        }
        LastP = transform.GetChild(25).gameObject;
        LastP.SetActive(false); 
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if(other.gameObject.tag == "Player")
        {
            TheWall.SetActive(false);
            StartCoroutine(TakeMeToChurch());
        }
        
    }
    
    IEnumerator TakeMeToChurch()
    {
        Particles[0].SetActive(true);
        yield return new WaitForSeconds(2f);
        Particles[1].SetActive(true);
        yield return new WaitForSeconds(2f);
        Particles[2].SetActive(true);
        yield return new WaitForSeconds(2f);
        Particles[3].SetActive(true);
        yield return new WaitForSeconds(2f);
        Particles[4].SetActive(true);
        yield return new WaitForSeconds(2f);
        Particles[5].SetActive(true);
        yield return new WaitForSeconds(2f);
        Particles[6].SetActive(true);
        yield return new WaitForSeconds(2f);
        Particles[7].SetActive(true);
        yield return new WaitForSeconds(2f);
        Particles[8].SetActive(true);
        yield return new WaitForSeconds(4f);
        Particles[9].SetActive(true);
        yield return new WaitForSeconds(4f);
        Particles[10].SetActive(true);
        yield return new WaitForSeconds(4f);
        Particles[11].SetActive(true);
        yield return new WaitForSeconds(4f);
        Particles[12].SetActive(true);
        yield return new WaitForSeconds(4f);
        Particles[13].SetActive(true);
        yield return new WaitForSeconds(4f);
        Particles[14].SetActive(true);
        yield return new WaitForSeconds(4f);
        Particles[15].SetActive(true);
        yield return new WaitForSeconds(4f);
        Particles[16].SetActive(true);
        yield return new WaitForSeconds(4f);
        Particles[17].SetActive(true);
        yield return new WaitForSeconds(4f);
        Particles[18].SetActive(true);
        yield return new WaitForSeconds(4f);
        Particles[19].SetActive(true);
        yield return new WaitForSeconds(4f);
        Particles[20].SetActive(true);
        yield return new WaitForSeconds(4f);
        Particles[21].SetActive(true);
        yield return new WaitForSeconds(4f);
        Particles[22].SetActive(true);
        yield return new WaitForSeconds(4f);
        Particles[23].SetActive(true);
        yield return new WaitForSeconds(4f);
        Particles[24].SetActive(true);
        yield return new WaitForSeconds(4f);
        Particles[24].SetActive(true);
        yield return new WaitForSeconds(4f);
        LastP.SetActive(true);
        yield return new WaitForSeconds(10f);
        for(int i = 0; i < Particles.Length; i++)
        {
            Particles[i].SetActive(false);
        }
        LastP.SetActive(false);
        yield return new WaitForSeconds(50f);
        //To Change Correctly!!!!!!!!!!!!!!!!!!!!!!!!!!
    }
}
