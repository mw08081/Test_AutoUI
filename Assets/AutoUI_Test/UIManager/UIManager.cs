using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public enum UIType
    {
        Static,
        Page,
        Option,
    }

    private static Dictionary<UIType, GameObject> UiList = new Dictionary<UIType, GameObject>();
    //public static Stack<UI_PopUp> _popUpStack = new Stack<UI_PopUp>();
    static int _order = 0;

    public static void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceCamera;               //블로그와 다르게 Mode is not RenderMode.ScreenSpaceOverlay
        //canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.worldCamera = Camera.main;
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

    public static void ManagePopupUI<T>(UIType uIType, string name = null) where T : UI_PopUp
    {

        //T popup = Util.GetOrAddComponent<T>(go);
        //_popUpStack.Push(popup);

        UIType uiTypeTmp = UIType.Page;
        switch (uIType)
        {
            case UIType.Static:
                uiTypeTmp = UIType.Static;
                break;
            case UIType.Page:
                uiTypeTmp = UIType.Page;
                break;
            case UIType.Option:
                uiTypeTmp = UIType.Option;
                break;
            default:
                break;
        }

        if(UiList.ContainsKey(uiTypeTmp))
        {
            if(UiList[uiTypeTmp].gameObject.activeSelf)
            {
                UiList[uiTypeTmp].gameObject.SetActive(false);
            }
            else
            {
                UiList[uiTypeTmp].gameObject.SetActive(true);
            }
            
        }
        else
        {
            GameObject go = Resources.Load<GameObject>($"UI/PopUp/{name}");
            GameObject realGo = Instantiate(go);
            UiList.Add(uiTypeTmp, realGo);
        }

        //go.transform.SetParent(Root.transform);                                       //블로그인데 잠시대기

        //return popup;
    }
}
