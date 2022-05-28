using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PopUp : UI_Base
{
    protected override void Init()
    {
        base.Init();
        UIManager.SetCanvas(gameObject, true);
    }

    public virtual void ClosePopUpUI()
    {
        Debug.Log("close");
        //UIManager.ClosePopUpUI(UIManager.UIType.Page);
        UIManager.ManagePopupUI<UI_PopUp>(UIManager.UIType.Page);
    }
}
