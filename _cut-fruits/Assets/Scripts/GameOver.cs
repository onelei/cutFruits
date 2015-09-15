using UnityEngine;

namespace cutFruits
{
    public class GameOver:MonoBehaviour
    {
        public static GameOver Instance;
        private string mGo_Over_Path = "over";
        GameObject mGo_Over;

        void Awake()
        {
            Instance = this;
            mGo_Over = transform.FindChild(mGo_Over_Path).gameObject;
        }

        void Start()
        {
            gameObject.SetActive(false);
        }

        // 弹出游戏结束;
        public void Over()
        {
            gameObject.SetActive(true);
            TweenScale ts =  mGo_Over.AddComponent<TweenScale>();
            ts.from = Vector3.zero;
            ts.to = Vector3.one;
            ts.duration = 1f;
            ts.SetOnFinished(onFinish);
        }

        void onFinish()
        {
            gameObject.SetActive(false);
            UIMain.Instance.Restart();
        }
    }
}
