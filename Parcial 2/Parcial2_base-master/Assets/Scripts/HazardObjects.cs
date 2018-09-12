using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class HazardObjects : MonoBehaviour
{
    protected Collider2D myCollider;
    protected object myRigidbody;

    [SerializeField]
    protected float resistance = 1F;
    protected int damageShelterMag = 1;

    protected float spinTime = 1F;

    // Use this for initialization
    protected virtual void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            //TODO: Make this to reduce damage using Bullet.damage attribute
            resistance -= 1;

            if (resistance == 0)
            {
                OnHazardDestroyed();
            }
        }
        if (collision.gameObject.GetComponent<IReduceHealthShelter>() != null)
        {
            collision.gameObject.GetComponent<IReduceHealthShelter>().Damage(damageShelterMag);
            Destroy(gameObject);
        }
    }

    protected void OnHazardDestroyed()
    {
        //TODO: GameObject should spin for 'spinTime' secs. then disappear
        Destroy(gameObject);
    }
}