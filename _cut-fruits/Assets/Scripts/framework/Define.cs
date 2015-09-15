using UnityEngine;

namespace cutFruits
{
    public enum fruitType
    {
        apple,
        banana,
        basaha,
        boom,
        peach,
        sandia
    }

    public class UIPrafabs
    {
        public const string UIMain = "UI/UIMain";
        public const string oneFruit = "onefruit";
    }

    public class GameData
    {
        public static float mMaxBottomY = -1000f;
        public static int mMaxUpForceY = 430;//410
        public static int mMinUpForceY = 430;//430
        public static int mMaxUpForceX = 15;
        public static int mMinUpForceX = -15;

        public static Vector3 Vec3_HeadBackGround = Vector3.zero;
        public static Vector3 Vec3_Head3Parent = new Vector3(114f,-185f);
        public static Vector3 Vec3_mGo_HeadParent = new Vector3(600f, -93f);
        public static Vector3 Vecs_mGo_GameParent = new Vector3(255f,0f);

    }
}
