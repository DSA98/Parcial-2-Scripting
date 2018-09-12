using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : HazardObjects {

    int randNum;
    
    protected override void Start()
    {
        base.Start();
        randNum = Random.Range(1, 6);
    }

	// Update is called once per frame
	void Update () {
        transform.eulerAngles += (randNum * transform.forward * 1);
	}
}
