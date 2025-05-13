using UnityEngine;

public class ChoppingSessionData : MonoBehaviour
{
    public static string itemID;     // ✅ This fixes your error
    public static string itemType;
    public static string result;     // "Perfect", "Good", "Bad" — used for scoring
    public static Sprite originalSprite;
}
