using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Static : UI_PopUp
{
    enum Texts
    {
        ScoreText,
    }
    enum GameObjects
    {
        TestObject,
    }
    enum Images
    {
        ItemIcon,
    }

    private void Start()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));
        

        //버튼 클릭 이벤트 바인딩       + 기존 함수(OnButtonClicked)
        //GetButton((int)Buttons.PointButton).gameObject.BindEvent(OnButtonClicked);                          //go, action, event 중에 action만 넘김
        // + 확장메서드를 통해 바로 BindEvent함수를 호출

    }

}

