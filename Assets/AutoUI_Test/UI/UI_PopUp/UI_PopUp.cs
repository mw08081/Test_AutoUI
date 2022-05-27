using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PopUp : UI_Base
{
    protected override void Init()
    {
        UIManager.SetCanvas(gameObject, true);
    }

    protected virtual void ClosePopUpUI()
    {
        UIManager.ClosePopUpUI(this);                                                //블로그는 ClosePopUpUI()로 정의되어있다
                                                                                //현재 내부는 비어있고 무슨 코드를 써야할지 아직 모른다
    }
}
