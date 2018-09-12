using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : HazardObjects
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            if (collision.gameObject.GetComponent<Bullet>() is NormalBullet)
            {
                //TODO: Make this to reduce damage using Bullet.damage attribute
                resistance -= 1;

                if (resistance == 0)
                {
                    OnHazardDestroyed();
                }
            }
            /*if (collision.gameObject.GetComponent<Bullet>() is ApBullet)
            {
                myCollider.isTrigger = true;
            }*/
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            /*if (collision.gameObject.GetComponent<Bullet>() is ApBullet)
            {
                myCollider.isTrigger = false;
            }*/
        }
    }
}
