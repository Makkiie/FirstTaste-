using UnityEngine;
using UnityEngine.UI;


public class StoveButtonFireOfandOn : MonoBehaviour
{
    public Sprite StoveButton;
    public Button button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeButtonImage()
    {
        button.image.sprite = StoveButton;
    }
}
