using UnityEngine;

public static class SpawnerExtensions
{
    public static Vector3 GetPointInVolume(this Collider2D collider)
    {
        Vector3 result = Vector3.zero;
        result = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x), collider.transform.position.y, 0F);

        return result;
    }
}

[RequireComponent(typeof(Collider2D))]
public class HazardSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject hazardTemplate;
    [SerializeField]
    private GameObject invaderTemplate;
    [SerializeField]
    private GameObject debrisTemplate;


    private Collider2D myCollider;

    [SerializeField]
    private float spawnFrequency = 1F;

    // Use this for initialization
    private void Start()
    {
        myCollider = GetComponent<Collider2D>();

        InvokeRepeating("SpawnEnemy", 0.2F, spawnFrequency);
    }

    private void SpawnEnemy()
    {
        int type = Random.Range(1, 4);
        if (type == 1)
        {
            if (hazardTemplate == null)
            {
                CancelInvoke();
            }
            else
            {
                Instantiate(hazardTemplate, myCollider.GetPointInVolume(), transform.rotation);
            }
        }
        if (type == 2)
        {
            if (invaderTemplate == null)
            {
                CancelInvoke();
            }
            else
            {
                Instantiate(invaderTemplate, myCollider.GetPointInVolume(), transform.rotation);
            }
        }
        if (type == 3)
        {
            if (debrisTemplate == null)
            {
                CancelInvoke();
            }
            else
            {
                Instantiate(debrisTemplate, myCollider.GetPointInVolume(), transform.rotation);
            }
        }
    }
}