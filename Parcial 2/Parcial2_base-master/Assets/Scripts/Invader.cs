using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : HazardObjects
{
    int sense;

	// Use this for initialization
	protected override void Start () {
        ChangingSense();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += (transform.right * 3f * sense)*Time.deltaTime;
    }

    private void ChangingSense()
    {
        InvokeRepeating("ChangeSense", 0.5f, 0.5f);
    }

    private void ChangeSense()
    {
        sense = Random.Range(0, 2);
        if (sense == 0)
        {
            sense = -1;
        }
    }
}
