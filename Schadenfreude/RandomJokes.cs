using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomJokes : MonoBehaviour
{
    private int JokeID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string RandomizeJoke(int jokeId){
        switch(jokeId){
            case 0:
            return "What do you call a crocodile that is also a detective? An investi-gator.";            
            case 1:
            return "A dyslexic man walks into a bra.";
            case 2:
            return "Did you hear about the Italian chef who died? He pasta-way";
            case 3:
            return "What do you call a magician who lost their magic? Ian.";
            case 4:
            return "How does your feline shop? By reading a catalog.";
            case 5:
            return "What did the ocean say to the beach? Nothing, it just waved.";
            case 6:
            return "Why don't skeletons fight each other? They don't have the guts.";
            case 7:
            return "A communist joke isn’t funny… … unless everyone gets it.";
            case 8:
            return "Does anyone need an ark? I Noah guy!";
            case 9:
            return "What's big, gray and doesn't matter? An irrelephant.";
            case 10:
            return "What do you call a fish with no eyes? A fsh.";
            case 11:
            return "What kind of dog does a magician have? A Labracadabrador.";
            case 12: 
            return "What do you call a sad cup of coffee? Depresso";
            default: 
            return "Joke not found";


        }
    }
}
