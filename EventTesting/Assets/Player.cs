using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if ( Physics.Raycast(transform.position, Vector3.forward, out hit) )
        {
            Debug.Log ( hit.collider.transform.parent.name + "_Drain" );
            Action Eve = EventManager.Instance.Get_Event( hit.collider.transform.parent.name + "_Drain");
            Eve ();
        }
    }


}
