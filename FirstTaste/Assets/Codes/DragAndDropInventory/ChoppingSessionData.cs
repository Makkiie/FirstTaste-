using UnityEngine;

public static class ChoppingSessionData
{
    public static string itemID;
    public static string itemType;
    public static string result;
    public static Sprite originalSprite;
    public static Sprite choppedSprite; // ✅ Add this

    public static Vector2? previousPosition;
}
