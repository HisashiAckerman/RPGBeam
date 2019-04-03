using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodScript : MonoBehaviour
{
    public GameObject bloodVFX;
    public GameObject WorldPos;
    public GameObject sword;
    void Start()
    {
        sword = this.gameObject;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision col)
    {
        //if (col.gameObject.CompareTag("Enemy"))
        {
             GameObject go = Instantiate(bloodVFX, sword.transform.position, Quaternion.identity) as GameObject;
           
            go.transform.position = col.contacts[0].point;
            go.transform.SetParent(WorldPos.transform);
            Destroy(go, 2f);

        }

    }

   
}
