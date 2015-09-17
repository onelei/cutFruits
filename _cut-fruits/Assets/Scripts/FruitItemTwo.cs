/*
 * 每个水果是一个预制物;
 * 水果上面都要帮这个脚本;
 */
using UnityEngine;
using System.Collections;
namespace cutFruits
{
    public class  FruitItemTwo:MonoBehaviour
    {

        Rigidbody leftBody;
        Rigidbody rightBody;
        bool isNeedUp = true;
        float _time = 0f;
        bool startCheck = false;
        fruitType mType;
        void findUI()
        {
            GameObject go = transform.FindChild("left").gameObject;
            leftBody = Framework.AddOneComponent<Rigidbody>(go);
            go = transform.FindChild("right").gameObject;
            rightBody = Framework.AddOneComponent<Rigidbody>(go);    
        }

        // 外部初始化;
        public void init(fruitType type)
        {
            this.mType = type;
            findUI();
            string fruitName = Framework.getNameByType(type);
            Vector2 size = Framework.getSizeByType(type);
            // 设置切开的水果;
            // left;
            GameObject left = gameObject.transform.FindChild("left").gameObject;
            UISprite sp = left.GetComponent<UISprite>();
            sp.spriteName = fruitName + "-1";
            sp.height = (int)size.y;
            sp.width = (int)size.x;
            // right;
            left = gameObject.transform.FindChild("right").gameObject;
            sp = left.GetComponent<UISprite>();
            sp.spriteName = fruitName + "-2";
            sp.height = (int)size.y;
            sp.width = (int)size.x;

            leftBody.isKinematic = true;
            rightBody.isKinematic = true;
        }

        // 开始分裂;
        public void doAction(bool isNeedUp)
        {
            // 判断游戏是否结束;
            if(mType==fruitType.boom)
            {
                Framework.Pause();
                GameOver.Instance.Over();
                return;
            }
            this.isNeedUp = isNeedUp;
            leftBody.isKinematic = false;
            rightBody.isKinematic = false;
            leftBody.velocity = Vector3.zero;
            rightBody.velocity = Vector3.zero;
            leftBody.AddForce(new Vector3(100f,-100f,0f));
            rightBody.AddForce(new Vector3(-100f, -100f, 0f));

            startCheck = true;
        }

        void Update()
        {
            if(startCheck)
            {
                _time += Time.deltaTime;
                if(_time>2)
                {
                    _time = 0f;
                    startCheck = false;
                    reset();
                }
            }
        }
    
        void reset()
        {
            // 去除动力学;
          
            leftBody.isKinematic = true;
            rightBody.isKinematic = true;
            
            // 位置置为0;
            leftBody.transform.localPosition = Vector3.zero;
            rightBody.transform.localPosition = Vector3.zero;
            // 划过水果之后,要将水果重新向上抛;
            if (isNeedUp)
            {
                FruitItem item = gameObject.GetComponentInParent<FruitItem>();
                item.reSet();
            }
            gameObject.SetActive(false);
        }
       
    }
}
