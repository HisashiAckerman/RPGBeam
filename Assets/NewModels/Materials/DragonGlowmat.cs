using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonGlowmat : MonoBehaviour
{
    public Material[] material;
    

    Renderer rend;
    void Start()
         
    {
        
        rend = GetComponent<Renderer>();
        rend.sharedMaterial = material[0];
        
    }

    // Update is called once per frame
    void Update()
    {

        if (DragonAttack.isGlowing)
            rend.sharedMaterial = material[1];
        else rend.sharedMaterial = material[0];
    }
}
