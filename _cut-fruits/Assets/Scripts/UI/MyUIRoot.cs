using UnityEngine;

namespace cutFruits
{
    public class MyUIRoot : MonoBehaviour
    { // 滚动的道场;
        GameObject mGo_UIMain;
        GameObject mGo_Parent;
        void Awake()
        {
            mGo_Parent = GameObject.Find("UI Root").gameObject;
            mGo_UIMain = gameObject.transform.Find("UIMain").gameObject;
        }

        void Start()
        {
            mGo_UIMain.AddComponent<UIMain>();
        }
    }
}
