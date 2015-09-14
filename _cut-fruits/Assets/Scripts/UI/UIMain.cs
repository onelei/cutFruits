/*
 * 游戏主界面;
 * 
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace cutFruits
{
    public class UIMain:MonoBehaviour
    {
        private readonly string mGo_DC_Path = "BLAnchor/parent/dojo";
        private readonly string mGo_Game_Path = "BAnchor/parent";
        private readonly string mGo_Quit_Path = "BRAnchor/parent";
        private readonly string mGo_Head_Path = "TLAnchor/parent";
        private readonly string mGo_Head3_Path = "TLAnchor/parent3";

        // 道场;
        private GameObject mGO_DC_parent;
        private GameObject mGO_DC;
        // 新游戏;
        private GameObject mGo_Game_parent;
        private GameObject mGo_Game;
        // 退出;
        private GameObject mGo_Quit_parent;
        private GameObject mGo_Quit;

        // 头部背景;
        private GameObject mGo_Head;
        private GameObject mGo_Head_Word2;
        private GameObject mGo_Head3;

        private float _mTime = 0f;
        private float mTime = 1f;
        private bool _Start = false;

        private List<GameObject> mGo_Rings;
        public UIMain()
        {
            mGo_Rings = new List<GameObject>();
        }

        void Awake()
        {
            mGO_DC_parent = gameObject.transform.FindChild(mGo_DC_Path).gameObject;
            mGo_Game_parent = gameObject.transform.FindChild(mGo_Game_Path).gameObject;
            mGo_Quit_parent = gameObject.transform.FindChild(mGo_Quit_Path).gameObject;
            mGo_Head = gameObject.transform.FindChild(mGo_Head_Path).gameObject;
            mGo_Head3 = gameObject.transform.FindChild(mGo_Head3_Path).gameObject;
        }

        void Start()
        {
            // 添加一个手滑事件;
            EasyTouch.On_Swipe += EasyTouch_On_Swipe;
            onEnterUI();
          
        }

        // 进入游戏UI界面;
        void onEnterUI()
        {
            setDC();
            setNewGame();
            setQuit();
            setHead();
        }

        // 进入游戏场景;
        void onEnterScence()
        {
            setLeaveUIMove();

            enterGame();
        }

        void enterGame()
        {
            StartCoroutine(startGame());
        }

        IEnumerator startGame()
        {
            yield return new WaitForSeconds(2f);
            // 设置水果从下面弹上来;
            addJumpFruits(2);
            // 如果水果跌落,则重新上来两个水果;

        }

        // 添加水果到场景中;
        void addJumpFruits(int number)
        {          
            for (int i = 0; i < number;++i )
            {
                // 设置水果从下面弹上来;
                int rand = Random.Range((int)fruitType.apple, (int)fruitType.sandia);
                fruitType type = Framework.getTypeByID(rand);
                OneFruit fruit = Framework.loadFruit(gameObject, type, new Vector3(0f, -400f));//-400
                MainModel.Instance.AddFruits(fruit);
                Rigidbody body = Framework.AddOneComponent<Rigidbody>(fruit.gameObject);
                body.useGravity = true;
                int randForceX = Random.Range(5,15);
                int randForceY = Random.Range(250,350);
                body.AddForce(new Vector3(randForceX, randForceY, 0f));//300
                fruit.StartCheck(true);
            }      
        }

        void setUp(OneFruit fruit)
        {
            fruit.transform.localPosition = new Vector3(0f,-400f);
            Rigidbody body = fruit.gameObject.GetComponent<Rigidbody>();
            int randForceX = Random.Range(-5, 5); 
            int randForceY = Random.Range(300, 350);
            body.AddForce(new Vector3(randForceX, randForceY, 0f));//300
            int rand = Random.Range((int)fruitType.apple, (int)fruitType.sandia);
            fruitType type = Framework.getTypeByID(rand);
            fruit.init(type);
        }

        void setDC()
        {
            // 道场的外环旋转(顺时针,right);
            GameObject mGo_DC_ring = mGO_DC_parent.transform.FindChild("ring").gameObject;
            Framework.SetRotate(mGo_DC_ring, 10f, false);
            Framework.SetScale(mGo_DC_ring);
            mGo_Rings.Add(mGo_DC_ring);

            // 道场的水果旋转(顺时针,right);
            Vector3 vec = mGO_DC_parent.transform.FindChild("fruitparent").localPosition;
            mGO_DC = Framework.CreateFruit(mGO_DC_parent, fruitType.peach, vec);
            OneFruit fuit = mGO_DC.GetComponentInParent<OneFruit>();
            Framework.AddOnClick(mGO_DC, "", OnDC);
            Framework.SetRotate(mGO_DC.transform.parent.gameObject, 5f, false);
            Framework.SetScale(mGO_DC.transform.parent.gameObject);          
        }

        // 离开UI界面的移动,也就是进入游戏界面的移动;
        void setLeaveUIMove()
        {
            // 隐藏外环;
            for (int i = 0; i < mGo_Rings.Count;++i )
            {
                mGo_Rings[i].SetActive(false);
            }
            // 设置道场向下移动;
            Framework.SetUpDown2(mGO_DC_parent,800f,false);
            // 设置标题向上移动;
            Framework.SetUpDown2(mGo_Head,800f,true);
            // 设置标题3向左边移动;
            Framework.SetLeftRight2(mGo_Head3,400f,true);
            // 设置退出向下移动;
            Framework.SetUpDown2(mGo_Quit_parent,800f,false);
        }

        void setNewGame()
        {
            // 游戏的外环顺时针旋转;
            GameObject mGo_Game_ring = mGo_Game_parent.transform.FindChild("ring").gameObject;
            Framework.SetRotate(mGo_Game_ring, 10f, false);
            Framework.SetScale(mGo_Game_ring);
            mGo_Rings.Add(mGo_Game_ring);
            // 游戏的水果逆时针旋转;
            Vector3 vec = mGo_Game_parent.transform.FindChild("fruitparent").localPosition;
            mGo_Game = Framework.CreateFruit(mGo_Game_parent, fruitType.sandia, vec);
            OneFruit fuit = mGo_Game.GetComponentInParent<OneFruit>();
            Framework.AddOnClick(mGo_Game, "", OnGame);
            Framework.SetRotate(mGo_Game.transform.parent.gameObject, 5f, true);
            Framework.SetScale(mGo_Game.transform.parent.gameObject);
        }

        void setQuit()
        {
            // 游戏的外环顺时针旋转;
            GameObject go = mGo_Quit_parent.transform.FindChild("fruitparent/ring").gameObject;
            Framework.SetRotate(go, 10f, true);
            Framework.SetScale(go);
            mGo_Rings.Add(go);
            // 游戏的水果逆时针旋转;
            Vector3 vec = mGo_Quit_parent.transform.FindChild("fruitparent").localPosition;
            mGo_Quit = Framework.CreateFruit(mGo_Quit_parent, fruitType.boom, vec);
            OneFruit fuit = mGo_Quit.GetComponentInParent<OneFruit>();
            Framework.AddOnClick(mGo_Quit, "", OnQuit);

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
            Framework.SetLeftRight(mGo_Head3, 800f, 2.5f, true);
        }

        IEnumerator setHeadWord2()
        {
            mGo_Head_Word2.SetActive(false);
            yield return new WaitForSeconds(1f);
            mGo_Head_Word2.SetActive(true);
        }
     
        void OnDC(object obj)
        {
            // 点击道场的回调;
            
        }

        void OnGame(object obj)
        {
            // 点击game的回调;
            onEnterScence();
            OneFruit fruit = mGo_Game.GetComponentInParent<OneFruit>();
            fruit.StartCheck(false);
        }

        void OnQuit(object obj)
        {
            // 点击quit的回调;

        }

        void OnDestroy()
        {
            // 释放一个手滑事件;
            EasyTouch.On_Swipe -= EasyTouch_On_Swipe;
        }

        // 手指滑动;
        void EasyTouch_On_Swipe(Gesture gesture)
        {
            List<OneFruit> mFruitsList = MainModel.Instance.mFruitsList;
            for (int i = 0; i < mFruitsList.Count;++i )
            {
                if (gesture.IsInRect(NGUIObjectToRect(mFruitsList[i].gameObject)))
                {
                    mFruitsList[i].onClick(null);               
                }
            }

            // 检测道场;
            if (gesture.IsInRect(NGUIObjectToRect(mGO_DC)))
            {
                OneFruit fuit = mGO_DC.GetComponentInParent<OneFruit>();
                fuit.onClick(null);
                OnDC(null);
            }

            // 检测游戏;
            if (gesture.IsInRect(NGUIObjectToRect(mGo_Game)))
            {
                OneFruit fuit = mGo_Game.GetComponentInParent<OneFruit>();
                fuit.onClick(null);
                OnGame(null);
            }

            // 检测退出;
            if (gesture.IsInRect(NGUIObjectToRect(mGo_Quit)))
            {
                OneFruit fuit = mGo_Quit.GetComponentInParent<OneFruit>();
                fuit.onClick(null);
                OnQuit(null);
            }
        }

        //计算出NGUI某个UISprite或者UITexture或者 UILabel 在屏幕中占的矩形位置;
        private Rect NGUIObjectToRect(GameObject go)
        {
            Camera camera = NGUITools.FindCameraForLayer(go.layer);
            Bounds bounds = NGUIMath.CalculateAbsoluteWidgetBounds(go.transform);
            Vector3 min = camera.WorldToScreenPoint(bounds.min);
            Vector3 max = camera.WorldToScreenPoint(bounds.max);
            return new Rect(min.x, min.y, max.x - min.x, max.y - min.y);
        }
 
        void Update()
        {
            List<OneFruit> mFruitsList = MainModel.Instance.mFruitsList;
            for (int i = 0; i < mFruitsList.Count;++i)
            {
                if (mFruitsList[i].transform.localPosition.y<-400)
                {
                    setUp(mFruitsList[i]);
                }
            }
        }
    }
}
