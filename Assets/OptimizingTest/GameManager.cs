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

        UIManager.ManagePopupUI<UI_PopUp>(UIManager.UIType.Static, "UI_Static");
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

        if(Input.GetKeyDown(KeyCode.A))
        {
            UIManager.ManagePopupUI<UI_PopUp>(UIManager.UIType.Page, "UI_Button");
        }
    }
}
