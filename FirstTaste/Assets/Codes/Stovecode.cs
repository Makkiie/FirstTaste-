using UnityEngine;
using UnityEngine.UI;

public class Stovecode : MonoBehaviour
{
    public Sprite newButtonImage;
    public Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeButtonIage()
    {
        button.image.sprite = newButtonImage;
    }
}
