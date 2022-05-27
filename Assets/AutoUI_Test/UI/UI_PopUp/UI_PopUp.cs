using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PopUp : UI_Base
{
    protected override void Init()
    {
        UIManager.SetCanvas(gameObject, true);
    }

    protected virtual void ClosePopUpUI()
    {
        UIManager.ClosePopUpUI(this);                                                //��α״� ClosePopUpUI()�� ���ǵǾ��ִ�
                                                                                //���� ���δ� ����ְ� ���� �ڵ带 ������� ���� �𸥴�
    }
}
