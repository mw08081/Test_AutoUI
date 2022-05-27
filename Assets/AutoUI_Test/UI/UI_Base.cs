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
        string[] names = Enum.GetNames(type);                                               //ĵ���� ���� UI ������Ʈ���� Ÿ������ �޾�, �� Ÿ�� ���� enum���� string Value - name���� ����
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];                //ĵ���� ���� UI ������Ʈ Ÿ���� enum ������ŭ ������Ʈ�� �߰��� ���̱⿡ ����Ʈ ����
        _objects.Add(typeof(T), objects);                                                   //UI_Base._objects (Dic)�� UI ������Ʈ�� Ÿ��(ex - Button)�� Ű�� �Ͽ�, �ش� Ÿ���� ���ӿ�����Ʈ ����Ʈ(objects)�� Dic�� ����

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))                                            //���ӿ�����Ʈ�� Ÿ���� UI Ÿ���� �ƴ� GameObject�� ���(ex - Enum:GameObjects)
            {
                objects[i] = Util.FindChild(gameObject, names[i], true);
            }
            else                                                                            //�� �ܿ� UI Ÿ���� ���(ex - Text)
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
        //UnityEngine.Object[] objects = null;                                             //��α� �ڵ��ε� ���� �̷��� �ؼ� GC���� �迭 ���̸� �� ������ ������? 
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
