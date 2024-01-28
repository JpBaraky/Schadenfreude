using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ButtonGame : MonoBehaviour

    {
    public Sprite[] buttonImages; // Assign button images in the Unity Editor
    public Image buttonImage; // Reference to the button image component
    private int[] sequence; // Generated random sequence
    private int currentIndex; // Current index in the sequence
    public PlayerInput playerInput; // Reference to the PlayerInput component
    public Image humorBar;
    public MicArea micArea;
    private bool canPressButtons;
    public Image[] nextButtons;
    public GameObject JokePanel;
    public TextMeshProUGUI jokeText;
    private int currentButton;
    private bool tellingJoke;
    private RandomJokes randomJokes;
    private SpawnTomatos spawnTomatos;
    public AudioSource audioSource;
    public AudioClip[] booSound;

    void Update(){
         
           DisplayNextButton();
            RightButton();
            MicAreaButtonAppears();
          

    }

    void Start()
    {   
        spawnTomatos = GetComponent<SpawnTomatos>();
        randomJokes = GetComponent<RandomJokes>();
        GenerateAndDisplaySequence();
      
    }

    void GenerateAndDisplaySequence()
    {
        GenerateSequence();
        DisplayNextButton();
    }

    void GenerateSequence()
    {
        
        // Generate a random sequence of button indices
        sequence = new int[buttonImages.Length];
        for (int i = 0; i < sequence.Length; i++)
        {
            sequence[i] = Random.Range(0, buttonImages.Length);
        }
       
       
    }

   

    void DisplayNextButton()
    {
        if (currentIndex >= sequence.Length)
        {

            currentIndex = 0;
            GenerateSequence();
            StartCoroutine(TellJoke());
        }
        // Display button at currentIndex
        int buttonIndex = sequence[currentIndex];
         buttonImage.sprite = buttonImages[sequence[buttonIndex]];
         /* if(currentIndex <= 2){
            nextButtons[0].enabled = true;
         nextButtons[0].sprite = buttonImages[currentIndex +1];
         } 
         else{
            nextButtons[0].enabled = false;
         }
         if(currentIndex <=1){
             nextButtons[1].enabled = true;
         nextButtons[1].sprite = buttonImages[currentIndex +2];
         }
         else{
            nextButtons[1].enabled = false;
         }
         if(currentIndex <= 0){
             nextButtons[2].enabled = true;
         nextButtons[2].sprite = buttonImages[currentIndex+3];
         } else{
        nextButtons[2].enabled = false;
         } */
        // Logic to display button at buttonIndex on the screen


        //currentIndex++;
      
        // Reset index and randomize sequence when the end is reached
        
    }
    void RightButton(){
        if(canPressButtons){
            
        
        if(buttonImage.sprite.name == "ArrowDown" && playerInput.actions["Down"].triggered){
            humorBar.fillAmount += 0.07f;
            currentIndex++;
        }
        if(buttonImage.sprite.name == "ArrowLeft" && playerInput.actions["Left"].triggered){
            humorBar.fillAmount += 0.07f;
            currentIndex++;
      
        }
        if(buttonImage.sprite.name == "ArrowRight" && playerInput.actions["Right"].triggered){
            humorBar.fillAmount += 0.07f;
            currentIndex++;
         
        }
        if(buttonImage.sprite.name == "ArrowUp" && playerInput.actions["Up"].triggered){
            humorBar.fillAmount += 0.07f;
            currentIndex++;
          
        }
        }
    }
    void MicAreaButtonAppears(){
       if(micArea.isOnArea && !tellingJoke){
        canPressButtons = true;
        buttonImage.enabled = true;
       } else{
        canPressButtons = false;
        buttonImage.enabled = false;
       }
    }
    
    IEnumerator TellJoke(){
        jokeText.text = randomJokes.RandomizeJoke(Random.Range(0, 13));

        tellingJoke = true;
        canPressButtons = false;
         buttonImage.enabled = false;
        JokePanel.SetActive(true);
        yield return new WaitForSeconds(1);
        if(audioSource != null && booSound!= null){
        audioSource.PlayOneShot(booSound[Random.Range(0, booSound.Length)]);
        }
        spawnTomatos.StartSpawnTomato();
        yield return new WaitForSeconds(1);
        JokePanel.SetActive(false);
        canPressButtons = true;
        buttonImage.enabled = true;
        tellingJoke = false;
         

    }

    

}