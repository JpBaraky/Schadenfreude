using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TomatoOnCrowd : MonoBehaviour


{
    public BoxCollider[] tomatoCrowd;
    public Image humorBar;
    public AudioSource audioSource;
    public AudioClip[] laughterAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("PickUpObjects")){
            if(audioSource!= null && laughterAudio != null){
            audioSource.PlayOneShot(laughterAudio[Random.Range(0, laughterAudio.Length)]);
     
            }
         humorBar.fillAmount += 0.07f;
        Destroy(other.gameObject);
        }

    }
}
