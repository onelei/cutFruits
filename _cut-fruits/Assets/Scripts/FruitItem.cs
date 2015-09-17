/*
 * 每个水果是一个预制物;
 * 水果上面都要帮这个脚本;
 */
using UnityEngine;
using System.Collections;
namespace cutFruits
{
    public class FruitItem : MonoBehaviour
    {
        private readonly string mGo_One_Path = "fruit";
        private readonly string mGo_Two_Path = "child";

        GameObject mGo_One;
        GameObject mGo_Two;

        FruitItemTwo itemTwo;
        FruitItemOne itemOne;
        // true是菜单按钮,false为button按钮;
        bool tag = false;
        fruitType type;
        void findUI()
        {
            mGo_One = transform.FindChild(mGo_One_Path).gameObject;
            mGo_Two = transform.FindChild(mGo_Two_Path).gameObject;
            itemTwo = Framework.AddOneComponent<FruitItemTwo>(mGo_Two);
            itemOne = Framework.AddOneComponent<FruitItemOne>(mGo_One);
        }

        public void init(fruitType type)
        {
            this.type = type;
            findUI();
            // 设置切开的水果的类型;
            itemOne.init(type);
            itemTwo.init(type);
            mGo_One.SetActive(true);
            mGo_Two.SetActive(false);
        }

        public void setPos(Vector3 vec)
        {
            mGo_One.transform.localPosition = vec;
        }

        public GameObject getOne()
        {
            return mGo_One;
        }

        public GameObject getTwo()
        {
            return mGo_Two;
        }

        public void doAction(bool isNeedUp)
        {
            mGo_One.SetActive(false);
            mGo_Two.SetActive(true);
            itemTwo.doAction(isNeedUp);
        }

        public void reSet(bool isNeedUp)
        {
            // 不是按钮;
            if (isNeedUp)
            {
                UIMain.Instance.setUp(itemOne);
                mGo_One.SetActive(true);
                return;
            }
            else
            {
                // 是按钮;
                // 西瓜的话就隐藏;
                if (type != fruitType.sandia)
                {
                    mGo_One.SetActive(true);
                }
                else
                {
                    mGo_One.SetActive(false);
                }
            }

        }


    }
}
