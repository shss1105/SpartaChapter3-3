using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
//{
//    private static T _instance;

//    public static T Instance
//    {
//        get
//        {
//            if (_instance == null)
//            {
//                _instance = FindObjectOfType<T>();
//                if (_instance == null)
//                {
//                    GameObject obj = new GameObject();
//                    _instance = obj.AddComponent<T>();
//                }
//            }
//            return _instance;
//        }
//    }
//}

public class UIManager : Singleton<UIManager>
{

    public Canvas mainCanvas;

    public List<UIBase> UIList = new List<UIBase>();

    [HideInInspector]
    public List<UIBase> UIObjList = new List<UIBase>();

    public void Show(string uiName)
    {
        UIBase ui = UIList.Find(obj => obj.name == uiName);

        if (ui == null)
            return;

        ui.Show();
    }

    public void Hide(string uiName)
    {
        var ui = UIObjList.Find(obj => obj.name == uiName);

        if (ui == null) return;

        ui.Hide();
    }
}
