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
    }
}
