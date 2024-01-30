using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlinkingText : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textToBlink;
    public float timeToBlink;
    void Start()
    {
        StartCoroutine(BlinkText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator BlinkText(){
        yield return new WaitForSecondsRealtime(timeToBlink);
        textToBlink.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(timeToBlink);
        textToBlink.gameObject.SetActive(true);
        StartCoroutine(BlinkText());

    }
}
