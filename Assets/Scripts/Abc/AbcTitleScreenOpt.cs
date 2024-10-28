using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AbcTitleScreenOpt : MonoBehaviour
{
    //private Button startButton;
    //private Button abcButton;

    private AbcManager abcManager; // when importing get reference to it in start method

    void Start()
    {


        //Button button = GetComponent<Button>();
        //abcManager = GameObject.Find("Abc Manager").GetComponent<AbcManager>();

        //if (gameObject.name == "Start Button")
        //{
        //    button.onClick.AddListener(LoadGame);
        //}
        //else if (gameObject.name == "Abc Button")
        //{
        //    button.onClick.AddListener(LoadAbc);
        //}

    }

    void Update()
    {

    }

    void LoadGame()
    {
        abcManager.StartGame();
    }

    //void LoadAbc()
    //{
    //    SceneManager.LoadScene("Game_Abc");
    //}
}
