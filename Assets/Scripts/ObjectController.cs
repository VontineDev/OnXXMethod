using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public Action action;
    // Start is called before the first frame update
    void Start()
    {
        action = Rotate;
        action += Move;
        action += EnLarge;
        action += BeBlack;      
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void Rotate()
    {
        this.transform.Rotate(Vector3.up, 30);
    }
    public void Move()
    {
        this.transform.Translate(Vector3.right * 2);

    }
    public void EnLarge()
    {
        this.transform.localScale = Vector3.one * 3;
    }
    public void BeBlack()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.black;
    }


}
