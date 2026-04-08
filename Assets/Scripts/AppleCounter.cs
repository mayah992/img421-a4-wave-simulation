using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppleCounter : MonoBehaviour
{
    public int applesLeft;
    public TMP_Text counterText;
    public start_game mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        // find reference to start game game object
        GameObject CameraOG = GameObject.Find("Main Camera");
        // get the text component
        mainCamera = CameraOG.GetComponent<start_game>();
        
        applesLeft = mainCamera.apples.Count;
    }

    // Update is called once per frame
    void Update()
    {
        counterText.SetText("Apples Left: " + applesLeft.ToString());

        if(applesLeft == 0)
        {
            endGame();
        }
    }

    void endGame()
    {
        // change scene to winning 
        SceneManager.LoadScene("Game_Complete");
    }
}
