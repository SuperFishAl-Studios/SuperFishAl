﻿using UnityEngine;

public class LockToY : MonoBehaviour
{
    public GameObject target;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);
    }
}
