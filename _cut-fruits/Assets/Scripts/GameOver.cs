using UnityEngine;

namespace cutFruits
{
    public class GameOver:MonoBehaviour
    {
        public static GameOver Instance;
        private string mGo_Over_Path = "parent/over";
        private string mGo_Parent_Path = "parent";
        GameObject mGo_Over;
        GameObject mGo_Parent;
        void Awake()
        {
            Instance = this;
            mGo_Over = transform.FindChild(mGo_Over_Path).gameObject;
            mGo_Parent = transform.FindChild(mGo_Parent_Path).gameObject;
        }

        void Start()
        {
            mGo_Parent.SetActive(false);
        }

        // 弹出游戏结束;
        public void Over()
        {
            mGo_Parent.SetActive(true);
            TweenScale ts =  mGo_Over.AddComponent<TweenScale>();
            ts.from = Vector3.zero;
            ts.to = Vector3.one;
            ts.duration = 1f;
            ts.SetOnFinished(onFinish);
        }

        void onFinish()
        {
            Framework.Resume();
            mGo_Parent.SetActive(false);
            UIMain.Instance.Restart();
        }
    }
}
