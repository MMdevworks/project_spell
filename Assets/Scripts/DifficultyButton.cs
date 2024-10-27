using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager; // when importing get reference to it in start method

    public int difficulty;
        
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        //Debug.Log(button.gameObject.name + " was clicked"); // logs name of difficulty button clicked in console
        //gameManager.StartGame(difficulty);
    }
}