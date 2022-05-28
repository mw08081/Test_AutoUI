using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.EventSystems;

public static class Extension
{
	public static T GetOrAddComponent<T>(this GameObject go) where T : UnityEngine.Component
	{
		return Util.GetOrAddComponent<T>(go);
	}

	public static void BindEvent(this GameObject go, Action<PointerEventData> action, UI_EventHandler.UIEvent type = UI_EventHandler.UIEvent.Click)
	{
		UI_Base.BindEvent(go, action, type);
	}
}
