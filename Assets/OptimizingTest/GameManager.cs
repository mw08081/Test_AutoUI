using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] Camera fullScreenUICam;

    bool isMainCam;

    private void Awake()
    {
        //Application.targetFrameRate = 30;
    }

    void Start()
    {
        isMainCam = true;    
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(isMainCam)
            {
                mainCam.enabled = false;
                fullScreenUICam.enabled = true;

                isMainCam = false;
            }
            else
            {
                mainCam.enabled = true;
                fullScreenUICam.enabled = false;

                isMainCam = true;
            }
        }
    }
}
