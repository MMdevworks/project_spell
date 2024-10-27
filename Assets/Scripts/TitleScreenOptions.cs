using UnityEngine;
using UnityEngine.UI;

public class TitleScreenOptions : MonoBehaviour
{
    private Button button;
    private GameManager gameManager; // when importing get reference to it in start method

    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        button.onClick.AddListener(LoadGame);
    }

    void Update()
    {

    }

    void LoadGame()
    {
        gameManager.StartGame();
    }
}
