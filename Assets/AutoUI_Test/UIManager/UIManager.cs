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
        canvas.renderMode = RenderMode.ScreenSpaceCamera;               //��α׿� �ٸ��� Mode is not RenderMode.ScreenSpaceOverlay
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
        if (string.IsNullOrEmpty(name)) // �̸��� �ȹ޾Ҵٸ� T�� ����
            name = typeof(T).Name;

        //GameObject go = Instantiate<GameObject>($"UI/Popup/{name}");                  //��α� ����
        GameObject go = Resources.Load<GameObject>($"UI/Popup/{name}");
        T popup = Util.GetOrAddComponent<T>(go);
        _popUpStack.Push(popup);

        //go.transform.SetParent(Root.transform);                                       //��α��ε� ��ô��

        return popup;
    }

    public static void ClosePopUpUI(UI_PopUp popUp)
    {
        if (_popUpStack.Count == 0) // ����ִ� �����̶�� ���� �Ұ�
            return;

        if (_popUpStack.Peek() != popUp)
        {
            Debug.Log("Close Popup Failed!"); // ������ ���� �����ִ� Peek() �͸� ������ �� �ձ� ������ popup�� Peek()�� �ƴϸ� ���� ����
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
        _order--; // order ���̱�
    }
}
