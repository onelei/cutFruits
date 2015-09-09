using UnityEngine;

namespace cutFruits
{
    public class Framework
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
    }
}
