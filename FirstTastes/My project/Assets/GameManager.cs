using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private MainMenu _startingSceneTransition;
    [SerializeField] private MainMenu _endingSceneTransition;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startingSceneTransition.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
