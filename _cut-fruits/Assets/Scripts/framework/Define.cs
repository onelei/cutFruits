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
        public static float mMaxBottomY = -600f;
        public static int mMaxUpForceY = 370;
        public static int mMinUpForceY = 340;
    }
}
