#define DEV
#define TEST

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Base : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    protected virtual void Init() { }

    #region Bind GameObject

    protected void Bind<T>(Type type) where T : UnityEngine.Object
	{
        string[] names = Enum.GetNames(type);                                               //캔버스 내의 UI 오브젝트들을 타입으로 받아, 그 타입 내의 enum값을 string Value - name으로 저장
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];                //캔버스 내의 UI 오브젝트 타입의 enum 개수만큼 오브젝트를 추가할 것이기에 리스트 생성
        _objects.Add(typeof(T), objects);                                                   //UI_Base._objects (Dic)에 UI 오브젝트의 타입(ex - Button)을 키로 하여, 해당 타입의 게임오브젝트 리스트(objects)를 Dic에 저장

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))                                            //게임오브젝트의 타입이 UI 타입이 아닌 GameObject일 경우(ex - Enum:GameObjects)
            {
                objects[i] = Util.FindChild(gameObject, names[i], true);
            }
            else                                                                            //그 외에 UI 타입일 경우(ex - Text)
            {
                objects[i] = Util.FindChild<T>(gameObject, names[i], true);
            }

            if (objects[i] == null)
            {
                Debug.Log($"Failed to bind({names[i]})");
            }
        }
    }

    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        //UnityEngine.Object[] objects = null;                                             //블로그 코드인데 굳이 이렇게 해서 GC에게 배열 먹이를 줄 이유가 있을까? 
        //if(!_objects.TryGetValue(typeof(T), out objects)) { return null; }

        if (_objects.ContainsKey(typeof(T)))
        {
            return _objects[typeof(T)][idx] as T;
        }
        else
        {
            Debug.LogWarning("No Exsit Type");

            return null;
        }
    }

    protected Button GetButton(int idx)
    {
        return Get<Button>(idx);
    }
    protected Text GetText(int idx)
    {
        return Get<Text>(idx);
    }
    protected GameObject GetGameObject(int idx)
    {
        return Get<GameObject>(idx);
    }
    protected Image GetImage(int idx)
    {
        return Get<Image>(idx);
    }

    #endregion

    #region Bind EventFunction

    public static void BindEvent(GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_EventHandler evt = Util.GetOrAddComponent<UI_EventHandler>(go);

        switch (type)
        {
            case Define.UIEvent.Click:
                evt.OnClickHandler -= action;
                evt.OnClickHandler += action;
                break;
            case Define.UIEvent.Drag:
                evt.OnDragHandler -= action;
                evt.OnDragHandler += action;
                break;
            default:
                break;
        }
    }

    #endregion
}
