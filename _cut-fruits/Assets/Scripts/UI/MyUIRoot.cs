using UnityEngine;

namespace cutFruits
{
    public class MyUIRoot : MonoBehaviour
    { 
        // 滚动的道场;
        GameObject mGo_UIMain;
        GameObject mGo_Parent;
        // 游戏结束界面;
        GameObject mGo_Over;
        void Awake()
        {
            mGo_Parent = GameObject.Find("UI Root").gameObject;
            //mGo_UIMain = gameObject.transform.Find("UIMain").gameObject;
            //mGo_Over = gameObject.transform.Find("UIOver").gameObject;
        }

        void Start()
        {
            // 加载主界面;
            mGo_UIMain = Instantiate(Resources.Load("UI/UIMain")) as GameObject;
            mGo_UIMain.transform.parent = gameObject.transform;
            mGo_UIMain.transform.localScale = Vector3.one;
            mGo_UIMain.AddComponent<UIMain>();

            // 设置GameOver界面;
            mGo_Over = Instantiate(Resources.Load("UI/UIOver")) as GameObject;
            mGo_Over.transform.parent = gameObject.transform;
            mGo_Over.transform.localScale = Vector3.one;
            mGo_Over.AddComponent<GameOver>();
        }

      
    }
}
