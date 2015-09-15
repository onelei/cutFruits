using UnityEngine;

namespace cutFruits
{
    public class Framework :MonoBehaviour
    {
        public static T AddOneComponent<T>(GameObject obj) where T : Component
        {
            T tempObject = obj.GetComponent<T>();
            if (tempObject == null)
            {
                tempObject = obj.AddComponent<T>();
            }
            return tempObject;
        }

        // 按钮的OnClick事件;
        public static GameObject AddOnClick(GameObject parent, string path, UIEventListener.VoidDelegate OnCallBack)
        {
            GameObject btnObj = null;
            if (path == "")
            {
                btnObj = parent;
            }
            else
            {
                btnObj = parent.transform.FindChild(path).gameObject;
            }
            if (btnObj != null)
            {
                // 添加回调;
                UIEventListener.Get(btnObj).onClick += OnCallBack;
                // 设置碰撞;
                UISprite sp = btnObj.GetComponent<UISprite>();
                BoxCollider bc = AddOneComponent<BoxCollider>(btnObj);
                bc.size = new Vector3(sp.localSize.x, sp.localSize.y, 0f);
                bc.center = new Vector3(sp.localSize.x * (0.5f - sp.pivotOffset.x), sp.localSize.y * (0.5f - sp.pivotOffset.y), 0f);
            }
            else
            {
                Debug.LogError("the GameObject in " + path + " is not fond!");
            }
            return btnObj;
        }

        public static void SetRotate(GameObject go,float time,bool isLeftRotate)
        {
            TweenRotation tr = AddOneComponent<TweenRotation>(go);
            tr.from = Vector3.zero;
            if (isLeftRotate)
            {
                tr.to = new Vector3(0, 0, 360f);
            }
            else
            {
                tr.to = new Vector3(0, 0, -360f);
            }
            tr.style = UITweener.Style.Loop;
            tr.duration = time;
        }

        public static void SetScale(GameObject go)
        {
            TweenScale ts = AddOneComponent<TweenScale>(go);
            ts.from = Vector3.zero;
            ts.to = Vector3.one;
            ts.style = UITweener.Style.Once;
            ts.duration = 1f;
        }

        public static void SetUpDown(GameObject go,float dis,bool isUp)
        {
            TweenPosition tp = go.AddComponent<TweenPosition>();
            Vector3 vec = go.transform.localPosition;
            if (isUp)
            {
                tp.from = new Vector3(vec.x, vec.y - dis, vec.z);
            }
            else
            {
                tp.from = new Vector3(vec.x, vec.y + dis, vec.z);
            }
            tp.to = vec;
            tp.style = UITweener.Style.Once;
            tp.duration = 1f;
        }
        public static void SetUpDown2(GameObject go, float dis, bool isUp)
        {
            TweenPosition tp = AddOneComponent<TweenPosition>(go);
            Vector3 vec = go.transform.localPosition;
            if (isUp)
            {
                tp.to = new Vector3(vec.x, vec.y + dis, vec.z);
            }
            else
            {
                tp.to = new Vector3(vec.x, vec.y - dis, vec.z);
            }
            tp.from = vec;
            tp.style = UITweener.Style.Once;
            tp.duration = 1f;
        }

        public static void SetLeftRight(GameObject go, float dis, float time,bool isLeft)
        {
            TweenPosition tp = go.AddComponent<TweenPosition>();
            Vector3 vec = go.transform.localPosition;
            // 从左到右;
            if (isLeft)
            {
                tp.from = new Vector3(vec.x-dis, vec.y, vec.z);
            }
            else
            {
                tp.from = new Vector3(vec.x+dis, vec.y + dis, vec.z);
            }
            tp.to = vec;
            tp.style = UITweener.Style.Once;
            tp.duration = time;
        }
        public static void SetLeftRight2(GameObject go, float dis,bool isLeft)
        {      
            TweenPosition tp = go.AddComponent<TweenPosition>();
            Vector3 vec = go.transform.localPosition;
            // 向左边移动;
            if (isLeft)
            {
                tp.to = new Vector3(vec.x - dis, vec.y, vec.z);
            }
            else
            {
                tp.to = new Vector3(vec.x + dis, vec.y + dis, vec.z);
            }
            tp.from = vec;
            tp.style = UITweener.Style.Once;
            tp.duration = 1f;
        }
        public static GameObject CreateFruit(GameObject parent,fruitType type ,Vector3 vec)
        {
            GameObject obj = Instantiate(Resources.Load(UIPrafabs.oneFruit)) as GameObject;       
            obj.transform.parent = parent.transform;
            obj.transform.localScale = Vector3.one;
            obj.transform.localPosition = vec;
            FruitItem fruit = AddOneComponent<FruitItem>(obj);
            fruit.init(type);
            return fruit.getOne();
        }

        public static GameObject loadFruit(GameObject parent, fruitType type, Vector3 vec)
        {
            GameObject go = Instantiate(Resources.Load(UIPrafabs.oneFruit)) as GameObject;
            go.transform.parent = parent.transform;
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            FruitItem fruit = AddOneComponent<FruitItem>(go);
            fruit.init(type);
            fruit.setPos(vec);
            return fruit.getOne();
        }

        public static string getNameByType(fruitType type)
        {
            string fruitName = "";
            switch (type)
            {
                case fruitType.apple:
                    {
                        fruitName = "apple";
                    }
                    break;
                case fruitType.banana:
                    {
                        fruitName = "banana";
                    }
                    break;
                case fruitType.basaha:
                    {
                        fruitName = "basaha";
                    }
                    break;
                case fruitType.boom:
                    {
                        fruitName = "boom";
                    }
                    break;
                case fruitType.peach:
                    {
                        fruitName = "peach";
                    }
                    break;
                case fruitType.sandia:
                    {
                        fruitName = "sandia";
                    }
                    break;
            }
            return fruitName;
        }

        public static fruitType getTypeByID(int id)
        {
            return (fruitType)id;         
        }
        public static Vector2 getSizeByType(fruitType type)
        {
            Vector2 vec = Vector2.one;
            switch (type)
            {
                case fruitType.apple:
                    {
                        vec = new Vector2(66f,66f);
                    }
                    break;
                case fruitType.banana:
                    {
                        vec = new Vector2(126f, 50f);
                    }
                    break;
                case fruitType.basaha:
                    {
                        vec = new Vector2(68f, 72f);
                    }
                    break;
                case fruitType.boom:
                    {
                        vec = new Vector2(66f, 68f);
                    }
                    break;
                case fruitType.peach:
                    {
                        vec = new Vector2(62f, 59f);
                    }
                    break;
                case fruitType.sandia:
                    {
                        vec = new Vector2(98f, 85f);
                    }
                    break;
            }
            return vec;
        }
    }
}
