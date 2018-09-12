using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApBullet : Bullet {

    RaycastHit hit;

    private void Update()
    {
        if(Physics.SphereCast(transform.position, 2, transform.forward,out hit))
        {
            if(hit.transform.gameObject.CompareTag("Hazard"))
            {
                myCollider.enabled = false;
                Invoke("Reactivate", 1f);
            }
        }
    }

    public void Reactivate()
    {
        myCollider.enabled = true;
    }
}
