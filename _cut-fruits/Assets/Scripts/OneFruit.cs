/*
 * 每个水果是一个预制物;
 * 水果上面都要帮这个脚本;
 */
using UnityEngine;
namespace cutFruits
{
    public class  OneFruit:MonoBehaviour
    {
        private readonly string mGo_One_Path = "fruit";
        private readonly string mGo_Two_Path = "child";

        GameObject mGo_One;
        GameObject mGo_Two;
        Rigidbody leftBody;
        Rigidbody rightBody;
        void findUI()
        {
            mGo_Two = transform.FindChild(mGo_Two_Path).gameObject;
            mGo_Two.SetActive(true);
            mGo_One = Framework.AddOnClick(gameObject, mGo_One_Path, onClick);
        }

        public void init(fruitType type)
        {
            findUI();
            string fruitName = Framework.getNameByType(type);
            Vector2 size = Framework.getSizeByType(type);
            // 设置切开的水果;
            // left;
            GameObject left = mGo_Two.transform.FindChild("left").gameObject;
            leftBody = left.AddComponent<Rigidbody>();
            leftBody.useGravity = false;
            UISprite sp = left.GetComponent<UISprite>();
            sp.spriteName = fruitName + "-1";
            sp.height = (int)size.y;
            sp.width = (int)size.x;
            // right;
            left = mGo_Two.transform.FindChild("right").gameObject;
            rightBody = left.AddComponent<Rigidbody>();
            rightBody.useGravity = false;
            sp = left.GetComponent<UISprite>();
            sp.spriteName = fruitName + "-2";
            sp.height = (int)size.y;
            sp.width = (int)size.x;
            mGo_Two.SetActive(false);

            // 设置水果名称;
            sp = mGo_One.GetComponent<UISprite>();
            sp.spriteName = fruitName;
            sp.height = (int)size.y;
            sp.width = (int)size.x;
        }

        public GameObject getOne()
        {
            return mGo_One;
        }

        public void onClick(object obj)
        {
            mGo_One.SetActive(false);
            mGo_Two.SetActive(true);

            leftBody.useGravity = true;
            rightBody.useGravity = true;

            leftBody.AddForce(new Vector3(60f,0f,0f));
            rightBody.AddForce(new Vector3(-60f, 0f, 0f));
        }

        //void Update()
        //{
        //    if (isStartCheck)
        //    {
        //        bool tmp1 = false;
        //        bool tmp2 = false;
        //        if (leftBody.gameObject.transform.localPosition.y <= -500f)
        //        {
        //            leftBody.gameObject.SetActive(false);
        //            tmp1 = true;
        //        }
        //        if (rightBody.gameObject.transform.localPosition.y <= -500f)
        //        {
        //            rightBody.gameObject.SetActive(false);
        //            tmp2 = true;
        //        } 
        //        if(tmp1&&tmp2)
        //        {
        //            isStartCheck = false;
        //        }
        //    }
         
        //}
    }
}
