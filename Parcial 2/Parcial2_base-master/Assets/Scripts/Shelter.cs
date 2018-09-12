using UnityEngine;

public class Shelter : MonoBehaviour, IReduceHealthShelter
{
    [SerializeField]
    private int maxResistance = 5;
    [SerializeField]
    GameObject myDefender;
    bool regenerating = false;

    public int MaxResistance
    {
        get
        {
            return maxResistance;
        }
        protected set
        {
            maxResistance = value;
        }
    }

    private void Update()
    {
        if (maxResistance <= 0)
        {
            Destroy(myDefender);
        }
        if (maxResistance < 5)
        {
            regenerating = true;
        }
        if (maxResistance == 5)
        {
            regenerating = false;
        }
        if (regenerating)
        {
            RegenHealth();
        }
    }

    public void Damage(int damage)
    {
        maxResistance -= damage;
        print(maxResistance);
    }

    private void RegenHealth()
    {
        InvokeRepeating("Regen", 2f, 2f);
    }
    private void Regen()
    {
        maxResistance += 1;
    }
}