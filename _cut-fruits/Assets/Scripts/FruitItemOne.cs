/*
 * 每个水果是一个预制物;
 * 水果上面都要帮这个脚本;
 */
using UnityEngine;
using System.Collections;
namespace cutFruits
{
    public class  FruitItemOne:MonoBehaviour
    {

        public void init(fruitType type)
        {
            string fruitName = Framework.getNameByType(type);
            Vector2 size = Framework.getSizeByType(type);
            UISprite sp = GetComponent<UISprite>();
            sp.spriteName = fruitName;
            sp.height = (int)size.y;
            sp.width = (int)size.x;
        }

        public void onClick(object obj)
        {
            gameObject.SetActive(false);
            // 像父节点发送被按下的消息;
            FruitItem item = gameObject.GetComponentInParent<FruitItem>();
            item.doAction(true);
        }    
       

    }
}
