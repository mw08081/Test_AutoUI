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
        

        //��ư Ŭ�� �̺�Ʈ ���ε�       + ���� �Լ�(OnButtonClicked)
        //GetButton((int)Buttons.PointButton).gameObject.BindEvent(OnButtonClicked);                          //go, action, event �߿� action�� �ѱ�
        // + Ȯ��޼��带 ���� �ٷ� BindEvent�Լ��� ȣ��

    }

}

