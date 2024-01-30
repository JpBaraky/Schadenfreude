using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] tomatoSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Floor")){
            audioSource.PlayOneShot(tomatoSound[Random.Range(0, tomatoSound.Length )]);
        }
    }
    
}
