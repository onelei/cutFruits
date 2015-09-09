/*
 * 游戏主界面;
 * 
 */

using UnityEngine;
using System.Collections;

namespace cutFruits
{
    public class UIMain:MonoBehaviour
    {
        private readonly string mGo_DC_Path = "BLAnchor/parent/dojo";
        private readonly string mGo_Game_Path = "BAnchor/parent";
        private readonly string mGo_Quit_Path = "BRAnchor/parent";
        private readonly string mGo_Head_Path = "TLAnchor/parent";

        // 道场;
        private GameObject mGO_DC;
        // 新游戏;
        private GameObject mGo_Game;
        // 退出;
        private GameObject mGo_Quit;
        // 头部背景;
        private GameObject mGo_Head;
        private GameObject mGo_Head_Word2;
        private GameObject mGo_Head_Word3;

        private float _mTime = 0f;
        private float mTime = 1f;
        private bool _Start = false;
        void Awake()
        {
            mGO_DC = gameObject.transform.FindChild(mGo_DC_Path).gameObject;
            mGo_Game = gameObject.transform.FindChild(mGo_Game_Path).gameObject;
            mGo_Quit = gameObject.transform.FindChild(mGo_Quit_Path).gameObject;
            mGo_Head = gameObject.transform.FindChild(mGo_Head_Path).gameObject;

        }

        void Start()
        {
            setDC();
            setNewGame();
            setQuit();
            setHead();
        }

        void setDC()
        {
            // 道场的外环旋转(顺时针,right);
            GameObject go = mGO_DC.transform.FindChild("ring").gameObject;
            Framework.SetRotate(go, 10f, false);
            Framework.SetScale(go);           

            // 道场的水果旋转(顺时针,right);
            go = mGO_DC.transform.FindChild("fruit").gameObject;
            Framework.SetRotate(go, 5f, false);
            Framework.SetScale(go);
   
        }

        void setNewGame()
        {
            // 游戏的外环顺时针旋转;
            GameObject go = mGo_Game.transform.FindChild("ring").gameObject;
            Framework.SetRotate(go,10f,false);
            Framework.SetScale(go);

            // 游戏的水果逆时针旋转;
            go = mGo_Game.transform.FindChild("fruit").gameObject;
            Framework.SetRotate(go, 5f, true);
            Framework.SetScale(go);

        }

        void setQuit()
        {
            // 游戏的外环顺时针旋转;
            GameObject go = mGo_Quit.transform.FindChild("ring").gameObject;
            Framework.SetRotate(go, 10f, true);
            Framework.SetScale(go);

            // 游戏的水果逆时针旋转;
            go = mGo_Game.transform.FindChild("fruit").gameObject;
         

        }

        void setHead()
        {
            // 设置背景;
            GameObject go = mGo_Head.transform.FindChild("bg").gameObject;
            Framework.SetUpDown(go,200f,false);
            // 设置弹跳的动画;
            _Start = true;
            mGo_Head_Word2 = mGo_Head.transform.FindChild("word2").gameObject;
            StartCoroutine(setHeadWord2());
            mGo_Head_Word3 = mGo_Head.transform.FindChild("word3").gameObject;
            Framework.SetLeftRight(mGo_Head_Word3, 800f, 2.5f, true);
        }

        IEnumerator setHeadWord2()
        {
            mGo_Head_Word2.SetActive(false);
            yield return new WaitForSeconds(1f);
            mGo_Head_Word2.SetActive(true);
        }
     
    }
}
