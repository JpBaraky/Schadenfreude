using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class changeScene : MonoBehaviour
{
    public string targetScene;
    public bool isChangeScene;
    public float secondsToWait;
    private fadeBackground fadeBackground;
    private bool changingScene = false;
    public bool isChangeAnyButton;
    public bool isChangeSceneNow;
    
    // Start is called before the first frame update
    void Start()
    {
       fadeBackground = FindFirstObjectByType(typeof(fadeBackground)) as fadeBackground;
    }

    // Update is called once per frame
    void Update()
    {
        if(catOutOfBox.catIsOut) {
            catOutOfBox.catIsOut = false;
         StartCoroutine("changeSceneFadeOut");
        }
        ChangeSceneAnyButton();
        ChangeSceneNow();
    }
     IEnumerator changeSceneFadeOut() {
        yield return new WaitForSecondsRealtime(secondsToWait);
        fadeBackground.fadeIn();
        yield return new WaitWhile(() => fadeBackground.fume.color.a < 0.9f);
        yield return new WaitForEndOfFrame();        
         SceneManager.LoadScene(targetScene);
    }
    void  ChangeSceneAnyButton(){
        if(!changingScene && isChangeAnyButton ){
        
        if(Input.anyKeyDown){
            StartCoroutine(changeSceneFadeOut());
                changingScene = true;
        }
        }
    }
    public void GameOver(){
        targetScene = "TittleScreen";
        isChangeScene = true;
        isChangeAnyButton = true;

    }
    public void Victory(){
        targetScene = "EndingCredits";
        isChangeScene = true;
        isChangeAnyButton = true;

    }
    private void ChangeSceneNow(){
        if(isChangeSceneNow){   
              StartCoroutine(changeSceneFadeOut());
              isChangeSceneNow = false;
        }
    }
    
}