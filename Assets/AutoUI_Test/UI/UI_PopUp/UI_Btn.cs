using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Btn : UI_PopUp
{
    enum Buttons
    {
        PointButton,
        CloseButton,
    }
    enum Texts
    {
        PointText,
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

    int _score;

    private void Start()
    {
        _score = 0;
        Init();
    }

    protected override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));


        //��ư Ŭ�� �̺�Ʈ ���ε�       + ���� �Լ�(OnButtonClicked)
        //GetButton((int)Buttons.PointButton).gameObject.BindEvent(OnButtonClicked);                          //go, action, event �߿� action�� �ѱ�
        // + Ȯ��޼��带 ���� �ٷ� BindEvent�Լ��� ȣ��

        //���� ���� �Լ� ���ε�
        GetButton((int)Buttons.CloseButton).gameObject.BindEvent(OnButtonClicked);

        //Close �Լ� ���ε�
        GameObject go2 = GetButton((int)Buttons.PointButton).gameObject;
        BindEvent(go2, (PointerEventData data) =>
        {
            base.ClosePopUpUI();
        });

        //�̹��� �巹�� �̺�Ʈ ���ε�   + ���� �Լ�
        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        BindEvent(go, (PointerEventData data) =>
        {
            go.transform.position = data.position;
        }, UI_EventHandler.UIEvent.Drag);
    }

    void OnButtonClicked(PointerEventData data)
    {
        _score++;
        GetText((int)Texts.ScoreText).text = $"���� : {_score}";
    }

}

