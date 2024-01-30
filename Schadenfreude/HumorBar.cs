using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class HumorBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image humorBar;
    public float humorDrain = 0.00005f;
    private float humorDrainObjects;
    public ObjectsOnStageCount objectsOnStageCount;
    public GameObject victory;
    public GameObject gameOver;
    public bool endGame;
    private changeScene changeScene;
    public GameObject pressAnyButton;
    private string gameWonOrLost;

    void Start()
    {

        changeScene = FindFirstObjectByType(typeof(changeScene)) as changeScene;
    }

    // Update is called once per frame
    void FixedUpdate(){
        if(humorBar.fillAmount < 1){
        humorBar.fillAmount = humorBar.fillAmount - humorDrain - humorDrainObjects;  
        }
    }
    void Update()
    {
        humorDrainObjects = 0.0005f * objectsOnStageCount.objectCount;
        
        if (humorBar.fillAmount <= 0){
            Debug.Log("Game Over");
            gameOver.SetActive(true);
            gameWonOrLost = "GameOver";
              StartCoroutine(WaitToEndGame());
            endGame = true;
        } 
         if (humorBar.fillAmount == 1){
            Debug.Log("Game Won!!");
            victory.SetActive(true);
            gameWonOrLost = "Victory";
            StartCoroutine(WaitToEndGame());
            endGame = true;
        }
         }
    IEnumerator WaitToEndGame(){
        yield return new WaitForSecondsRealtime(2);
        pressAnyButton.SetActive(true);
        changeScene.SendMessage(gameWonOrLost);
    }
}
