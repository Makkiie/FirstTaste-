using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public ChoppingMechanic choppingMechanic;

    void Awake()
    {
        Instance = this;
    }

    // ✅ Accept both item name and sprite
    public void StartChopping(string itemName, Sprite itemSprite)
    {
        choppingMechanic.StartChopping(itemName, itemSprite);
    }
}
