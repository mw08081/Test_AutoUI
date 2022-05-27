using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static Stack<UI_PopUp> _popUpStack = new Stack<UI_PopUp>();
    static int _order = 0;

    public static void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceCamera;               //블로그와 다르게 Mode is not RenderMode.ScreenSpaceOverlay
        canvas.overrideSorting = true;

        if(sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }

    public static T ShowPopupUI<T>(string name = null) where T : UI_PopUp
    {
        if (string.IsNullOrEmpty(name)) // 이름을 안받았다면 T로 ㄱㄱ
            name = typeof(T).Name;

        //GameObject go = Instantiate<GameObject>($"UI/Popup/{name}");                  //블로그 버전
        GameObject go = Resources.Load<GameObject>($"UI/Popup/{name}");
        T popup = Util.GetOrAddComponent<T>(go);
        _popUpStack.Push(popup);

        //go.transform.SetParent(Root.transform);                                       //블로그인데 잠시대기

        return popup;
    }

    public static void ClosePopUpUI(UI_PopUp popUp)
    {
        if (_popUpStack.Count == 0) // 비어있는 스택이라면 삭제 불가
            return;

        if (_popUpStack.Peek() != popUp)
        {
            Debug.Log("Close Popup Failed!"); // 스택의 가장 위에있는 Peek() 것만 삭제할 수 잇기 때문에 popup이 Peek()가 아니면 삭제 못함
            return;
        }

        ClosePopUpUI();
    }

    static void ClosePopUpUI()
    {
        if (_popUpStack.Count == 0)
            return;

        UI_PopUp popup = _popUpStack.Pop();
        Destroy(popup.gameObject);
        popup = null;
        _order--; // order 줄이기
    }
}
