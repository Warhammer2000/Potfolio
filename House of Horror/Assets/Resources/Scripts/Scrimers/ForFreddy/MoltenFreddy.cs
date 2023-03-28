using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoltenFreddy : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();    
    }

    public void LetsAnim()
    {
        anim.SetBool("inAction", true);
    }
    public void DontAnim()
    {
        anim.SetBool("inAction", false);
    }
}
