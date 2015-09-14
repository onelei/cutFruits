/*
 * 每个水果是一个预制物;
 * 水果上面都要帮这个脚本;
 */
using UnityEngine;
using System.Collections;
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
        bool startCheck = false;
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
            leftBody = Framework.AddOneComponent<Rigidbody>(left); 
            leftBody.useGravity = false;
            UISprite sp = left.GetComponent<UISprite>();
            sp.spriteName = fruitName + "-1";
            sp.height = (int)size.y;
            sp.width = (int)size.x;
            // right;
            left = mGo_Two.transform.FindChild("right").gameObject;
            rightBody = Framework.AddOneComponent<Rigidbody>(left); 
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

            if (startCheck)
            {
                StartCoroutine(startCheck2());
            }
        }

        public void StartCheck(bool check)
        {
            startCheck = check;
        }

        IEnumerator startCheck2()
        {
            yield return new WaitForSeconds(1f);
            reset();
        }

        void reset()
        {       
            leftBody.useGravity = false;
            rightBody.useGravity = false;
            leftBody.transform.localPosition = Vector3.zero;
            rightBody.transform.localPosition = Vector3.zero;
            gameObject.transform.localPosition = new Vector3(0f, GameData.mMaxBottomY);
            mGo_One.SetActive(true);
            mGo_Two.SetActive(false);
        }
       
    }
}
