using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Btn : UI_Base
{
    enum Buttons
    {
        PointButton
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
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        /*
        //Test Debug
        for (int i = 0; i < _objects[typeof(Button)].Length; i++)
        {
            Debug.Log(_objects[typeof(Button)][i]);
        }

        for (int i = 0; i < _objects[typeof(Text)].Length; i++)
        {
            Debug.Log(_objects[typeof(Text)][i]);
        }

        for (int i = 0; i < _objects[typeof(GameObject)].Length; i++)
        {
            Debug.Log(_objects[typeof(GameObject)][i]);
        }

        for (int i = 0; i < _objects[typeof(Image)].Length; i++)
        {
            Debug.Log(_objects[typeof(Image)][i]);
        }
        */

        //버튼 클릭 이벤트 바인딩       + 기존 함수(OnButtonClicked)
        GetButton((int)Buttons.PointButton).gameObject.BindEvent(OnButtonClicked);                          //go, action, event 중에 action만 넘김
                                                                                                            // + 확장메서드를 통해 바로 BindEvent함수를 호출

        //이미지 드레그 이벤트 바인딩   + 람다 함수
        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        BindEvent(go, (PointerEventData data) =>
        {
            go.transform.position = data.position;
        }, Define.UIEvent.Drag);

    }

    void OnButtonClicked(PointerEventData data)
    {
        _score++;
        GetText((int)Texts.ScoreText).text = $"점수 : {_score}";
    }
}

