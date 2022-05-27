#define DEV

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
#if DEV
        Debug.Log("dev mode");
#endif
    }

    IEnumerator StartCoroutine()
    {
        WaitForSeconds wfs = new WaitForSeconds(0.1f);
        
        while(true)
        {
            Debug.Log("hello");

            yield return wfs;
        }
    }
}
